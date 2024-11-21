using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeliveryHUB
{
    public partial class UserForm : Form
    {
        private BD db = new BD(); // Экземпляр подключения к базе данных
        private DataTable ordersTable; // Таблица для хранения данных
        private string currentSortColumn = ""; // Текущая колонка для сортировки
        private string currentSortOrder = "ASC"; // Текущий порядок сортировки
        private bool isExitButtonClicked = false;

        public UserForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders(); // Загружаем данные при загрузке формы
            LoadPickupPoints(); // Загружаем пункты выдачи
            LoadStatusOrders(); // Загружаем статусы заказов
            PopulateSortColumns(); // Загружаем названия колонок для сортировки
        }
        private void LoadPickupPoints()
        {
            try
            {
                db.openConnection();

                string query = "SELECT Address FROM PickupPoints";
                SqlCommand command = new SqlCommand(query, db.GetSqlConnection());
                SqlDataReader reader = command.ExecuteReader();

                cmbPickupPoints.Items.Clear();
                cmbPickupPoints.Items.Add("Выберите пункт"); // Пункт по умолчанию

                while (reader.Read())
                {
                    cmbPickupPoints.Items.Add(reader["Address"].ToString());
                }

                cmbPickupPoints.SelectedIndex = 0; // Устанавливаем пункт по умолчанию
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пунктов выдачи: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void LoadStatusOrders()
        {
            try
            {
                db.openConnection();

                string query = "SELECT StatusDescription FROM OrderStatus";
                SqlCommand command = new SqlCommand(query, db.GetSqlConnection());
                SqlDataReader reader = command.ExecuteReader();

                cmbStatusOrders.Items.Clear();
                cmbStatusOrders.Items.Add("Выберите статус"); // Пункт по умолчанию

                while (reader.Read())
                {
                    cmbStatusOrders.Items.Add(reader["StatusDescription"].ToString());
                }

                cmbStatusOrders.SelectedIndex = 0; // Устанавливаем пункт по умолчанию
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов заказов: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private int currentCustomerId; // ID авторизованного клиента

        public UserForm(int customerId)
        {
            InitializeComponent();
            currentCustomerId = customerId; // Сохраняем ID клиента
        }

        private void LoadOrders()
        {
            try
            {
                db.openConnection();

                // Обновленный SQL-запрос с фильтром по CustomerID
                string query = @"
SELECT 
    o.OrderID AS НомерЗаказа, 
    os.StatusDescription AS Статус,
    p.PaymentMethod AS Оплата,
    pp.Address AS ПунктВыдачи,
    pr.Name AS Товар,
    o.OrderDate AS Дата,
    o.TotalAmount AS Цена
FROM Orders o
LEFT JOIN OrderStatus os ON o.Status = os.StatusID
LEFT JOIN Payments p ON o.PaymentID = p.PaymentID
LEFT JOIN PickupPoints pp ON o.PickupPointID = pp.PickupPointID
LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
LEFT JOIN Products pr ON oi.ProductID = pr.ProductID
WHERE o.CustomerID = @CustomerID"; // Фильтр по CustomerID

                SqlCommand command = new SqlCommand(query, db.GetSqlConnection());
                command.Parameters.AddWithValue("@CustomerID", currentCustomerId); // Передаем CustomerID

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                ordersTable = new DataTable();
                adapter.Fill(ordersTable);

                // Обновляем DataGridView
                dataGridViewOrders.DataSource = ordersTable;
                dataGridViewOrders.AutoGenerateColumns = true;
                dataGridViewOrders.ReadOnly = true; // Запрет редактирования
                dataGridViewOrders.AllowUserToAddRows = false; // Запрет добавления строк
                dataGridViewOrders.AllowUserToDeleteRows = false; // Запрет удаления строк
                dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выделение только всей строки
                dataGridViewOrders.MultiSelect = false; // Запрет на множественный выбор


                // Делаем таблицу только для чтения
                dataGridViewOrders.ReadOnly = true;

                ApplyFiltersAndSorting(); // Применяем фильтры и сортировку
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных из таблицы Orders: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }


        private void PopulateSortColumns()
        {
            cmbSortTable.Items.Clear();
            cmbSortTable.Items.Add("Выберите колонку для сортировки"); // Пункт по умолчанию

            // Добавляем названия колонок из DataTable
            foreach (DataColumn column in ordersTable.Columns)
            {
                cmbSortTable.Items.Add(column.ColumnName);
            }

            cmbSortTable.SelectedIndex = 0; // Устанавливаем пункт по умолчанию
        }

        private void cmbSortTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSortTable.SelectedIndex == 0) // Если выбран пункт по умолчанию
            {
                currentSortColumn = ""; // Сбрасываем сортировку
                ApplyFiltersAndSorting();
                return;
            }

            currentSortColumn = cmbSortTable.SelectedItem.ToString(); // Получаем выбранную колонку
            currentSortOrder = "ASC"; // Устанавливаем сортировку по возрастанию
            ApplyFiltersAndSorting();
        }


        private void ApplyFiltersAndSorting()
        {
            try
            {
                string selectedAddress = cmbPickupPoints.SelectedItem?.ToString();
                string selectedStatus = cmbStatusOrders.SelectedItem?.ToString();

                string filterExpression = "";

                // Фильтр по пункту выдачи
                if (!string.IsNullOrEmpty(selectedAddress) && selectedAddress != "Выберите пункт")
                {
                    filterExpression += $"[ПунктВыдачи] = '{selectedAddress}'"; // Используйте отображаемое имя столбца
                }

                // Фильтр по статусу заказа
                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Выберите статус")
                {
                    if (!string.IsNullOrEmpty(filterExpression))
                    {
                        filterExpression += " AND ";
                    }
                    filterExpression += $"[Статус] = '{selectedStatus}'"; // Используйте отображаемое имя столбца
                }

                // Применяем фильтр
                ordersTable.DefaultView.RowFilter = filterExpression;

                // Применяем сортировку
                if (!string.IsNullOrEmpty(currentSortColumn))
                {
                    ordersTable.DefaultView.Sort = $"{currentSortColumn} {currentSortOrder}";
                }

                // Обновляем DataGridView напрямую из DefaultView
                dataGridViewOrders.DataSource = ordersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении фильтров или сортировки: {ex.Message}", "Ошибка");
            }
        }


        private void cmbPickupPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSorting(); // Применяем фильтры и сортировку при изменении пункта
        }

        private void cmbStatusOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSorting(); // Применяем фильтры и сортировку при изменении статуса
        }

        private void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExitButtonClicked) // Если форма закрывается не через кнопку "Выход"
            {
                // Завершаем процесс приложения
                Application.Exit();
            }
        }


        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открываем окно для ввода строки поиска
            string searchQuery = Prompt.ShowDialog("Введите текст для поиска:", "Поиск");

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                string filterExpression = "";

                // Формируем выражение для фильтрации по всем текстовым столбцам
                foreach (DataColumn column in ordersTable.Columns)
                {
                    if (column.DataType == typeof(string)) // Учитываем только текстовые столбцы
                    {
                        if (!string.IsNullOrEmpty(filterExpression))
                        {
                            filterExpression += " OR ";
                        }
                        filterExpression += $"{column.ColumnName} LIKE '%{searchQuery}%'";
                    }
                }

                if (!string.IsNullOrEmpty(filterExpression))
                {
                    ordersTable.DefaultView.RowFilter = filterExpression;

                    // Обновляем DataGridView
                    dataGridViewOrders.DataSource = ordersTable.DefaultView.ToTable();
                }
                else
                {
                    MessageBox.Show("Невозможно выполнить поиск. Нет доступных текстовых столбцов.", "Поиск");
                }
            }
            else
            {
                MessageBox.Show("Введите строку для поиска.", "Поиск");
            }
        }


 

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "ОК", Left = 280, Width = 80, Top = 90 };

                confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;
                
                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сбрасываем фильтры и сортировку
            cmbPickupPoints.SelectedIndex = 0;
            cmbStatusOrders.SelectedIndex = 0;
            cmbSortTable.SelectedIndex = 0;
            currentSortColumn = "";
            currentSortOrder = "ASC";

            // Перезагружаем данные
            LoadOrders();
            MessageBox.Show("Данные успешно обновлены.", "Обновить");
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Устанавливаем флаг, что выход был инициирован кнопкой "Выход"
            isExitButtonClicked = true;

            // Открываем форму авторизации
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // Закрываем текущую форму
            this.Close();
        }


    }
}


using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static DeliveryHUB.MainForm;

namespace DeliveryHUB
{
    public partial class MainForm : MaterialForm
    {
        private BD db = new BD(); // Экземпляр подключения к базе данных






        public static class ThemeManager
        {
            public enum Theme
            {
                Light, Dark
            }
            private static Theme currentTheme = Theme.Light;
            public static void ApplyTheme(Form form)
            {
                // Применяем тему к контролам
                ApplyThemeToControls(form.Controls);

                // Обновляем тему MaterialSkin
                var materialSkinManager = MaterialSkinManager.Instance;
                if (currentTheme == Theme.Dark)
                {
                    form.BackColor = Color.FromArgb(45, 45, 45);
                    form.ForeColor = Color.White;
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                }
                else
                {
                    form.BackColor = Color.FromArgb(233, 233, 233);
                    form.ForeColor = Color.FromArgb(50, 50, 50);
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                }
            }
            public static void ToggleTheme(Form form)
            {
                currentTheme = currentTheme == Theme.Light ? Theme.Dark : Theme.Light;

                // Применяем тему
                ApplyTheme(form);

            }
            private static void ApplyThemeToControls(Control.ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    switch (control)
                    {
                        case Button button:
                            ApplyThemeToButton(button);
                            break;
                        //case Label label:
                        //    ApplyThemeToLabel(label); break;
                        case TextBox textBox:
                            ApplyThemeToTextBox(textBox); break;
                        case DataGridView dataGridView:
                            ApplyThemeToDataGridView(dataGridView); break;
                        //case ComboBox comboBox:
                        //    ApplyThemeToComboBox(comboBox); break;
                        case Panel panel:
                            panel.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(245, 245, 245); break;
                        case GroupBox groupBox:
                            groupBox.ForeColor = currentTheme == Theme.Dark ? Color.White : Color.FromArgb(50, 50, 50); break;
                    }
                    if (control.Controls.Count > 0)
                    {
                        ApplyThemeToControls(control.Controls);
                    }
                }
            }
            private static void ApplyThemeToButton(Button button)
            {
                button.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.FromArgb(72, 61, 139);
                button.ForeColor = currentTheme == Theme.Dark ? Color.White : Color.White; button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
            private static void ApplyThemeToLabel(Label label)
            {
                //label.ForeColor = currentTheme == Theme.Dark ? Color.White : Color.Black;
            }
            private static void ApplyThemeToTextBox(TextBox textBox)
            {
                textBox.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.White; textBox.ForeColor = currentTheme == Theme.Dark ? Color.White : Color.FromArgb(50, 50, 50);
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            private static void ApplyThemeToDataGridView(DataGridView dataGridView)
            {
                dataGridView.BackgroundColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.FromArgb(242, 242, 242);
               dataGridView.DefaultCellStyle.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.White; dataGridView.DefaultCellStyle.ForeColor = currentTheme == Theme.Dark ? Color.FromArgb(242, 242, 242) : Color.FromArgb(50, 50, 50);
                dataGridView.DefaultCellStyle.SelectionBackColor = currentTheme == Theme.Dark ? Color.FromArgb(100, 100, 100) : Color.FromArgb(176, 224, 230); dataGridView.DefaultCellStyle.SelectionForeColor = currentTheme == Theme.Dark ? Color.FromArgb(242, 242, 242) : Color.FromArgb(50, 50, 50);
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.FromArgb(72, 61, 139);
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = currentTheme == Theme.Dark ? Color.FromArgb(242, 242, 242) : Color.FromArgb(242, 242, 242);
                dataGridView.GridColor = currentTheme == Theme.Dark ? Color.Gray : Color.LightGray;
            }
            private static void ApplyThemeToComboBox(ComboBox comboBox)
            {
                //comboBox.BackColor = currentTheme == Theme.Dark ? Color.FromArgb(50, 50, 50) : Color.White;
                //comboBox.ForeColor = currentTheme == Theme.Dark ? Color.White : Color.Black;
            }
        }
    
 

    public MainForm()
        {
            InitializeComponent();

            ThemeManager.ApplyTheme(this);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.LightGreen200, TextShade.WHITE);


        }

        private void UpdateFilterVisibility()
        {
            // Проверяем, выбрана ли таблица Orders
            bool isOrdersTable = SwitchingTablesBox.SelectedItem?.ToString() == "Orders";

            // Управляем видимостью элементов фильтрации
            cmbPickupPoints.Visible = isOrdersTable;
            cmbStatusOrders.Visible = isOrdersTable;
            FilterLabel.Visible = isOrdersTable;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "deliveryHUBDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.deliveryHUBDataSet.Orders);
            PopulateTableList(); // Заполняем список таблиц в ComboBox
            LoadPickupPoints();  // Загружаем адреса из PickupPoints в ComboBox
            LoadStatusOrders();  // Загружаем статусы заказов в ComboBox
            UpdateFilterVisibility();   // Устанавливаем видимость фильтров в зависимости от выбранной таблицы
        }
        private string currentSortColumn = null; // Имя текущего столбца сортировки
        private void ApplySorting()
        {
            if (!string.IsNullOrEmpty(currentSortColumn) && dataGridViewMain.DataSource is DataTable currentTable)
            {
                currentTable.DefaultView.Sort = $"{currentSortColumn} ASC"; // Сортировка по возрастанию
                currentTable = currentTable.DefaultView.ToTable(); // Применяем сортировку
                dataGridViewMain.DataSource = currentTable; // Обновляем отображение
            }
        }


        private void PopulateTableList()
        {
            try
            {
                db.openConnection();
                DataTable schema = db.GetSqlConnection().GetSchema("Tables");

                SwitchingTablesBox.Items.Clear();
                foreach (DataRow row in schema.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    // Исключаем таблицу sysdiagrams
                    if (!string.Equals(tableName, "sysdiagrams", StringComparison.OrdinalIgnoreCase))
                    {
                        SwitchingTablesBox.Items.Add(tableName);
                    }
                }

                if (SwitchingTablesBox.Items.Count > 0)
                    SwitchingTablesBox.SelectedIndex = 5; // Выбираем пятую таблицу по умолчанию
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка таблиц: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }


        private void LoadData(string tableName)
        {
            try
            {
                db.openConnection();

                // Получаем данные таблицы
                string query = $"SELECT * FROM {tableName}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Получаем информацию о первичном ключе
                DataTable primaryKeyInfo = db.GetSqlConnection().GetSchema("IndexColumns", new[] { null, null, tableName, null });
                string primaryKeyColumn = primaryKeyInfo.Rows.Count > 0 ? primaryKeyInfo.Rows[0]["COLUMN_NAME"].ToString() : null;

                // Устанавливаем источник данных
                dataGridViewMain.DataSource = table;
                dataGridViewMain.AllowUserToAddRows = false;

                // Делаем колонку с первичным ключом только для чтения
                if (!string.IsNullOrEmpty(primaryKeyColumn) && dataGridViewMain.Columns.Contains(primaryKeyColumn))
                {
                    dataGridViewMain.Columns[primaryKeyColumn].ReadOnly = true;
                    //dataGridViewMain.Columns[primaryKeyColumn].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    //dataGridViewMain.Columns[primaryKeyColumn].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    //dataGridViewMain.Columns[primaryKeyColumn].HeaderCell.Style.BackColor = System.Drawing.Color.DarkRed;
                }

                // Устанавливаем размер шрифта заголовков всех колонок
                foreach (DataGridViewColumn column in dataGridViewMain.Columns)
                {
                    column.HeaderCell.Style.Font = new System.Drawing.Font("Mongolian Baiti", 20, System.Drawing.FontStyle.Italic); // Устанавливаем размер шрифта для заголовка
                }

                // Применяем другие настройки
                PopulateSortColumns();
                ApplySorting(); // Применяем сохраненную сортировку

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных таблицы: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }




        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу перед добавлением записи.", "Ошибка");
                return;
            }

            string tableName = SwitchingTablesBox.SelectedItem.ToString();
            try
            {
                db.openConnection();
                DataTable schema = db.GetSqlConnection().GetSchema("Columns", new[] { null, null, tableName });

                string query = $"INSERT INTO {tableName} ({string.Join(", ", schema.AsEnumerable().Select(row => row["COLUMN_NAME"].ToString()))}) VALUES ({string.Join(", ", schema.AsEnumerable().Select((_, index) => $"@param{index}"))})";

                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    foreach (DataRow row in schema.Rows)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        string value = Prompt.ShowDialog($"Введите значение для {columnName}:", "Добавить запись");

                        if (string.IsNullOrEmpty(value))
                            command.Parameters.AddWithValue($"@param{schema.Rows.IndexOf(row)}", DBNull.Value);
                        else
                            command.Parameters.AddWithValue($"@param{schema.Rows.IndexOf(row)}", value);
                    }

                    command.ExecuteNonQuery();
                }
                LoadData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления записи: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem == null || dataGridViewMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите таблицу и запись для редактирования.", "Ошибка");
                return;
            }

            string tableName = SwitchingTablesBox.SelectedItem.ToString();
            try
            {
                db.openConnection();
                DataTable schema = db.GetSqlConnection().GetSchema("Columns", new[] { null, null, tableName });

                string keyColumn = schema.Rows[0]["COLUMN_NAME"].ToString();
                int id = Convert.ToInt32(dataGridViewMain.SelectedRows[0].Cells[0].Value);

                string query = $"UPDATE {tableName} SET {string.Join(", ", schema.Rows.Cast<DataRow>().Skip(1).Select((row, index) => $"{row["COLUMN_NAME"]} = @param{index}"))} WHERE {keyColumn} = @id";

                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    for (int i = 1; i < schema.Rows.Count; i++)
                    {
                        string columnName = schema.Rows[i]["COLUMN_NAME"].ToString();
                        string newValue = Prompt.ShowDialog($"Введите новое значение для {columnName}:", "Редактировать запись");

                        if (string.IsNullOrEmpty(newValue))
                            command.Parameters.AddWithValue($"@param{i - 1}", DBNull.Value);
                        else
                            command.Parameters.AddWithValue($"@param{i - 1}", newValue);
                    }
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                LoadData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка редактирования записи: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem == null || dataGridViewMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите таблицу и запись для удаления.", "Ошибка");
                return;
            }

            string tableName = SwitchingTablesBox.SelectedItem.ToString();
            try
            {
                db.openConnection();
                // Получаем первичный ключ выбранной записи
                string keyColumn = db.GetSqlConnection().GetSchema("Columns", new[] { null, null, tableName }).Rows[0]["COLUMN_NAME"].ToString();
                int id = Convert.ToInt32(dataGridViewMain.SelectedRows[0].Cells[0].Value);

                // Проверяем наличие связанных записей
                string relatedRecords = CheckRelatedRecords(id, tableName);

                // Формируем сообщение для подтверждения удаления
                string message = string.IsNullOrEmpty(relatedRecords)
                    ? $"Вы уверены, что хотите удалить запись с ID = {id} из таблицы '{tableName}'?"
                    : $"Вы уверены, что хотите удалить запись с ID = {id} из таблицы '{tableName}'?\n" +
                      $"Эта запись связана со следующими данными:\n{relatedRecords}";

                // Показываем диалоговое окно с предупреждением
                DialogResult result = MessageBox.Show(
                    message,
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Если пользователь выбрал "No", отменяем удаление
                if (result == DialogResult.No)
                {
                    return;
                }

                // Выполняем удаление записи
                string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @id";

                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                LoadData(tableName);
                MessageBox.Show("Запись успешно удалена.", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления записи: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void SwitchingTablesBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem != null)
            {
                string selectedTable = SwitchingTablesBox.SelectedItem.ToString();
                LoadData(selectedTable);
            }
            // Обновляем видимость фильтров
            UpdateFilterVisibility();
        }

        private void dataGridViewMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Игнорируем заголовки

            if (SwitchingTablesBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу для редактирования данных.", "Ошибка");
                return;
            }

            string tableName = SwitchingTablesBox.SelectedItem.ToString();

            try
            {
                db.openConnection();

                // Определяем имя колонки и значение ключевого столбца
                string columnName = dataGridViewMain.Columns[e.ColumnIndex].HeaderText;
                string keyColumn = dataGridViewMain.Columns[0].HeaderText; // Предполагаем, что ключевой столбец — первый
                object id = dataGridViewMain.Rows[e.RowIndex].Cells[0].Value;

                if (id == null)
                {
                    MessageBox.Show("Не удалось определить ключевую колонку для редактирования.", "Ошибка");
                    return;
                }

                // Получаем новое значение из измененной ячейки
                object newValue = dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? DBNull.Value;

                // Формируем запрос для обновления
                string query = $"UPDATE {tableName} SET {columnName} = @value WHERE {keyColumn} = @id";
                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    command.Parameters.AddWithValue("@value", newValue);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                //MessageBox.Show("Данные успешно обновлены.", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void dataGridViewMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMain_CellValueChanged(sender, e); // Вызываем обновление данных
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу перед поиском.", "Ошибка");
                return;
            }

            string searchValue = Prompt.ShowDialog("Введите значение для поиска:", "Поиск");
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Значение для поиска не введено.", "Ошибка");
                return;
            }

            try
            {
                DataTable table = (DataTable)dataGridViewMain.DataSource;
                if (table == null)
                {
                    MessageBox.Show("Данные таблицы не загружены.", "Ошибка");
                    return;
                }

                // Проверяем, является ли введенное значение числом
                bool isNumeric = int.TryParse(searchValue, out int numericValue);

                // Формируем фильтр в зависимости от типа данных столбцов
                string filter = string.Join(" OR ", table.Columns.Cast<DataColumn>().Select(col =>
                {
                    if (col.DataType == typeof(string))
                    {
                        return $"{col.ColumnName} LIKE '%{searchValue}%'";
                    }
                    else if (col.DataType == typeof(int) && isNumeric)
                    {
                        return $"{col.ColumnName} = {numericValue}";
                    }
                    else if (col.DataType == typeof(DateTime) && DateTime.TryParse(searchValue, out DateTime dateValue))
                    {
                        return $"{col.ColumnName} = #{dateValue:yyyy-MM-dd}#"; // Убедитесь в правильности формата
                    }
                    else
                    {
                        return "1=0"; // Игнорируем неподходящие столбцы
                    }
                }));


                // Применяем фильтр к DataTable
                table.DefaultView.RowFilter = filter;

                if (table.DefaultView.Count == 0)
                {
                    MessageBox.Show("Записи, соответствующие поисковому запросу, не найдены.", "Результат поиска");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении поиска: {ex.Message}", "Ошибка");
            }
        }

        private bool isLogout = false;

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Устанавливаем флаг выхода
            isLogout = true;

            // Создаем экземпляр формы авторизации
            LoginForm loginForm = new LoginForm();

            // Показываем форму авторизации
            loginForm.Show();

            // Скрываем текущую форму MainForm
            this.Hide();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Проверяем, закрывается ли форма через кнопку "Выход" или крестик
            if (!isLogout)
            {
                // Если форма закрывается через крестик, завершаем процесс приложения
                Application.Exit();
            }
        }

 
        private string CheckRelatedRecords(int id, string tableName)
        {
            string relatedInfo = "";
            try
            {
                // Проверяем связанные таблицы
                var relatedTables = new (string table, string column)[]
                {
            ("Orders", "CustomerID"),
            ("OrderItems", "OrderID"),
            ("OrderIssues", "OrderID"),
            ("Payments", "PaymentID"),
            ("Delivery", "PickupPointID"),
            ("Administrators", "PickupPointID")
                };

                foreach (var (relatedTable, relatedColumn) in relatedTables)
                {
                    string query = $"SELECT COUNT(*) FROM {relatedTable} WHERE {relatedColumn} = @id";
                    using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Если найдены связанные записи, добавляем информацию в строку relatedInfo
                        if (count > 0)
                        {
                            relatedInfo += $"- Таблица '{relatedTable}': {count} связанных записей\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки связанных записей: {ex.Message}", "Ошибка");
            }

            return relatedInfo;
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу перед обновлением.", "Ошибка");
                return;
            }

            // Получаем название текущей выбранной таблицы
            string tableName = SwitchingTablesBox.SelectedItem.ToString();

            // Загружаем данные из выбранной таблицы
            LoadData(tableName);

            //MessageBox.Show("Данные таблицы успешно обновлены.", "Обновление");
        }
        private void LoadPickupPoints()
        {
            try
            {
                db.openConnection();
                string query = "SELECT Address FROM PickupPoints"; // Запрос для получения всех адресов
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
                DataTable pickupPointsTable = new DataTable();
                adapter.Fill(pickupPointsTable);

                cmbPickupPoints.Items.Clear(); // Очистить старые элементы
                cmbPickupPoints.Items.Add("Выберите пункт"); // Добавляем пустой пункт
                foreach (DataRow row in pickupPointsTable.Rows)
                {
                    string address = row["Address"].ToString();
                    cmbPickupPoints.Items.Add(address); // Добавляем адрес в ComboBox
                }

                cmbPickupPoints.SelectedIndex = 0; // По умолчанию выбираем первый элемент (Выберите пункт)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки адресов: {ex.Message}", "Ошибка");
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

                string query = "SELECT StatusDescription FROM OrderStatus"; // Запрос на получение всех статусов
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
                DataTable statusTable = new DataTable();
                adapter.Fill(statusTable);

                cmbStatusOrders.Items.Clear(); // Очищаем старые данные
                cmbStatusOrders.Items.Add("Выберите статус"); // Добавляем пункт по умолчанию

                foreach (DataRow row in statusTable.Rows)
                {
                    cmbStatusOrders.Items.Add(row["StatusDescription"].ToString()); // Добавляем статусы
                }

                cmbStatusOrders.SelectedIndex = 0; // Устанавливаем пункт по умолчанию
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }


        private void cmbPickupPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAddress = cmbPickupPoints.SelectedItem?.ToString();
            string selectedStatus = cmbStatusOrders.SelectedItem?.ToString();

            // Если оба фильтра сброшены, показываем все заказы
            if ((selectedAddress == "Выберите пункт" || string.IsNullOrEmpty(selectedAddress)) &&
                (selectedStatus == "Выберите статус" || string.IsNullOrEmpty(selectedStatus)))
            {
                LoadData(SwitchingTablesBox.SelectedItem.ToString());
                return;
            }

            try
            {
                db.openConnection();

                // Базовый запрос для фильтрации
                string query = "SELECT * FROM Orders WHERE 1=1";

                // Фильтр по пункту выдачи
                if (!string.IsNullOrEmpty(selectedAddress) && selectedAddress != "Выберите пункт")
                {
                    query += " AND PickupPointID IN (SELECT PickupPointID FROM PickupPoints WHERE Address = @address)";
                }

                // Фильтр по статусу
                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Выберите статус")
                {
                    query += " AND Status = (SELECT StatusID FROM OrderStatus WHERE StatusDescription = @status)";
                }

                query += " ORDER BY OrderID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());

                if (!string.IsNullOrEmpty(selectedAddress) && selectedAddress != "Выберите пункт")
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@address", selectedAddress);
                }

                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Выберите статус")
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);
                }

                DataTable ordersTable = new DataTable();
                adapter.Fill(ordersTable);

                // Отображаем данные в DataGridView
                dataGridViewMain.DataSource = ordersTable;
                dataGridViewMain.AutoResizeColumns(); // Автоматическое изменение размера колонок
                ApplySorting(); // Применяем сохраненную сортировку

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных заказов: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }


        private void cmbStatusOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAddress = cmbPickupPoints.SelectedItem?.ToString();
            string selectedStatus = cmbStatusOrders.SelectedItem?.ToString();

            // Если оба фильтра сброшены, показываем все заказы
            if ((selectedAddress == "Выберите пункт" || string.IsNullOrEmpty(selectedAddress)) &&
                (selectedStatus == "Выберите статус" || string.IsNullOrEmpty(selectedStatus)))
            {
                LoadData(SwitchingTablesBox.SelectedItem.ToString());
                return;
            }

            try
            {
                db.openConnection();

                // Базовый запрос для фильтрации
                string query = "SELECT * FROM Orders WHERE 1=1";

                // Фильтр по пункту выдачи
                if (!string.IsNullOrEmpty(selectedAddress) && selectedAddress != "Выберите пункт")
                {
                    query += " AND PickupPointID IN (SELECT PickupPointID FROM PickupPoints WHERE Address = @address)";
                }

                // Фильтр по статусу
                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Выберите статус")
                {
                    query += " AND Status = (SELECT StatusID FROM OrderStatus WHERE StatusDescription = @status)";
                }

                query += " ORDER BY OrderID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());

                if (!string.IsNullOrEmpty(selectedAddress) && selectedAddress != "Выберите пункт")
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@address", selectedAddress);
                }

                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Выберите статус")
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@status", selectedStatus);
                }

                DataTable ordersTable = new DataTable();
                adapter.Fill(ordersTable);

                // Отображаем данные в DataGridView
                dataGridViewMain.DataSource = ordersTable;
                dataGridViewMain.AutoResizeColumns(); // Автоматическое изменение размера колонок
                ApplySorting(); // Применяем сохраненную сортировку

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных заказов: {ex.Message}", "Ошибка");
            }
            finally
            {
                db.closeConnection();
            }
        }
        private void PopulateSortColumns()
        {
            cmbSortTable.Items.Clear(); // Очистить предыдущие элементы

            if (dataGridViewMain.DataSource is DataTable currentTable) // Проверить, что источник данных — DataTable
            {
                foreach (DataColumn column in currentTable.Columns)
                {
                    cmbSortTable.Items.Add(column.ColumnName); // Добавить имя каждого столбца
                }
            }

            if (cmbSortTable.Items.Count > 0)
            {
                cmbSortTable.SelectedIndex = 0; // Установить первый элемент по умолчанию
            }
        }

        private void cmbSortTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSortTable.SelectedItem != null && dataGridViewMain.DataSource is DataTable currentTable)
            {
                string selectedColumn = cmbSortTable.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(selectedColumn))
                {
                    currentTable.DefaultView.Sort = $"{selectedColumn} ASC"; // Сортировка по возрастанию
                    currentTable = currentTable.DefaultView.ToTable(); // Применить сортировку
                    dataGridViewMain.DataSource = currentTable; // Обновить отображение в DataGridView
                }
            }
            if (cmbSortTable.SelectedItem != null)
            {
                currentSortColumn = cmbSortTable.SelectedItem.ToString(); // Сохраняем выбранный столбец
                ApplySorting(); // Применяем сортировку
            }
        }

 

        private void SwitchingTablesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SwitchingTablesBox.SelectedItem != null)
            {
                string selectedTable = SwitchingTablesBox.SelectedItem.ToString();
                LoadData(selectedTable);
            }
            // Обновляем видимость фильтров
            UpdateFilterVisibility();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme(this);

        }
    }

    // Класс Prompt
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                Text = caption
            };

            Label textLabel = new Label() { Left = 5, Top = 5, Text = text, Width = 370 };
            TextBox textBox = new TextBox() { Left = 5, Top = 30, Width = 370 };
            Button confirmation = new Button() { Text = "OK", Left = 285, Top = 60, Width = 90 };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}
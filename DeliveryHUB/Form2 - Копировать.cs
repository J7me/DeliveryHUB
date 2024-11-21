using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
 

namespace DeliveryHUB
{
    public partial class MainForm : Form
    {
        private BD db = new BD(); // Database connection instance

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData(); // Load data when the form loads
        }

        private void LoadData()
        {
            db.openConnection();
            string query = "SELECT * FROM Employees"; // Change table name as needed

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridViewMain.DataSource = table;
            db.closeConnection();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Введите имя:", "Добавить запись");
            string position = Prompt.ShowDialog("Введите должность:", "Добавить запись");

            db.openConnection();
            string query = "INSERT INTO Employees (FirstName, PositionID) VALUES (@name, @position)";
            using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@position", position);
                command.ExecuteNonQuery();
            }
            db.closeConnection();

            LoadData();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewMain.SelectedRows[0].Cells[0].Value);
                string newName = Prompt.ShowDialog("Введите новое имя:", "Редактировать запись");
                string newPosition = Prompt.ShowDialog("Введите новую должность:", "Редактировать запись");

                db.openConnection();
                string query = "UPDATE Employees SET FirstName = @name, PositionID = @position WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    command.Parameters.AddWithValue("@name", newName);
                    command.Parameters.AddWithValue("@position", newPosition);
                    command.Parameters.AddWithValue("@EmployeeID", id);
                    command.ExecuteNonQuery();
                }
                db.closeConnection();

                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.", "Ошибка");
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewMain.SelectedRows[0].Cells[0].Value);

                db.openConnection();
                string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlCommand command = new SqlCommand(query, db.GetSqlConnection()))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);
                    command.ExecuteNonQuery();
                }
                db.closeConnection();

                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.", "Ошибка");
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchTerm = Prompt.ShowDialog("Введите текст для поиска:", "Поиск");

            db.openConnection();
            string query = "SELECT * FROM Employees WHERE FirstName LIKE @searchTerm";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
            adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridViewMain.DataSource = table;
            db.closeConnection();
        }

        private void записиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    // Helper class for input dialogs
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = caption
            };

            Label textLabel = new Label() { Left = 10, Top = 10, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 250 };
            Button confirmation = new Button() { Text = "OK", Left = 170, Top = 60, Width = 90 };

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

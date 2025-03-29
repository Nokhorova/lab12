using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCurs
{
    public partial class AddDocumentForClient : Form
    {
        DataBase database = new DataBase();
        public AddDocumentForClient()
        {
            InitializeComponent();
            FillClientsComboBox();
        }

        // Метод для заполнения comboBox1 всеми клиентами из базы данных
        private void FillClientsComboBox()
        {
            // Очищаем ComboBox перед заполнением
            comboBox1.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=AcerNitro5;Initial Catalog=Hotel_Curs;Integrated Security=True"))
                {
                    string query = "SELECT клиента_id, фамилия, имя, отчество FROM Клиенты";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int clientId = (int)reader["клиента_id"];
                        string lastName = reader["фамилия"].ToString();
                        string firstName = reader["имя"].ToString();
                        string patronymic = reader["отчество"].ToString();

                        // Проверяем, есть ли у клиента документы
                        bool hasDocuments = CheckClientDocuments(clientId);

                        // Формируем строку для отображения в ComboBox
                        string clientInfo = $" - {lastName} {firstName} {patronymic} {(hasDocuments ? "- Есть документы" : "- Нет документов")}";

                        // Добавляем информацию о клиенте в ComboBox
                        comboBox1.Items.Add(new KeyValuePair<int, string>(clientId, clientInfo));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке списка клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для обновления данных на форме при выборе клиента из comboBox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedClient = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            int clientId = selectedClient.Key;

            // Проверяем наличие документов у выбранного клиента
            bool hasDocuments = CheckClientDocuments(clientId);

            if (hasDocuments)
            {
                // Если у клиента есть документы, заполняем поля данными из базы данных
                FillDocumentFields(clientId);
            }
            else
            {
                // Если у клиента нет документов, оставляем поля пустыми
                ClearDocumentFields();
            }
        }

        // Метод для проверки наличия документов у клиента
        private bool CheckClientDocuments(int clientId)
        {
            bool hasDocuments = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=AcerNitro5;Initial Catalog=Hotel_Curs;Integrated Security=True"))
                {
                    string query = "SELECT COUNT(*) FROM Документы WHERE владельца_id = @ClientId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        connection.Open();

                        int documentCount = (int)command.ExecuteScalar();

                        if (documentCount > 0)
                        {
                            hasDocuments = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при проверке наличия документов у клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasDocuments;
        }

        // Метод для заполнения полей документов данными из базы данных
        private void FillDocumentFields(int clientId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=AcerNitro5;Initial Catalog=Hotel_Curs;Integrated Security=True"))
                {
                    string query = "SELECT тип_документа, номер_документа, дата_выдачи FROM Документы WHERE владельца_id = @ClientId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string documentType = reader["тип_документа"].ToString();
                        comboBox2.SelectedItem = documentType;
                        maskedTextBox1.Text = reader["номер_документа"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["дата_выдачи"]);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных о документах: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Метод для очистки полей документов
        private void ClearDocumentFields()
        {
            comboBox2.SelectedIndex = -1;
            maskedTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;
        }

        private void save_document_btn_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedClient = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            int clientId = selectedClient.Key;

            string documentType = comboBox2.SelectedItem.ToString();
            string documentNumber = maskedTextBox1.Text;
            DateTime documentIssueDate = dateTimePicker1.Value;

            // Здесь выполняется сохранение данных о документе в базу данных
            // В зависимости от выбора пользователя, либо добавляются новые данные, либо обновляются существующие
            if (string.IsNullOrEmpty(documentType) || string.IsNullOrEmpty(documentNumber))
            {
                MessageBox.Show("Заполните все поля документа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Проверяем, есть ли у клиента уже документы
                    bool hasDocuments = CheckClientDocuments(clientId);

                    string query;
                    if (hasDocuments)
                    {
                        // Если у клиента уже есть документы, обновляем существующие
                        query = "UPDATE Документы SET тип_документа = @DocumentType, номер_документа = @DocumentNumber, дата_выдачи = @IssueDate WHERE владельца_id = @ClientId";
                    }
                    else
                    {
                        // Если у клиента нет документов, добавляем новые
                        query = "INSERT INTO Документы (тип_документа, номер_документа, дата_выдачи, владельца_id) VALUES (@DocumentType, @DocumentNumber, @IssueDate, @ClientId)";
                    }

                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@DocumentType", documentType);
                    command.Parameters.AddWithValue("@DocumentNumber", documentNumber);
                    command.Parameters.AddWithValue("@IssueDate", documentIssueDate);
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();
                    database.closeConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные о документе успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearDocumentFields(); // Очищаем поля после сохранения
                    }
                    else
                    {
                        MessageBox.Show("Не удалось сохранить данные о документе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении данных о документе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

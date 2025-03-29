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
using static HotelCurs.AddBooking;

namespace HotelCurs
{
    public partial class AddBooking : Form
    {
        DataBase database = new DataBase();
        public AddBooking()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            // Загрузка данных для ComboBox из таблицы "Номера"
            string queryRooms = "SELECT номера_id, номер_комнаты FROM Номера WHERE доступность = 'true'";
            FillComboBox(queryRooms, comboBox7);

            // Загрузка данных для ComboBox из таблицы "Тарифы"
            string queryTariffs = "SELECT тариф_id, наименование FROM Тарифы";
            FillComboBox(queryTariffs, comboBox6);
        }

        private void FillComboBox(string query, ComboBox comboBox)
        {
            database.openConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                comboBox.DisplayMember = "Text";
                comboBox.ValueMember = "Value";

                foreach (DataRow row in table.Rows)
                {
                    comboBox.Items.Add(new { Text = row[1], Value = row[0] });
                }
            }
            database.closeConnection();
        }

        private void add_booking_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Добавление нового клиента
                int clientId = FindOrCreateClient(textBox2.Text, textBox1.Text, textBox3.Text, maskedTextBox1.Text, textBox4.Text);

                // Создание бронирования
                int days = Convert.ToInt32(textBox6.Text);
                DateTime checkInDateTime = dateTimePicker1.Value.Date.Add(TimeSpan.Parse((string)comboBox1.SelectedItem));
                DateTime checkOutDateTime = dateTimePicker2.Value.Date.Add(TimeSpan.Parse((string)comboBox2.SelectedItem));

                int adultsCount = int.Parse(comboBox3.SelectedItem.ToString());
                int childrenCount = int.Parse(comboBox4.SelectedItem.ToString());
                int infantsCount = int.Parse(comboBox5.SelectedItem.ToString());

                int roomId = GetRoomIdByRoomNumber(comboBox7.Text);
                UpdateRoomAvailability(roomId);

                int tariffId = GetTariffIdByTariffName(comboBox6.Text);

                decimal totalCost = CalculateTotalCost(days, tariffId);

                // Вставка новой записи в таблицу "Заказ"
                AddNewBooking(clientId, checkInDateTime, days, checkOutDateTime, roomId, tariffId, textBox5.Text, totalCost, adultsCount, childrenCount, infantsCount);

                label11.Text = totalCost.ToString();

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                // Отображение сообщения об ошибке при сохранении данных
                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private int FindOrCreateClient(string firstName, string lastName, string patronymic, string phoneNumber, string email)
        {

            int clientId = GetClientIdByDetails(firstName, lastName, patronymic, phoneNumber, email);
            try
            {
                if (clientId == -1)
                {
                    // Если клиент не найден, создаем нового
                    clientId = AddNewClient(firstName, lastName, patronymic, phoneNumber, email);
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в AddBooking 'FindOrCreateClient': " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return clientId;
        }

        private int GetClientIdByDetails(string firstName, string lastName, string patronymic, string phoneNumber, string email)
        {
            int clientId = -1;

            string query = "SELECT клиента_id FROM Клиенты WHERE имя = @FirstName AND фамилия = @LastName AND отчество = @Patronymic AND номер_телефона = @PhoneNumber AND почта = @Email";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Patronymic", patronymic);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);

                database.openConnection();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    clientId = Convert.ToInt32(result);
                }

                database.closeConnection();
            }

            return clientId;
        }
        // работа с номером комнаты
        private int GetRoomIdByRoomNumber(string roomNumber)
        {
            int roomId = -1;
            string query = "SELECT номера_id FROM Номера WHERE номер_комнаты = @RoomNumber";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                database.openConnection();
                roomId = Convert.ToInt32(command.ExecuteScalar());
                database.closeConnection();
            }

            return roomId;
        }

        private void UpdateRoomAvailability(int roomNumber)
        {
            // SQL-запрос для обновления статуса доступности выбранного номера
            string query = "UPDATE Номера SET доступность = @Availability WHERE номер_комнаты = @RoomNumber";

            // Устанавливаем значение параметров
            bool isAvailable = false; // Занятый
            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                command.Parameters.AddWithValue("@Availability", isAvailable);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                // Открываем соединение и выполняем запрос
                database.openConnection();
                command.ExecuteNonQuery();
                database.closeConnection();
            }
        }
        // конец тут

        private int GetTariffIdByTariffName(string tariffName)
        {
            int tariffId = -1;
            string query = "SELECT тариф_id FROM Тарифы WHERE наименование = @TariffName";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@TariffName", tariffName);

                database.openConnection();
                tariffId = Convert.ToInt32(command.ExecuteScalar());
                database.closeConnection();
            }

            return tariffId;
        }

        private int AddNewClient(string firstName, string lastName, string patronymic, string phoneNumber, string email)
        {
            int clientId = -1;

            string query = "INSERT INTO Клиенты (фамилия, имя, отчество, номер_телефона, почта) VALUES (@LastName, @FirstName, @Patronymic, @PhoneNumber, @Email); SELECT SCOPE_IDENTITY();";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@Patronymic", patronymic);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);

                database.openConnection();
                clientId = Convert.ToInt32(command.ExecuteScalar());
                database.closeConnection();
            }

            return clientId;
        }

        private decimal CalculateTotalCost(int days, int tariffId)
        {
            decimal pricePerDay = 0;
            decimal totalCost = 0;

            string query = "SELECT цена FROM Тарифы WHERE тариф_id = @TariffId";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@TariffId", tariffId);

                database.openConnection();
                pricePerDay = Convert.ToDecimal(command.ExecuteScalar());
                database.closeConnection();
            }

            totalCost = (pricePerDay * days) + 500;
            return totalCost;
        }

        private void AddNewBooking(int clientId, DateTime checkInDate, int days, DateTime checkOutDate, int roomId, int tariffId, string comment, decimal totalCost, int adultsCount, int childrenCount, int infantsCount)
        {
            string query = "INSERT INTO Заказ (сотрудник_id, клиента_id, номера_id, дата_заезда, количество_дней, дата_выезда, тариф_id, комментарий, общая_стоимость, количество_взрослых, количество_детей, количество_грудных_детей) VALUES (@EmployeeId, @ClientId, @RoomId, @CheckInDate, @Days, @CheckOutDate, @TariffId, @Comment, @TotalCost, @AdultsCount, @ChildrenCount, @InfantsCount);";

            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@EmployeeId", 1); // Идентификатор сотрудника, если есть
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.Parameters.AddWithValue("@RoomId", roomId);
                command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                command.Parameters.AddWithValue("@Days", days);
                command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                command.Parameters.AddWithValue("@TariffId", tariffId);
                command.Parameters.AddWithValue("@Comment", comment);
                command.Parameters.AddWithValue("@TotalCost", totalCost);
                command.Parameters.AddWithValue("@AdultsCount", adultsCount);
                command.Parameters.AddWithValue("@ChildrenCount", childrenCount);
                command.Parameters.AddWithValue("@InfantsCount", infantsCount);

                database.openConnection();
                command.ExecuteNonQuery();
                database.closeConnection();
            }
        }
        
        // Вычисляемые поля выезда и кол-во дней
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            UpdateCheckOutDate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            UpdateNumberOfDays();
        }

        private void UpdateCheckOutDate()
        {
            if (int.TryParse(textBox6.Text, out int numberOfDays) && dateTimePicker1.Value != null)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(numberOfDays);
            }
        }

        private void UpdateNumberOfDays()
        {
            TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
            textBox6.Text = difference.Days.ToString();
        }
        // конец тут

        //обновление общей стоимости
        private void UpdateTotalCost()
        {
            int days = int.Parse(textBox6.Text);
            int tariffId = GetTariffIdByTariffName(comboBox6.Text);

            decimal totalCost = CalculateTotalCost(days, tariffId);

            label11.Text = totalCost.ToString() + " руб";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }
        //конец тут

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string userInput = textBox1.Text;

                // Проверяем, является ли текст в textBox1 частью существующих подсказок
                string[] existingSuggestions = textBox1.AutoCompleteCustomSource.Cast<string>().ToArray();
                if (!existingSuggestions.Any(suggestion => suggestion.StartsWith(userInput)))
                {
                    // Если введенный текст не соответствует существующим подсказкам, 
                    // очищаем и обновляем подсказки с помощью метода GetClientLastNameSuggestions
                    UpdateLastNameSuggestions(userInput);
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в AddBooking 'textBox2_TextChanged': " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateLastNameSuggestions(string userInput)
        {
            try
            {
                List<string> suggestions = GetClientLastNameSuggestions(userInput);

                textBox1.AutoCompleteCustomSource.Clear();
                textBox1.AutoCompleteCustomSource.AddRange(suggestions.ToArray());
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в AddBooking 'UpdateLastNameSuggestions': " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private List<string> GetClientLastNameSuggestions(string userInput)
        {
            List<string> suggestions = new List<string>();
            database.getConnection();
            try
            {
                {
                    string query = "SELECT DISTINCT Фамилия FROM Клиенты WHERE Фамилия LIKE @UserInput + '%'";
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@UserInput", userInput);

                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        suggestions.Add(reader["Фамилия"].ToString());
                    }

                    database.closeConnection();
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в AddBooking 'GetClientLastNameSuggestions': " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return suggestions;
        }

        private void FillOtherFields(string selectedLastName)
        {
            database.getConnection();
            {
                string query = "SELECT * FROM Клиенты WHERE Фамилия = @LastName";
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@LastName", selectedLastName);

                database.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox2.Text = reader["Имя"].ToString();
                    textBox3.Text = reader["Отчество"].ToString();
                    textBox4.Text = reader["Почта"].ToString();
                    maskedTextBox1.Text = reader["Номер_телефона"].ToString();
                }

                database.closeConnection();
                reader.Close();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string selectedLastName = textBox1.Text;
                FillOtherFields(selectedLastName);
            }
        }

        private void AddBooking_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}

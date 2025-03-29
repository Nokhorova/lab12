using System;
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
    public partial class ChangeBooking : Form
    {
        DataBase database = new DataBase();
        public int OrderId { get; set; }
        public ChangeBooking()
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
            }

            return tariffId;
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
            }

            totalCost = (pricePerDay * days) + 500;
            return totalCost;
        }
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

        //работа с номером комнаты
        private string GetPreviousRoomNumber(int OrderId)
        {
            string previousRoomNumber = "";

            try
            {
                string query = "SELECT Номера.номер_комнаты FROM Заказ INNER JOIN Номера ON Заказ.номера_id = Номера.номера_id WHERE заказа_id = @OrderId";

                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", OrderId);
                    database.openConnection();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        previousRoomNumber = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении предыдущего номера комнаты: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }

            return previousRoomNumber;
        }
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
            }

            return roomId;
        }
        private void UpdateRoomAvailability(string currentRoomNumber, string previousRoomNumber)
        {
            // SQL-запрос для обновления статуса доступности выбранного номера
            string updateCurrentRoomQuery = "UPDATE Номера SET доступность = @Availability WHERE номер_комнаты = @RoomNumber";
            string updatePreviousRoomQuery = "UPDATE Номера SET доступность = @Availability WHERE номер_комнаты = @RoomNumber";

            // Устанавливаем значение параметров
            bool isAvailable = true; // Свободен
            using (SqlCommand command = new SqlCommand(updateCurrentRoomQuery, database.getConnection()))
            {
                command.Parameters.AddWithValue("@Availability", !isAvailable);
                command.Parameters.AddWithValue("@RoomNumber", currentRoomNumber);

                // Открываем соединение и выполняем запрос
                database.openConnection();
                command.ExecuteNonQuery();
                database.closeConnection();
            }

            if (!string.IsNullOrEmpty(previousRoomNumber))
            {
                using (SqlCommand command = new SqlCommand(updatePreviousRoomQuery, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@Availability", isAvailable);
                    command.Parameters.AddWithValue("@RoomNumber", previousRoomNumber);

                    // Открываем соединение и выполняем запрос
                    database.openConnection();
                    command.ExecuteNonQuery();
                    database.closeConnection();
                }
            }
        }
        //конец тут

        //подсказки при вводе фамилии
        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void UpdateLastNameSuggestions(string userInput)
        {
            List<string> suggestions = GetClientLastNameSuggestions(userInput);

            textBox1.AutoCompleteCustomSource.Clear();
            textBox1.AutoCompleteCustomSource.AddRange(suggestions.ToArray());
        }

        private List<string> GetClientLastNameSuggestions(string userInput)
        {
            List<string> suggestions = new List<string>();
            database.getConnection();
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

                reader.Close();
            }

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

                reader.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string selectedLastName = textBox1.Text;
                FillOtherFields(selectedLastName);
            }
        }
        //конец тут

        private void ChangeBooking_Load(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void save_booking_btn_Click(object sender, EventArgs e)
        {
            SaveBookingChanges(OrderId);
        }
        public void SaveBookingChanges(int OrderId)
        {
            try
            {
                // Получение обновленных данных из формы ChangeBooking
                string surname = textBox1.Text;
                string name = textBox2.Text;
                string patronymic = textBox3.Text;
                string phoneNumber = maskedTextBox1.Text;
                string email = textBox4.Text;

                // Преобразование даты заезда и выезда
                DateTime checkInDate = dateTimePicker1.Value.Date;
                DateTime checkOutDate = dateTimePicker2.Value.Date;
                TimeSpan checkInTime = TimeSpan.Parse(comboBox1.Text);
                TimeSpan checkOutTime = TimeSpan.Parse(comboBox2.Text);
                DateTime checkInDateTime = checkInDate.Add(checkInTime);
                DateTime checkOutDateTime = checkOutDate.Add(checkOutTime);

                int numberOfDays = int.Parse(textBox6.Text);
                int numberOfAdults = int.Parse(comboBox3.Text);
                int numberOfChildren = int.Parse(comboBox4.Text);
                int numberOfInfants = int.Parse(comboBox5.Text);

                int tariffName = GetTariffIdByTariffName(comboBox6.Text);

                string currentRoomNumber = comboBox7.Text;
                string previousRoomNumber = GetPreviousRoomNumber(OrderId);
                UpdateRoomAvailability(currentRoomNumber, previousRoomNumber);

                string comment = textBox5.Text;
                decimal totalPrice = CalculateTotalCost(numberOfDays, tariffName);

                // Проверка существования клиента в базе данных
                int clientId;
                using (SqlCommand command = new SqlCommand("SELECT клиента_id FROM Клиенты WHERE фамилия = @Surname AND имя = @Name AND отчество = @Patronymic AND номер_телефона = @PhoneNumber", database.getConnection()))
                {
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Patronymic", patronymic);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    database.openConnection();
                    object result = command.ExecuteScalar();
                    database.closeConnection();

                    if (result != null)
                    {
                        clientId = (int)result;
                    }
                    else
                    {
                        // Если клиент не найден, создаем нового клиента
                        using (SqlCommand insertCommand = new SqlCommand("INSERT INTO Клиенты (фамилия, имя, отчество, номер_телефона, почта) VALUES (@Surname, @Name, @Patronymic, @PhoneNumber, @Email); SELECT SCOPE_IDENTITY();", database.getConnection()))
                        {
                            insertCommand.Parameters.AddWithValue("@Surname", surname);
                            insertCommand.Parameters.AddWithValue("@Name", name);
                            insertCommand.Parameters.AddWithValue("@Patronymic", patronymic);
                            insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            insertCommand.Parameters.AddWithValue("@Email", email);

                            database.openConnection();
                            clientId = Convert.ToInt32(insertCommand.ExecuteScalar());
                            database.closeConnection();
                        }
                    }
                }

                // Обновление информации о бронировании
                using (SqlCommand updateCommand = new SqlCommand("UPDATE Заказ SET клиента_id = @ClientId, дата_заезда = @CheckInDateTime, количество_дней = @NumberOfDays, дата_выезда = @CheckOutDateTime, количество_взрослых = @NumberOfAdults, количество_детей = @NumberOfChildren, количество_грудных_детей = @NumberOfInfants, тариф_id = @TariffId, номера_id = @RoomId, комментарий = @Comment, общая_стоимость = @TotalPrice WHERE заказа_id = @OrderId", database.getConnection()))
                {
                    updateCommand.Parameters.AddWithValue("@ClientId", clientId);
                    updateCommand.Parameters.AddWithValue("@CheckInDateTime", checkInDateTime);
                    updateCommand.Parameters.AddWithValue("@NumberOfDays", numberOfDays);
                    updateCommand.Parameters.AddWithValue("@CheckOutDateTime", checkOutDateTime);
                    updateCommand.Parameters.AddWithValue("@NumberOfAdults", numberOfAdults);
                    updateCommand.Parameters.AddWithValue("@NumberOfChildren", numberOfChildren);
                    updateCommand.Parameters.AddWithValue("@NumberOfInfants", numberOfInfants);
                    updateCommand.Parameters.AddWithValue("@TariffId", tariffName); // Предполагается, что у вас есть метод для получения идентификатора тарифа по его наименованию
                    updateCommand.Parameters.AddWithValue("@RoomId", GetRoomIdByRoomNumber(currentRoomNumber)); // Предполагается, что у вас есть метод для получения идентификатора номера по его номеру
                    updateCommand.Parameters.AddWithValue("@Comment", comment);
                    updateCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    updateCommand.Parameters.AddWithValue("@OrderId", OrderId);

                    database.openConnection();
                    updateCommand.ExecuteNonQuery();
                    database.closeConnection();
                }
                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                // Отображение сообщения об ошибке при сохранении данных
                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

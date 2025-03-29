using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelCurs
{
    public partial class Main : Form
    {
        DataBase database = new DataBase();
        public Main()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            booking_table(tb_search.Text);
            rooms_table(textBox1.Text);
            clients_table(textBox2.Text);
            employees_table(textBox3.Text);
            documents_table(textBox4.Text);
            tarifs_table(textBox5.Text);
        }
        
        // БРОНИРОВАНИЕ
        private void booking_table(string searchKeyword)
        {
            string query_booking = "SELECT Заказ.заказа_id AS [Id заказа], " +
                                    "CONCAT(Сотрудники.фамилия, ' ', Сотрудники.имя, ' ', Сотрудники.отчество) AS Сотрудник, " +
                                    "CONCAT(Клиенты.фамилия, ' ', Клиенты.имя, ' ', Клиенты.отчество) AS Клиент, " +
                                    "Номера.номер_комнаты AS [Номер комнаты], " +
                                    "Заказ.дата_заезда AS Заезд, " +
                                    "Заказ.количество_дней AS Дней, " +
                                    "Заказ.дата_выезда AS Выезд, " +
                                    "Заказ.количество_взрослых AS Взрослых, " +
                                    "Заказ.количество_детей AS Детей, " +
                                    "Заказ.количество_грудных_детей AS [Грудных детей], " +
                                    "Тарифы.наименование AS Тариф, " +
                                    "Заказ.комментарий AS Комментарий, " +
                                    "Заказ.общая_стоимость AS [Общая стоимость]" +
                                    "FROM Заказ " +
                                    "LEFT JOIN Сотрудники ON Заказ.сотрудник_id = Сотрудники.сотрудника_id " +
                                    "LEFT JOIN Клиенты ON Заказ.клиента_id = Клиенты.клиента_id " +
                                    "LEFT JOIN Номера ON Заказ.номера_id = Номера.номера_id " +
                                    "LEFT JOIN Тарифы ON Заказ.тариф_id = Тарифы.тариф_id " +
                                    "WHERE Заказ.заказа_id LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Сотрудники.фамилия LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Сотрудники.имя LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Сотрудники.отчество LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Клиенты.фамилия LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Клиенты.имя LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Клиенты.отчество LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Номера.номер_комнаты LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Тарифы.наименование LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Заказ.комментарий LIKE '%' + @SearchKeyword + '%' OR " +
                                    "Заказ.общая_стоимость LIKE '%' + @SearchKeyword + '%'";
            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_booking, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                database.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = "SELECT Заказ.заказа_id AS [Id заказа], " +
                            "CONCAT(Сотрудники.фамилия, ' ', Сотрудники.имя, ' ', Сотрудники.отчество) AS Сотрудник, " +
                            "CONCAT(Клиенты.фамилия, ' ', Клиенты.имя, ' ', Клиенты.отчество) AS Клиент, " +
                            "Номера.номер_комнаты AS [Номер комнаты], " +
                            "Заказ.дата_заезда AS Заезд, " +
                            "Заказ.количество_дней AS Дней, " +
                            "Заказ.дата_выезда AS Выезд, " +
                            "Заказ.количество_взрослых AS Взрослых, " +
                            "Заказ.количество_детей AS Детей, " +
                            "Заказ.количество_грудных_детей AS [Грудных детей], " +
                            "Тарифы.наименование AS Тариф, " +
                            "Заказ.комментарий AS Комментарий, " +
                            "Заказ.общая_стоимость AS [Общая стоимость]" +
                            "FROM Заказ " +
                            "LEFT JOIN Сотрудники ON Заказ.сотрудник_id = Сотрудники.сотрудника_id " +
                            "LEFT JOIN Клиенты ON Заказ.клиента_id = Клиенты.клиента_id " +
                            "LEFT JOIN Номера ON Заказ.номера_id = Номера.номера_id " +
                            "LEFT JOIN Тарифы ON Заказ.тариф_id = Тарифы.тариф_id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            booking_table(tb_search.Text);
        }
        private void addbooking_Click(object sender, EventArgs e)
        {
            AddBooking addbooking = new AddBooking();
            addbooking.Show();
        }
        private void delete_booking_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите снять бронирование?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int orderIdToDelete = GetSelectedOrderIdToDelete(); // Получите ID выбранного заказа для удаления

                        // SQL запрос для удаления заказа
                        string deleteOrderQuery = "DELETE FROM Заказ WHERE заказа_id = @OrderId";

                        // SQL запрос для обновления статуса номера на "свободный"
                        string updateRoomStatusQuery = @"UPDATE Номера
                                                SET доступность = 1
                                                WHERE номера_id IN (
                                                SELECT номера_id 
                                                FROM Заказ 
                                                WHERE заказа_id = @OrderId
                                                )";

                        // Здесь вы должны выполнить запросы к базе данных, используя вашу библиотеку доступа к данным

                        // Запустите транзакцию для атомарного выполнения обоих запросов
                        database.getConnection();
                        {
                            database.openConnection();
                            using (SqlTransaction transaction = database.getConnection().BeginTransaction())
                            {
                                try
                                {
                                    // Удаление заказа
                                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Обновление статуса номера
                                    using (SqlCommand command = new SqlCommand(updateRoomStatusQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Если все успешно, фиксируем транзакцию
                                    transaction.Commit();
                                    MessageBox.Show("Снятие с бронирования прошло успешно.");
                                }
                                catch (Exception ex)
                                {
                                    // Если произошла ошибка, откатываем транзакцию
                                    transaction.Rollback();
                                    MessageBox.Show($"Произошла ошибка при снятии с бронирования: {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при снятии с бронирования: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при снятии с бронирования: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private int GetSelectedOrderIdToDelete()
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку (предполагаем, что первая ячейка в строке содержит ID заказа)
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Получаем значение ID заказа из первой ячейки выбранной строки
                int orderId = Convert.ToInt32(selectedRow.Cells["Id заказа"].Value);

                return orderId;
            }
            else
            {
                throw new Exception("Выберите заказ для удаления.");
            }
        }
        private void edit_booking_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо строка в DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите бронирование для редактирования.");
                    return;
                }

                // Получаем значение "заказа_id" выбранной строки в DataGridView
                int orderId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id заказа"].Value);

                // Выполняем SQL-запрос для получения информации о бронировании по заказу
                string query = @"SELECT Клиенты.фамилия, Клиенты.имя, Клиенты.отчество, 
                                Клиенты.номер_телефона, Клиенты.почта, 
                                Заказ.дата_заезда, Заказ.дата_выезда, 
                                Заказ.количество_дней, Заказ.количество_взрослых, 
                                Заказ.количество_детей, Заказ.количество_грудных_детей, 
                                Тарифы.наименование AS НаименованиеТарифа, 
                                Номера.номер_комнаты, Заказ.комментарий, Заказ.общая_стоимость
                                FROM Заказ 
                                LEFT JOIN Клиенты ON Заказ.клиента_id = Клиенты.клиента_id
                                LEFT JOIN Тарифы ON Заказ.тариф_id = Тарифы.тариф_id
                                LEFT JOIN Номера ON Заказ.номера_id = Номера.номера_id
                                WHERE Заказ.заказа_id = @OrderId";

                ChangeBooking changeBooking = new ChangeBooking();
                changeBooking.OrderId = orderId;

                // Подготавливаем объекты команды для выполнения запроса
                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    database.openConnection();

                    // Выполняем запрос и получаем результаты
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем элементы управления на форме "ChangeBooking" полученными данными
                            changeBooking.textBox1.Text = reader["фамилия"].ToString();
                            changeBooking.textBox2.Text = reader["имя"].ToString();
                            changeBooking.textBox3.Text = reader["отчество"].ToString();
                            changeBooking.maskedTextBox1.Text = reader["номер_телефона"].ToString();
                            changeBooking.textBox4.Text = reader["почта"].ToString();
                            changeBooking.dateTimePicker1.Value = Convert.ToDateTime(reader["дата_заезда"]);

                            changeBooking.dateTimePicker1.Value = ((DateTime)reader["дата_заезда"]).Date;
                            changeBooking.comboBox1.Text = ((DateTime)reader["дата_заезда"]).ToString("HH:mm");

                            changeBooking.textBox6.Text = reader["количество_дней"].ToString();

                            changeBooking.dateTimePicker2.Value = ((DateTime)reader["дата_выезда"]).Date;
                            changeBooking.comboBox2.Text = ((DateTime)reader["дата_выезда"]).ToString("HH:mm");

                            changeBooking.comboBox3.Text = reader["количество_взрослых"].ToString();
                            changeBooking.comboBox4.Text = reader["количество_детей"].ToString();
                            changeBooking.comboBox5.Text = reader["количество_грудных_детей"].ToString();
                            changeBooking.comboBox6.Text = reader["НаименованиеТарифа"].ToString();
                            changeBooking.comboBox7.Text = reader["номер_комнаты"].ToString();
                            changeBooking.textBox5.Text = reader["комментарий"].ToString();
                            changeBooking.label11.Text = reader["общая_стоимость"].ToString() + " руб";
                        }
                    }
                }
                changeBooking.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных о бронировании: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        // БРОНИРОВАНИЯ КОНЕЦ









        // НОМЕРА
        private void rooms_table(string searchKeyword1)
        {
            string query_rooms = @"SELECT 
                            номера_id AS [Id номера], 
                            номер_комнаты AS [Номер комнаты], 
                            вместимость_гостей AS [Вместимость гостей], 
                            CASE 
                                WHEN доступность = 1 THEN 'Свободен' 
                                ELSE 'Занят' 
                            END AS Доступность, 
                            площадь AS [Площадь (кв/м)], 
                            количество_комнат AS [Количество комнат] 
                        FROM Номера 
                        WHERE 
                            номера_id LIKE '%' + @SearchKeyword + '%' OR 
                            номер_комнаты LIKE '%' + @SearchKeyword + '%' OR 
                            вместимость_гостей LIKE '%' + @SearchKeyword + '%' OR 
                            (доступность = 1 AND 'Свободен' LIKE '%' + @SearchKeyword + '%') OR
                            (доступность = 0 AND 'Занят' LIKE '%' + @SearchKeyword + '%') OR 
                            площадь LIKE '%' + @SearchKeyword + '%' OR 
                            количество_комнат LIKE '%' + @SearchKeyword + '%'";

            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_rooms, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword1 + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView2.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            clients_table(textBox2.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            rooms_table(textBox1.Text);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefreshDataGridView1();
        }

        private void RefreshDataGridView1()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = "SELECT номера_id AS [Id номера], номер_комнаты AS [Номер комнаты], вместимость_гостей AS [Вместимость гостей], " +
                           "CASE WHEN доступность = 1 THEN 'Свободен' ELSE 'Занят' END AS Доступность, " +
                           "площадь AS [Площадь (кв/м)], количество_комнат AS [Количество комнат] FROM Номера";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void add_room_btn_Click(object sender, EventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            addRoom.Show();
        }

        private void edit_rooms_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо строка в DataGridView
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите номер для редактирования.");
                    return;
                }

                // Получаем значение "номера_id" выбранной строки в DataGridView
                int orderId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id номера"].Value);

                // Выполняем SQL-запрос для получения информации о номере
                string query = "SELECT номер_комнаты, вместимость_гостей, " +
                           "доступность, " +
                           "площадь, количество_комнат FROM Номера WHERE номера_id = @OrderId";

                ChangeRoom changeRoom = new ChangeRoom();
                changeRoom.OrderId = orderId;

                // Подготавливаем объекты команды для выполнения запроса
                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    database.openConnection();

                    // Выполняем запрос и получаем результаты
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем элементы управления на форме "ChangeRoom" полученными
                            changeRoom.textBox1.Text = reader["номер_комнаты"].ToString();
                            changeRoom.comboBox1.Text = reader["вместимость_гостей"].ToString();
                            changeRoom.comboBox2.Text = reader["количество_комнат"].ToString();
                            changeRoom.textBox3.Text = reader["площадь"].ToString();
                            // Проверяем значение доступности и устанавливаем checkBox1
                            bool availability = Convert.ToBoolean(reader["доступность"]);
                            changeRoom.checkBox1.Checked = availability;
                            // Устанавливаем текст checkBox1 в зависимости от доступности
                            changeRoom.checkBox1.Text += availability ? "" : " (занят)";
                        }
                    }
                }
                changeRoom.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных о номере: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void delete_room_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить номер?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int orderIdToDelete = GetSelectedOrderIdToDelete1(); // Получите ID выбранного заказа для удаления

                        // SQL запрос для удаления номера
                        string deleteOrderQuery = "DELETE FROM Номера WHERE номера_id = @OrderId";

                        // SQL запрос для обновления "номера_id" в таблице "Заказ"
                        string updateBookingRoomIdQuery = "UPDATE Заказ SET номера_id = NULL WHERE номера_id = @OrderId";

                        // Здесь вы должны выполнить запросы к базе данных, используя вашу библиотеку доступа к данным

                        // Запустите транзакцию для атомарного выполнения обоих запросов
                        database.getConnection();
                        {
                            database.openConnection();
                            using (SqlTransaction transaction = database.getConnection().BeginTransaction())
                            {
                                try
                                {
                                    // Удаление номера
                                    using (SqlCommand command = new SqlCommand(updateBookingRoomIdQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Обновление статуса номера
                                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Если все успешно, фиксируем транзакцию
                                    transaction.Commit();
                                    MessageBox.Show("Номер успешно удален.");
                                }
                                catch (Exception ex)
                                {
                                    // Если произошла ошибка, откатываем транзакцию
                                    transaction.Rollback();
                                    MessageBox.Show($"Произошла ошибка при удалении номера: {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении номера: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении номера: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private int GetSelectedOrderIdToDelete1()
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку (предполагаем, что первая ячейка в строке содержит ID номера)
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Получаем значение ID номера из первой ячейки выбранной строки
                int orderId = Convert.ToInt32(selectedRow.Cells["Id номера"].Value);

                return orderId;
            }
            else
            {
                throw new Exception("Выберите номер для удаления.");
            }
        }
        // НОМЕРА КОНЕЦ










        // КЛИЕНТЫ
        private void clients_table(string searchKeyword2)
        {
            string query_clients = @"SELECT клиента_id AS [Id клиента], 
                                фамилия AS Фамилия, 
                                имя AS Имя, 
                                отчество AS Отчество, 
                                адрес AS Адрес, 
                                почта AS Почта, 
                                номер_телефона AS [Номер телефона] 
                         FROM Клиенты 
                         WHERE клиента_id LIKE '%' + @SearchKeyword + '%' OR 
                               фамилия LIKE '%' + @SearchKeyword + '%' OR 
                               имя LIKE '%' + @SearchKeyword + '%' OR 
                               отчество LIKE '%' + @SearchKeyword + '%' OR 
                               адрес LIKE '%' + @SearchKeyword + '%' OR 
                               почта LIKE '%' + @SearchKeyword + '%' OR 
                               номер_телефона LIKE '%' + @SearchKeyword + '%'";
            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_clients, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword2 + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView3.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshDataGridView2();
        }

        private void RefreshDataGridView2()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = "SELECT клиента_id AS [Id клиента], фамилия AS Фамилия, имя AS Имя, отчество AS Отчество, адрес AS Адрес, почта AS Почта, номер_телефона AS [Номер телефона] FROM Клиенты";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView3.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void add_client_btn_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
        }
        private void edit_client_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо строка в DataGridView
                if (dataGridView3.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите клиента для редактирования.");
                    return;
                }

                // Получаем значение "номера_id" выбранной строки в DataGridView
                int orderId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["Id клиента"].Value);

                // Выполняем SQL-запрос для получения информации о клиенте
                string query = "SELECT фамилия, имя, отчество, адрес, почта, номер_телефона FROM Клиенты WHERE клиента_id = @OrderId";

                ChangeClient changeClient = new ChangeClient();
                changeClient.OrderId = orderId;

                // Подготавливаем объекты команды для выполнения запроса
                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    database.openConnection();

                    // Выполняем запрос и получаем результаты
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем элементы управления на форме "ChangeClient" полученными
                            changeClient.textBox1.Text = reader["фамилия"].ToString();
                            changeClient.textBox2.Text = reader["имя"].ToString();
                            changeClient.textBox3.Text = reader["отчество"].ToString();
                            changeClient.textBox4.Text = reader["адрес"].ToString();
                            changeClient.textBox5.Text = reader["почта"].ToString();
                            changeClient.maskedTextBox1.Text = reader["номер_телефона"].ToString();
                        }
                    }
                }
                changeClient.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных о клиенте: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void delete_client_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int orderIdToDelete = GetSelectedOrderIdToDelete2(); // Получите ID выбранного клиента для удаления

                        // SQL запрос для удаления клиента
                        string deleteOrderQuery = "DELETE FROM Клиенты WHERE клиента_id = @OrderId";

                        // SQL запрос для обновления "клиента_id" в таблице "Заказ"
                        string updateBookingClientIdQuery = "UPDATE Заказ SET клиента_id = NULL WHERE клиента_id = @OrderId";

                        // SQL запрос для удаления документов клиента
                        string deleteClientDocuments = "DELETE FROM Документы WHERE владельца_id = @OrderId";

                        // Здесь вы должны выполнить запросы к базе данных, используя вашу библиотеку доступа к данным

                        // Запустите транзакцию для атомарного выполнения обоих запросов
                        database.getConnection();
                        {
                            database.openConnection();
                            using (SqlTransaction transaction = database.getConnection().BeginTransaction())
                            {
                                try
                                {
                                    // Обновление заказа
                                    using (SqlCommand command = new SqlCommand(updateBookingClientIdQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Удаление клиента
                                    using (SqlCommand command = new SqlCommand(deleteClientDocuments, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Удаление документов клиента
                                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Если все успешно, фиксируем транзакцию
                                    transaction.Commit();
                                    MessageBox.Show("Клиент успешно удален.");
                                }
                                catch (Exception ex)
                                {
                                    // Если произошла ошибка, откатываем транзакцию
                                    transaction.Rollback();
                                    MessageBox.Show($"Произошла ошибка при удалении клиента: {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении клиента: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private int GetSelectedOrderIdToDelete2()
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку (предполагаем, что первая ячейка в строке содержит ID клиента)
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                // Получаем значение ID клиента из первой ячейки выбранной строки
                int orderId = Convert.ToInt32(selectedRow.Cells["Id клиента"].Value);

                return orderId;
            }
            else
            {
                throw new Exception("Выберите клиента для удаления.");
            }
        }
        // КЛИЕНТЫ КОНЕЦ


















        // СОТРУДНИКИ
        private void employees_table(string searchKeyword2)
        {
            string query_employees = @"SELECT сотрудника_id AS [Id сотрудника], 
                                        фамилия AS Фамилия, 
                                        имя AS Имя, 
                                        отчество AS Отчество, 
                                        должность AS Должность, 
                                        почта AS Почта, 
                                        номер_телефона AS [Номер телефона] 
                                 FROM Сотрудники 
                                 WHERE сотрудника_id LIKE '%' + @SearchKeyword + '%' OR 
                                       фамилия LIKE '%' + @SearchKeyword + '%' OR 
                                       имя LIKE '%' + @SearchKeyword + '%' OR 
                                       отчество LIKE '%' + @SearchKeyword + '%' OR 
                                       должность LIKE '%' + @SearchKeyword + '%' OR 
                                       почта LIKE '%' + @SearchKeyword + '%' OR 
                                       номер_телефона LIKE '%' + @SearchKeyword + '%'";
            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_employees, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword2 + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView4.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            employees_table(textBox3.Text);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RefreshDataGridView3();
        }

        private void RefreshDataGridView3()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = "SELECT сотрудника_id AS [Id сотрудника], фамилия AS Фамилия, имя AS Имя, отчество AS Отчество, должность AS Должность, почта AS Почта, номер_телефона AS [Номер телефона] FROM Сотрудники";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView4.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        // СОТРУДНИКИ КОНЕЦ
















        // ДОКУМЕНТЫ
        private void documents_table(string searchKeyword3)
        {
            string query_documents = @"SELECT 
                                Документы.документа_id AS [Id документа],
                                Документы.тип_документа AS [Тип документа],
                                SUBSTRING(номер_документа, 1, 4) + ' ' + 
                                SUBSTRING(номер_документа, 5, 1) + ' ' + 
                                SUBSTRING(номер_документа, 6, LEN(номер_документа) - 5) AS [Серия и номер],
                                Документы.дата_выдачи AS [Дата выдачи],
                                Клиенты.фамилия + ' ' + Клиенты.имя + ' ' + Клиенты.отчество AS Владелец
                            FROM 
                                Документы
                            LEFT JOIN 
                                Клиенты ON Документы.владельца_id = Клиенты.клиента_id
                            WHERE 
                                Документы.тип_документа LIKE '%' + @SearchKeyword + '%' OR 
                                CONCAT(Клиенты.фамилия, ' ', Клиенты.имя, ' ', Клиенты.отчество) LIKE '%' + @SearchKeyword + '%' OR
                                Документы.дата_выдачи LIKE '%' + @SearchKeyword + '%' OR
                                номер_документа LIKE '%' + @SearchKeyword + '%';";

            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_documents, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword3 + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView5.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            documents_table(textBox4.Text);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RefreshDataGridView4();
        }

        private void RefreshDataGridView4()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = @"SELECT 
                                Документы.документа_id AS [Id документа],
                                Документы.тип_документа AS [Тип документа],
                                SUBSTRING(номер_документа, 1, 4) + ' ' + SUBSTRING(номер_документа, 5, 1) + ' ' + 
                                SUBSTRING(номер_документа, 6, LEN(номер_документа) - 5) AS [Серия и номер],
                                Документы.дата_выдачи AS [Дата выдачи],
                                Клиенты.фамилия + ' ' + Клиенты.имя + ' ' + Клиенты.отчество AS Владелец
                            FROM 
                                Документы
                            LEFT JOIN 
                                Клиенты ON Документы.владельца_id = Клиенты.клиента_id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView5.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }

        private void add_document_btn_Click(object sender, EventArgs e)
        {
            AddDocumentForClient addDocumentForClient = new AddDocumentForClient();
            addDocumentForClient.Show();
        }
        private void delete_document_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить документы выбранного клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int orderIdToDelete = GetSelectedOrderIdToDelete3(); // Получите ID выбранного документа для удаления

                        // SQL запрос для удаления клиента
                        string deleteOrderQuery = "DELETE FROM Документы WHERE документа_id = @OrderId";

                        // Здесь вы должны выполнить запросы к базе данных, используя вашу библиотеку доступа к данным

                        // Запустите транзакцию для атомарного выполнения обоих запросов
                        database.getConnection();
                        {
                            database.openConnection();
                            using (SqlTransaction transaction = database.getConnection().BeginTransaction())
                            {
                                try
                                {
                                    // Удаление документов клиента
                                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Если все успешно, фиксируем транзакцию
                                    transaction.Commit();
                                    MessageBox.Show("Документы успешно удален.");
                                }
                                catch (Exception ex)
                                {
                                    // Если произошла ошибка, откатываем транзакцию
                                    transaction.Rollback();
                                    MessageBox.Show($"Произошла ошибка при удалении документов клиента: {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении документов клиента: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении документов клиента: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private int GetSelectedOrderIdToDelete3()
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView5.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку (предполагаем, что первая ячейка в строке содержит ID клиента)
                DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                // Получаем значение ID клиента из первой ячейки выбранной строки
                int orderId = Convert.ToInt32(selectedRow.Cells["Id документа"].Value);

                return orderId;
            }
            else
            {
                throw new Exception("Выберите строку с клиентом для удаления его документов.");
            }
        }
        // ДОКУМЕНТЫ КОНЕЦ





















        // ТАРИФЫ
        private void tarifs_table(string searchKeyword4)
        {
            string query_tarifs = @"SELECT тариф_id AS [Id тарифа], наименование AS Наименование, цена AS Цена, описание AS Описание 
                             FROM Тарифы 
                             WHERE наименование LIKE '%' + @SearchKeyword + '%' OR 
                                   цена LIKE '%' + @SearchKeyword + '%' OR 
                                   описание LIKE '%' + @SearchKeyword + '%';";

            try
            {
                database.openConnection();
                {
                    SqlCommand command = new SqlCommand(query_tarifs, database.getConnection());
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword4 + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView6.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выполнении запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tarifs_table(textBox5.Text);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RefreshDataGridView5();
        }

        private void RefreshDataGridView5()
        {
            try
            {
                database.getConnection();
                {
                    database.openConnection();
                    string query = "SELECT тариф_id AS [Id тарифа], наименование AS Наименование, цена AS Цена, описание AS Описание FROM Тарифы";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, database.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView6.DataSource = table;

                    MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                database.closeConnection();
            }
        }

        private void add_tariff_btn_Click(object sender, EventArgs e)
        {
            AddTariff addTariff = new AddTariff();
            addTariff.Show();
        }
        private void edit_tariff_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли какая-либо строка в DataGridView
                if (dataGridView6.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите тариф для редактирования.");
                    return;
                }

                // Получаем значение "номера_id" выбранной строки в DataGridView
                int orderId = Convert.ToInt32(dataGridView6.SelectedRows[0].Cells["Id тарифа"].Value);

                // Выполняем SQL-запрос для получения информации о клиенте
                string query = "SELECT наименование, цена, описание FROM Тарифы WHERE тариф_id = @OrderId";

                ChangeTariff changeTariff = new ChangeTariff();
                changeTariff.OrderId = orderId;

                // Подготавливаем объекты команды для выполнения запроса
                using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    database.openConnection();

                    // Выполняем запрос и получаем результаты
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем элементы управления на форме "ChangeClient" полученными
                            changeTariff.textBox1.Text = reader["наименование"].ToString();
                            changeTariff.textBox2.Text = reader["описание"].ToString();
                            changeTariff.textBox3.Text = reader["цена"].ToString();
                        }
                    }
                }
                changeTariff.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации о тарифе: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }

        private void delete_tariff_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный тариф?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int orderIdToDelete = GetSelectedOrderIdToDelete4(); // Получите ID выбранного тарифа для удаления

                        // SQL запрос для удаления тарифа
                        string deleteOrderQuery = "DELETE FROM Тарифы WHERE тариф_id = @OrderId";

                        // SQL запрос для обновления "тариф_id" в таблице "Заказ"
                        string updateBookingTariffIdQuery = "UPDATE Заказ SET тариф_id = NULL WHERE тариф_id = @OrderId";

                        // Здесь вы должны выполнить запросы к базе данных, используя вашу библиотеку доступа к данным

                        // Запустите транзакцию для атомарного выполнения обоих запросов
                        database.getConnection();
                        {
                            database.openConnection();
                            using (SqlTransaction transaction = database.getConnection().BeginTransaction())
                            {
                                try
                                {
                                    // Обновление заказа
                                    using (SqlCommand command = new SqlCommand(updateBookingTariffIdQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Удаление тарифа
                                    using (SqlCommand command = new SqlCommand(deleteOrderQuery, database.getConnection(), transaction))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", orderIdToDelete);
                                        command.ExecuteNonQuery();
                                    }

                                    // Если все успешно, фиксируем транзакцию
                                    transaction.Commit();
                                    MessageBox.Show("Тариф успешно удален.");
                                }
                                catch (Exception ex)
                                {
                                    // Если произошла ошибка, откатываем транзакцию
                                    transaction.Rollback();
                                    MessageBox.Show($"Произошла ошибка при удалении тарифа: {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении тарифа: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении тарифа: {ex.Message}");
            }
            finally
            {
                database.closeConnection();
            }
        }
        private int GetSelectedOrderIdToDelete4()
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView6.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку (предполагаем, что первая ячейка в строке содержит ID клиента)
                DataGridViewRow selectedRow = dataGridView6.SelectedRows[0];

                // Получаем значение ID клиента из первой ячейки выбранной строки
                int orderId = Convert.ToInt32(selectedRow.Cells["Id тарифа"].Value);

                return orderId;
            }
            else
            {
                throw new Exception("Выберите строку с нужным тарифом для удаления.");
            }
        }
        // ТАРИФЫ КОНЕЦ




        private void отчётыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }
        
    }
}

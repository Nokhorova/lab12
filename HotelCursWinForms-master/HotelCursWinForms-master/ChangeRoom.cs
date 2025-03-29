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
    
    public partial class ChangeRoom : Form
    {
        DataBase database = new DataBase();
        public int OrderId { get; set; }
        public ChangeRoom()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        public void SaveRoomChanges(int OrderId)
        {
            try
            {
                // Получение обновленных данных из формы ChangeBooking

                int numberRoom = int.Parse(textBox1.Text);
                int capacityOfGuests = int.Parse(comboBox1.Text); // Используем значение Value из выбранного элемента ComboBox
                bool availability = checkBox1.Checked; // Состояние CheckBox (true - свободен, false - занят)
                int countRooms = int.Parse(comboBox2.Text); // Используем значение Value из выбранного элемента ComboBox
                decimal square = decimal.Parse(textBox3.Text);


                // Обновление информации о бронировании
                using (SqlCommand updateCommand = new SqlCommand("UPDATE Номера SET номер_комнаты = @NumberRoom, вместимость_гостей = @CapacityOfGuest, доступность = @Availability, количество_комнат = @CountRooms, площадь = @Square WHERE номера_id = @OrderId", database.getConnection()))
                {
                    updateCommand.Parameters.AddWithValue("@NumberRoom", numberRoom);
                    updateCommand.Parameters.AddWithValue("@CapacityOfGuest", capacityOfGuests);
                    updateCommand.Parameters.AddWithValue("@Availability", countRooms);
                    updateCommand.Parameters.AddWithValue("@CountRooms", countRooms);
                    updateCommand.Parameters.AddWithValue("@Square", square);
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
            finally
            {
                database.closeConnection();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Проверяем состояние checkBox1 и обновляем текст в зависимости от него
            checkBox1.Text = checkBox1.Checked ? "Доступность (свободен)" : "Доступность (занят)";
        }

        private void edit_room_btn_Click(object sender, EventArgs e)
        {
            SaveRoomChanges(OrderId);
        }
    }
}

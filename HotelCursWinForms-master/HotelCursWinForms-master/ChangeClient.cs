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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelCurs
{
    public partial class ChangeClient : Form
    {
        DataBase database = new DataBase();
        public int OrderId { get; set; }
        public ChangeClient()
        {
            InitializeComponent();
        }

        public void SaveRoomChanges(int OrderId)
        {
            try
            {
                // Получение обновленных данных из формы ChangeBooking

                string lastname = textBox1.Text;
                string firstname = textBox2.Text;
                string patronymic = textBox3.Text;
                string address = textBox4.Text;
                string email = textBox5.Text;
                string phoneNumber = maskedTextBox1.Text;


                // Обновление информации о бронировании
                using (SqlCommand updateCommand = new SqlCommand("UPDATE Клиенты SET фамилия = @LastName, имя = @FirstName, отчество = @Patronymic, адрес = @Address, почта = @Email, номер_телефона = @PhoneNumber WHERE клиента_id = @OrderId", database.getConnection()))
                {

                    updateCommand.Parameters.AddWithValue("@LastName", lastname);
                    updateCommand.Parameters.AddWithValue("@FirstName", firstname);
                    updateCommand.Parameters.AddWithValue("@Patronymic", patronymic);
                    updateCommand.Parameters.AddWithValue("@Address", address);
                    updateCommand.Parameters.AddWithValue("@Email", email);
                    updateCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
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

        private void save_client_btn_Click(object sender, EventArgs e)
        {
            SaveRoomChanges(OrderId);
        }
    }
}

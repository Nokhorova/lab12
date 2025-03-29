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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelCurs
{
    public partial class AddClient : Form
    {
        DataBase database = new DataBase();
        public AddClient()
        {
            InitializeComponent();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void add_client_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string lastname = textBox1.Text;
                string firstname = textBox2.Text;
                string patronymic = textBox3.Text;
                string address = textBox4.Text;
                string email = textBox5.Text;
                string phoneNumber = maskedTextBox1.Text;

                AddNewClient(lastname, firstname, patronymic, address, email, phoneNumber);

                MessageBox.Show("Клиент успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании клиента: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewClient(string lastname, string firstname, string patronymic, string address, string email, string phoneNumber)
        {
            try
            {
                string query = "INSERT INTO Клиенты (фамилия, имя, отчество, адрес, почта, номер_телефона) VALUES (@LastName, @FirstName, @Patronymic, @Address, @Email, @PhoneNumber);";

                database.getConnection();
                {
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@LastName", lastname);
                    command.Parameters.AddWithValue("@FirstName", firstname);
                    command.Parameters.AddWithValue("@Patronymic", patronymic);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    database.openConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при заполнении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

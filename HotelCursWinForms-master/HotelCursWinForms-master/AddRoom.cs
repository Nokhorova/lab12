using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCurs
{
    public partial class AddRoom : Form
    {
        DataBase database = new DataBase();
        public AddRoom()
        {
            InitializeComponent();
        }

        private void add_room_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int numberRoom = Convert.ToInt32(textBox1.Text);
                int capacityOfGuests = int.Parse(comboBox1.SelectedItem.ToString());
                int countRooms = int.Parse(comboBox2.SelectedItem.ToString());

                decimal square = decimal.Parse(textBox3.Text);

                if (!RoomExists(numberRoom))
                {
                    AddNewRoom(numberRoom, capacityOfGuests, countRooms, square);
                    MessageBox.Show("Номер успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Комната с таким номером уже существует. \nВыберите другой номер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании номера: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewRoom(int numberRoom, int capacityOfGuests, int countRooms, decimal square)
        {
            try
            {
                string query = "INSERT INTO Номера (номер_комнаты, вместимость_гостей, доступность, площадь, количество_комнат) VALUES (@NumberRoom, @CapacityOfGuests, @Availability, @Square, @CountRooms);";

                database.getConnection();
                {
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@NumberRoom", numberRoom);
                    command.Parameters.AddWithValue("@CapacityOfGuests", capacityOfGuests);
                    command.Parameters.AddWithValue("@Availability", 1); // т.к изначально при создании номера, он свободен
                    command.Parameters.AddWithValue("@Square", square);
                    command.Parameters.AddWithValue("@CountRooms", countRooms);

                    database.openConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Произошла ошибка при заполнении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool RoomExists(int numberRoom)
        {
            string query = "SELECT COUNT(*) FROM Номера WHERE номер_комнаты = @NumberRoom";
            database.getConnection();
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                command.Parameters.AddWithValue("@NumberRoom", numberRoom);

                database.openConnection();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

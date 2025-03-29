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
    public partial class ChangeTariff : Form
    {
        DataBase database = new DataBase();
        public int OrderId { get; set; }
        public ChangeTariff()
        {
            InitializeComponent();
        }

        public void SaveRoomChanges(int OrderId)
        {
            try
            {
                // Получение обновленных данных из формы ChangeBooking

                string tariff = textBox1.Text;
                string description = textBox2.Text;
                decimal price = decimal.Parse(textBox3.Text);


                // Обновление информации о бронировании
                using (SqlCommand updateCommand = new SqlCommand("UPDATE Тарифы SET наименование = @Tariff, цена = @Price, описание = @Description WHERE тариф_id = @OrderId", database.getConnection()))
                {

                    updateCommand.Parameters.AddWithValue("@Tariff", tariff);
                    updateCommand.Parameters.AddWithValue("@Price", price);
                    updateCommand.Parameters.AddWithValue("@Description", description);
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

        private void save_tariff_btn_Click(object sender, EventArgs e)
        {
            SaveRoomChanges(OrderId);
        }
    }
}

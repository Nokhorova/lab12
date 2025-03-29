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
    public partial class AddTariff : Form
    {
        DataBase database = new DataBase();
        public AddTariff()
        {
            InitializeComponent();
        }

        private void save_tariff_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string tariff = textBox1.Text;
                string description = textBox2.Text;
                string price = textBox3.Text;

                AddNewTariff(tariff, description, price);

                MessageBox.Show("Тариф успешно создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при создании тарифа: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewTariff(string tariff, string description, string price)
        {
            try
            {
                string query = "INSERT INTO Тарифы (наименование, цена, описание) VALUES (@Tariff, @Price, @Description);";

                database.getConnection();
                {
                    SqlCommand command = new SqlCommand(query, database.getConnection());
                    command.Parameters.AddWithValue("@Tariff", tariff);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Description", description);

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

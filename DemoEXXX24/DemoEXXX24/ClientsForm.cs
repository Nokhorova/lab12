using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEXXX24
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }

        private void personBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);

        }

        private void ClientsForm_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.demEx24DataSet.Person);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < personDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < personDataGridView.RowCount - 1; j++)
                {
                    personDataGridView[i, j].Style.BackColor = Color.White;
                    personDataGridView[i, j].Style.ForeColor = Color.Black;
                }
            }

            for (int i = 0; i < personDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < personDataGridView.RowCount - 1; j++)
                {
                    if (personDataGridView[i,
                   j].Value.ToString().IndexOf(textBox1.Text) != -1)
                    {
                        personDataGridView[i, j].Style.BackColor = Color.AliceBlue;
                        personDataGridView[i, j].Style.ForeColor = Color.Blue;

                    }
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            personBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            personBindingSource.RemoveCurrent();
        }
    }
}

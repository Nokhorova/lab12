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
    public partial class ManagerMenuForm : Form
    {
        public ManagerMenuForm()
        {
            InitializeComponent();
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            this.Hide();
            clientsForm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestForm requestForm = new RequestForm();
            this.Hide();
            requestForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatisticForm statisticForm = new StatisticForm();
            this.Hide();
            statisticForm.ShowDialog();
            this.Show();
        }

        
    }
}

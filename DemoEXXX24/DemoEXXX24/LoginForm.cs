using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DemoEXXX24
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.demEx24DataSet.Employee);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginText = textBox1.Text;
            string passwordText = textBox2.Text;
            var employeeRow = demEx24DataSet.Employee.FirstOrDefault(x => x.Login == loginText && x.Password == passwordText);

            if (employeeRow == null)
            {
                MessageBox.Show("Хорошая попытка, жулик");
                return;
            }

            string position = employeeRow.Position;
            if (position == "manager")
            {
                ManagerMenuForm managerMenuForm = new ManagerMenuForm();
                this.Hide();
                managerMenuForm.ShowDialog();
                this.Show();
            }

            if (position == "specialist")
            {
                RepairMenuForm repairMenuForm = new RepairMenuForm();
                this.Hide();
                repairMenuForm.ShowDialog();
                this.Show();
            }
        }
    }
}

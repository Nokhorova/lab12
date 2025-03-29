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
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
        }

       

        private void RequestForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.demEx24DataSet.Model);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.demEx24DataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.demEx24DataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.demEx24DataSet.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.demEx24DataSet.Person);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.FaultType". При необходимости она может быть перемещена или удалена.
            this.faultTypeTableAdapter.Fill(this.demEx24DataSet.FaultType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Equipment". При необходимости она может быть перемещена или удалена.
            this.equipmentTableAdapter.Fill(this.demEx24DataSet.Equipment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Status". При необходимости она может быть перемещена или удалена.
            this.statusTableAdapter.Fill(this.demEx24DataSet.Status);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Request". При необходимости она может быть перемещена или удалена.
            this.requestTableAdapter.Fill(this.demEx24DataSet.Request);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Person". При необходимости она может быть перемещена или удалена.
            


        }

        

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.ShowDialog();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            EquipmentForm equipmentForm = new EquipmentForm();
            equipmentForm.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FaultTypeForm faultTypeForm = new FaultTypeForm();
            faultTypeForm.ShowDialog();
        }
        

        private void AddRequastBtn_Click(object sender, EventArgs e)
        {
            requestBindingSource.AddNew();
        }

        private void UpdateRequastBtn_Click(object sender, EventArgs e)
        {
            requestBindingSource.AddNew();
            this.Validate();
            this.requestBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Заявка успешно добавлена!");
            this.Close();
        }

        private void DeleteRequastBtn_Click(object sender, EventArgs e)
        {
            requestBindingSource.RemoveCurrent();
        }


    }
}

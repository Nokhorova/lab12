using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DemoEXXX24
{
    public partial class RepairMenuForm : Form
    {
        public RepairMenuForm()
        {
            InitializeComponent();
        }


        private void RepairMenuForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.demEx24DataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.demEx24DataSet.Model);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Component". При необходимости она может быть перемещена или удалена.
            this.componentTableAdapter.Fill(this.demEx24DataSet.Component);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.PartsOrderComponent". При необходимости она может быть перемещена или удалена.
            this.partsOrderComponentTableAdapter.Fill(this.demEx24DataSet.PartsOrderComponent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.PartsOrder". При необходимости она может быть перемещена или удалена.
            this.partsOrderTableAdapter.Fill(this.demEx24DataSet.PartsOrder);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.FaultType". При необходимости она может быть перемещена или удалена.
            this.faultTypeTableAdapter.Fill(this.demEx24DataSet.FaultType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.demEx24DataSet.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.demEx24DataSet.Person);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Equipment". При необходимости она может быть перемещена или удалена.
            this.equipmentTableAdapter.Fill(this.demEx24DataSet.Equipment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Status". При необходимости она может быть перемещена или удалена.
            this.statusTableAdapter.Fill(this.demEx24DataSet.Status);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Request". При необходимости она может быть перемещена или удалена.
            this.requestTableAdapter.Fill(this.demEx24DataSet.Request);

        }

        private void UpdateRequestRemontBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.requestBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Успешно СОХРАНЕНО");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FaultTypeForm faultTypeForm = new FaultTypeForm();
            faultTypeForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestPartsOrderForm requestPartsOrderForm = new RequestPartsOrderForm();
            requestPartsOrderForm.ShowDialog();
        }

        private void AddZakazComponentBtn_Click(object sender, EventArgs e)
        {
            partsOrderComponentBindingSource.AddNew();
        }

        private void UpdateZakazComponentBtn_Click(object sender, EventArgs e)
        {
            partsOrderComponentBindingSource.AddNew();
            this.Validate();
            this.partsOrderComponentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Заказ создан успешно");
        }

        private void DeleteZakazComponentBtn_Click(object sender, EventArgs e)
        {
            partsOrderComponentBindingSource.RemoveCurrent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CoponentForm component = new CoponentForm();
            component.ShowDialog();
        }
    }
}

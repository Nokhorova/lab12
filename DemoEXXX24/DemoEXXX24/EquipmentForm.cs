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
    public partial class EquipmentForm : Form
    {
        public EquipmentForm()
        {
            InitializeComponent();
        }

       

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.demEx24DataSet.Model);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Equipment". При необходимости она может быть перемещена или удалена.
            this.equipmentTableAdapter.Fill(this.demEx24DataSet.Equipment);
           

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            equipmentBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            equipmentBindingSource.AddNew();
            this.Validate();
            this.equipmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Оборудование сохранено");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            equipmentBindingSource.RemoveCurrent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ModelForm modelForm = new ModelForm();

            modelForm.ShowDialog();


        }

        private void equipmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.equipmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);

        }
    }
}

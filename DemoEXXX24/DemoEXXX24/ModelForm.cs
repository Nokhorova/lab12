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
    public partial class ModelForm : Form
    {
        public ModelForm()
        {
            InitializeComponent();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.demEx24DataSet.Manufacturer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.demEx24DataSet.Model);

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            modelBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            modelBindingSource.AddNew();
            this.Validate();
            this.modelBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Модель успешно добавлена!");
            this.Close();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            modelBindingSource.RemoveCurrent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MAnufactureForm mAnufactureForm = new MAnufactureForm();    
            mAnufactureForm.ShowDialog();
        }
    }
}

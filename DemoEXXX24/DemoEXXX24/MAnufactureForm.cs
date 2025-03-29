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
    public partial class MAnufactureForm : Form
    {
        public MAnufactureForm()
        {
            InitializeComponent();
        }

        

        private void MAnufactureForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Manufacturer". При необходимости она может быть перемещена или удалена.
            this.manufacturerTableAdapter.Fill(this.demEx24DataSet.Manufacturer);

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            manufacturerBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.manufacturerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            manufacturerBindingSource.RemoveCurrent();
        }
    }
}

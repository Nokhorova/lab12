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
    public partial class FaultTypeForm : Form
    {
        public FaultTypeForm()
        {
            InitializeComponent();
        }

        //private void faultTypeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //    this.Validate();
        //    this.faultTypeBindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.demEx24DataSet1);

        //}

        private void FaultTypeForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.FaultType". При необходимости она может быть перемещена или удалена.
            this.faultTypeTableAdapter.Fill(this.demEx24DataSet.FaultType);

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            faultTypeBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.faultTypeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            faultTypeBindingSource.RemoveCurrent();
        }
    }
}

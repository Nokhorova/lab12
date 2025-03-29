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
    public partial class CoponentForm : Form
    {
        public CoponentForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            componentBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.componentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            componentBindingSource.RemoveCurrent();
        }

        private void CoponentForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Component". При необходимости она может быть перемещена или удалена.
            this.componentTableAdapter.Fill(this.demEx24DataSet.Component);

        }
    }
}

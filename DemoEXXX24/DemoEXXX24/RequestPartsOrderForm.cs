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
    public partial class RequestPartsOrderForm : Form
    {
        public RequestPartsOrderForm()
        {
            InitializeComponent();
        }

        

        private void RequestPartsOrderForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.demEx24DataSet.Person);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.Request". При необходимости она может быть перемещена или удалена.
            this.requestTableAdapter.Fill(this.demEx24DataSet.Request);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.PartsOrder". При необходимости она может быть перемещена или удалена.
            this.partsOrderTableAdapter.Fill(this.demEx24DataSet.PartsOrder);

        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            partsOrderBindingSource.AddNew();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            partsOrderBindingSource.AddNew();
            this.Validate();
            this.partsOrderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.demEx24DataSet);
            MessageBox.Show("Заявка успеешно создана!");
            this.Close();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            partsOrderBindingSource.RemoveCurrent();
        }
    }
}

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
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet1.FaultType". При необходимости она может быть перемещена или удалена.
            this.faultTypeTableAdapter.Fill(this.demEx24DataSet1.FaultType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "demEx24DataSet.StatisticAll". При необходимости она может быть перемещена или удалена.
            this.statisticAllTableAdapter.Fill(this.demEx24DataSet.StatisticAll);

        }
    }
}

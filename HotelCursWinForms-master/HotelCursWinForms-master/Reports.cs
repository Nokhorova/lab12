using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCurs
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Curs_GetTopUsedTariffs.GetTopUsedTariffs". При необходимости она может быть перемещена или удалена.
            this.getTopUsedTariffsTableAdapter.Fill(this.hotel_Curs_GetTopUsedTariffs.GetTopUsedTariffs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Curs_GetTop5ClientsWithMostDaysOrderedAndOrdersCount.GetTop5ClientsWithMostDaysOrderedAndOrdersCount". При необходимости она может быть перемещена или удалена.
            this.getTop5ClientsWithMostDaysOrderedAndOrdersCountTableAdapter.Fill(this.hotel_Curs_GetTop5ClientsWithMostDaysOrderedAndOrdersCount.GetTop5ClientsWithMostDaysOrderedAndOrdersCount);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotel_Curs_GetOrdersBetween15th.GetOrdersBetween15th". При необходимости она может быть перемещена или удалена.
            this.getOrdersBetween15thTableAdapter.Fill(this.hotel_Curs_GetOrdersBetween15th.GetOrdersBetween15th);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void btnShowReports_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            // Вызов хранимой процедуры и передача параметров
            this.getOrdersBetween15thTableAdapter.FillByDates(this.hotel_Curs_GetOrdersBetween15th.GetOrdersBetween15th, startDate, endDate);

            // Обновление ReportViewer
            this.reportViewer1.RefreshReport();
        }

        private void btnShowReport1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker4.Value;
            DateTime endDate = dateTimePicker3.Value;

            // Вызов хранимой процедуры и передача параметров
            this.getTop5ClientsWithMostDaysOrderedAndOrdersCountTableAdapter.FillByDates1(this.hotel_Curs_GetTop5ClientsWithMostDaysOrderedAndOrdersCount.GetTop5ClientsWithMostDaysOrderedAndOrdersCount, startDate, endDate);

            // Обновление ReportViewer
            this.reportViewer2.RefreshReport();
        }

        private void btnShowReport3_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker6.Value;
            DateTime endDate = dateTimePicker5.Value;

            // Вызов хранимой процедуры и передача параметров
            this.getTopUsedTariffsTableAdapter.FillByDates2(this.hotel_Curs_GetTopUsedTariffs.GetTopUsedTariffs, startDate, endDate);

            // Обновление ReportViewer
            this.reportViewer3.RefreshReport();
        }
    }
}

using ClosedXML.Excel;
using HotelProgram.ViewModels;
using Microsoft.Win32;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public string connectionString = "Data Source=AcerNitro5;Initial Catalog=Hotel_bd;Integrated Security=True;TrustServerCertificate=True";
        public ReportsView()
        {
            InitializeComponent();
            SetDefaultDates();
            LoadReports();
        }
        private void CalculateSummary(DataTable dataTable, out int totalOrders, out decimal totalCost)
        {
            totalOrders = dataTable.Rows.Count;
            totalCost = dataTable.AsEnumerable()
                                 .Where(row => row["Стоимость (руб.)"] != DBNull.Value)
                                 .Sum(row => row.Field<decimal>("Стоимость (руб.)"));
        }

        public static class DatabaseHelper
        {
            public static DataTable ExecuteStoredProcedure(string connectionString, string storedProcedureName, SqlParameter[] parameters)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        private void SetDefaultDates()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1, 0, 0, 0);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).Date.AddDays(1).AddTicks(-1);

            startDatePicker.SelectedDate = firstDayOfMonth;
            endDatePicker.SelectedDate = lastDayOfMonth;
        }
        private void dataGridGetBookingsReport_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        public void LoadReports()
        {
            if (startDatePicker.SelectedDate.HasValue && endDatePicker.SelectedDate.HasValue)
            {
                DateTime startDate = startDatePicker.SelectedDate.Value;
                DateTime endDate = endDatePicker.SelectedDate.Value;

                // Установка времени
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999);

                LoadDataToGrid("ReportEmployees", dataGridReportEmployees, new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                LoadDataToGrid("ReportIncome", dataGridReportIncomes, new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                LoadDataToGrid("ReportServices", dataGridReportServices, new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
                    new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate }
                };

                try
                {
                    DataTable dataTable = DatabaseHelper.ExecuteStoredProcedure(connectionString, "GetBookingsReport", parameters);
                    int totalOrders;
                    decimal totalCost;
                    CalculateSummary(dataTable, out totalOrders, out totalCost);
                    dataGridGetBookingsReport.ItemsSource = dataTable.DefaultView;

                    // Обновление текстовых блоков
                    totalOrdersTextBlock.Text = totalOrders.ToString();
                    totalCostTextBlock.Text = totalCost.ToString("N2"); // Форматирование в валюту
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                LogTransaction(1, $"Отчёт");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите даты для отчёта.");
            }

        }
        private void LoadDataToGrid(string storedProcedure, DataGrid dataGrid, params SqlParameter[] parameters)
        {
            DataTable dataTable = DatabaseHelper.ExecuteStoredProcedure(connectionString, storedProcedure, parameters);
            dataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void LoadReportBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadReports();
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = mainTabControl.SelectedItem as TabItem;

            if (selectedTab != null)
            {
                if (selectedTab == tabItemAdditionalOrder)
                {
                    ExportToExcel(dataGridGetBookingsReport, "Общий отчёт о бронированиях");
                    LogTransaction(11, $"Общий отчёт о бронированиях");
                }
                else if (selectedTab == tabItemServices)
                {
                    ExportToExcel(dataGridReportServices, "Общий отчёт об услугах");
                    LogTransaction(11, $"Общий отчёт об услугах");
                }
                else if (selectedTab == tabItemEmployessReport)
                {
                    ExportToExcel(dataGridReportEmployees, "Отчёт о работе сотрудников");
                    LogTransaction(11, $"Отчёт о работе сотрудников");
                }
                else if (selectedTab == tabItemIncomesReport)
                {
                    ExportToExcel(dataGridReportIncomes, "Отчёт о доходах");
                    LogTransaction(11, $"Отчёт о доходах");
                }
            }
        }

        private void ExportToWordButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem selectedTab = mainTabControl.SelectedItem as TabItem;

            if (selectedTab != null)
            {
                if (selectedTab == tabItemAdditionalOrder)
                {
                    ExportToWord(dataGridGetBookingsReport, "Общий отчёт о бронированиях");
                    LogTransaction(12, $"Общий отчёт о бронированиях");
                }
                else if (selectedTab == tabItemServices)
                {
                    ExportToWord(dataGridReportServices, "Общий отчёт об услугах");
                    LogTransaction(12, $"Общий отчёт об услугах");
                }
                else if (selectedTab == tabItemEmployessReport)
                {
                    ExportToWord(dataGridReportEmployees, "Отчёт о работе сотрудников");
                    LogTransaction(12, $"Отчёт о работе сотрудников");
                }
                else if (selectedTab == tabItemIncomesReport)
                {
                    ExportToWord(dataGridReportIncomes, "Отчёт о доходах");
                    LogTransaction(12, $"Отчёт о доходах");
                }
            }
        }
        private void ExportToExcel(DataGrid dataGrid, string sheetName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                DefaultExt = "xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    // Write headers
                    for (int i = 0; i < dataGrid.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGrid.Columns[i].Header.ToString();
                    }

                    // Write data
                    for (int i = 0; i < dataGrid.Items.Count; i++)
                    {
                        for (int j = 0; j < dataGrid.Columns.Count; j++)
                        {
                            if (dataGrid.Columns[j].GetCellContent(dataGrid.Items[i]) is TextBlock cellContent)
                            {
                                string cellText = cellContent.Text;
                                if (double.TryParse(cellText, out double number))
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = number;
                                }
                                else
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = cellText;
                                }
                            }
                        }
                    }

                    // Add summary text blocks if dataGrid is dataGridGetBookingsReport
                    if (dataGrid == dataGridGetBookingsReport)
                    {
                        int lastRow = dataGrid.Items.Count + 2;
                        worksheet.Cell(lastRow, 1).Value = "Заказов: ";
                        worksheet.Cell(lastRow, 2).Value = int.Parse(totalOrdersTextBlock.Text);
                        worksheet.Cell(lastRow, 10).Value = "Общая стоимость: ";
                        worksheet.Cell(lastRow, 11).Value = decimal.Parse(totalCostTextBlock.Text).ToString("N2");
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Экспорт в Excel завершен.");
            }
        }

        private void ExportToWord(DataGrid dataGrid, string title)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Documents|*.docx",
                DefaultExt = "docx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        XWPFDocument document = new XWPFDocument();

                        // Создание таблицы
                        XWPFTable table = document.CreateTable(dataGrid.Items.Count + 1, dataGrid.Columns.Count);

                        // Запись заголовков
                        for (int i = 0; i < dataGrid.Columns.Count; i++)
                        {
                            table.GetRow(0).GetCell(i).SetText(dataGrid.Columns[i].Header.ToString());
                        }

                        // Запись данных
                        for (int i = 0; i < dataGrid.Items.Count; i++)
                        {
                            for (int j = 0; j < dataGrid.Columns.Count; j++)
                            {
                                if (dataGrid.Columns[j].GetCellContent(dataGrid.Items[i]) is TextBlock cellContent)
                                {
                                    table.GetRow(i + 1).GetCell(j).SetText(cellContent.Text);
                                }
                            }
                        }

                        // Добавление строки для текстовых блоков, если dataGrid == dataGridGetBookingsReport
                        if (dataGrid == dataGridGetBookingsReport)
                        {
                            XWPFTableRow summaryRow = table.CreateRow();
                            summaryRow.GetCell(0).SetText("Заказов: ");
                            summaryRow.GetCell(1).SetText(totalOrdersTextBlock.Text);
                            summaryRow.GetCell(2).SetText("Общая стоимость: ");
                            summaryRow.GetCell(3).SetText(totalCostTextBlock.Text);
                        }

                        document.Write(fs);
                        fs.Close();
                    }

                    MessageBox.Show("Экспорт в Word завершен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при экспорте в Word: " + ex.Message);
                }
            }
        }
        private void LogTransaction(int typeOperationId, string windowName)
        {
            using (var _context = new Hotel_bdEntities()) // Замените YourDbContext на ваш тип контекста
            {
                var transaction = new transaction
                {
                    employee_id = GetCurrentEmployeeId(), // Предположим, что _employee_id доступен где-то в вашем классе
                    type_operation_id = typeOperationId,
                    date = DateTime.Now,
                    window_name = windowName
                };

                _context.transaction.Add(transaction);
                _context.SaveChanges();
            }
        }
        private int GetCurrentEmployeeId()
        {
            var authenticatedUser = LoginViewModel.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                using (var _context = new Hotel_bdEntities()) // Замените YourDbContext на ваш тип контекста
                {
                    var employee = _context.employees.FirstOrDefault(e => e.Id == authenticatedUser.Id);
                    if (employee != null)
                    {
                        return employee.employee_id;
                    }
                }
            }
            return 0; // Или другое значение по умолчанию для идентификатора сотрудника
        }
    }
}

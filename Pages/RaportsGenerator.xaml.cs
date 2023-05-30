using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asgard.Pages
{
    /// <summary>
    /// Interaction logic for RaportsGenerator.xaml
    /// </summary>
    public partial class RaportsGenerator : Page
    {
        public RaportsGenerator()
        {
            InitializeComponent();
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected dates
            DateTime startDate = Data_start.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = Data_final.SelectedDate ?? DateTime.MaxValue;

            // Connect to the database
            string connectionString = "server=192.168.100.18;port=3306;user=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Retrieve data from the database based on the selected date range
                    string query = $"SELECT * FROM chestionare_cec WHERE DATE >= @StartDate AND DATE <= @EndDate";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Generate CSV data
                    StringBuilder csvData = new StringBuilder();

                    // Append column headers
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        csvData.Append(QuoteValue(column.ColumnName) + ",");
                    }
                    csvData.AppendLine();

                    // Append data rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            csvData.Append(QuoteValue(item.ToString()) + ",");
                        }
                        csvData.AppendLine();
                    }

                    // Save CSV data to a file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, csvData.ToString());
                        MessageBox.Show("CSV report generated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating CSV report: " + ex.Message);
                }
            }
        }

        private string QuoteValue(string value)
        {
            if (value.Contains(","))
            {
                // If the value contains a comma, enclose it within double quotation marks
                return "\"" + value + "\"";
            }
            else
            {
                return value;
            }
        }
    }
}

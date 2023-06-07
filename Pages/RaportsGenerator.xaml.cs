// <copyright file="RaportsGenerator.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Pages
{
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Asgard.Repositories;
    using Microsoft.Win32;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for RaportsGenerator.xaml.
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

            try
            {
                // Connect to the database using RepositoryBase.GetConnectionPublic()
                using (var connection = RepositoryBase.GetConnectionPublic())
                {
                    // Retrieve data from the database based on the selected date range
                    string query = $"SELECT * FROM chestionare_cec WHERE DATE >= @StartDate AND DATE <= @EndDate";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    // Execute the query and fill a DataTable with the results
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
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "CSV Files (*.csv)|*.csv",
                    };
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, csvData.ToString());
                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Raport generat";
                            dialog.Descriere.Text = "Raportul a fost generat cu succes.";
                        };
                        dialog.ShowDialog();
                        return;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Nu am putut genera";
                    dialog.Descriere.Text = "Am întâmpinat următoarea eroare: " + ex;
                };
                dialog.ShowDialog();
                return;
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

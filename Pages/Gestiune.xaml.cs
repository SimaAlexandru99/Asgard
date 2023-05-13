// <copyright file="Gestiune.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Pages
{
    using Asgard.CustomControls;
    using Asgard.Repositories;
    using Asgard.ViewModels;
    using iTextSharp.text.pdf;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Gestiune.xaml.
    /// </summary>
    public partial class Gestiune : Page
    {
        public ObservableCollection<DeviceModel> MyDataList;

        public ObservableCollection<DeviceModel2> MyDataList2;

        private readonly MainViewModel user;

        // Declare a variable to store the ID value of the selected row
        public int SelectedId;
        public string SelectedCategory;
        private string selectedMouse;
        private string selectedTastatura;
        private string selectedCasti;

        private int currentPage = 1;

        private int rowsPerPage = 20;

        public Gestiune()
        {
            InitializeComponent();

            user = new MainViewModel();

            // Bind the DataGrid to the MySQL database
            LoadData();
        }

        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the data item bound to the clicked row
            var selectedItem = ((FrameworkElement)sender).DataContext as DeviceModel;

            var ID = int.Parse(selectedItem.Column1);

            // Store the ID value in a variable
            SelectedId = ID;

            SelectedCategory = selectedItem.Column8;

            selectedMouse = selectedItem.Column9;

            selectedTastatura = selectedItem.Column10;

            selectedCasti = selectedItem.Column11;

            if (selectedItem != null)
            {
                var edit = new UpdateDeviceWindow();

                // Populate the edit form with the selected row's data
                selectedItem.Column1.ToString();
                edit.ModelTextBoxAdd.Text = selectedItem.Column2;
                edit.SerieTextBoxAdd.Text = selectedItem.Column3;
                edit.AgentTextBoxAdd.Text = selectedItem.Column4;
                edit.AnydeskTextBoxAdd.Text = selectedItem.Column5;
                edit.StatusTextBoxAdd.Text = selectedItem.Column6;
                edit.StareTextBoxAdd.Text = selectedItem.Column7;
                edit.CategorieTextBoxAdd.Text = selectedItem.Column8;
                edit.MouseTextBoxAdd.Text = selectedItem.Column9;
                edit.TastaturaTextBoxAdd.Text = selectedItem.Column10;
                edit.CastiTextBoxAdd.Text = selectedItem.Column11;
                edit.LicentaAdd.Text = selectedItem.Column12;
                edit.Internet.Text = selectedItem.Column13;
                edit.Closing += this.Refresh_Closing;

                // Open the popup
                edit.Show();
            }
        }

        private void LoadData()
        {
            using (var connection = RepositoryBase.GetConnectionPublic())
            {
                MyDataList = new ObservableCollection<DeviceModel>();
                MyDataList2 = new ObservableCollection<DeviceModel2>();

                int offset = (currentPage - 1) * rowsPerPage;

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT ID, MODEL, SERIE, AGENT, ANYDESK, STATUS, STARE, CATEGORIE, MOUSE, TASTATURA, CASTI, LICENTA, INTERNET FROM gestiune WHERE CATEGORIE = 'LAPTOP' LIMIT {offset},{rowsPerPage}";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyDataList.Add(new DeviceModel { Column1 = reader[0].ToString(), Column2 = reader[1].ToString(), Column3 = reader[2].ToString(), Column4 = reader[3].ToString(), Column5 = reader[4].ToString(), Column6 = reader[5].ToString(), Column7 = reader[6].ToString(), Column8 = reader[7].ToString(), Column9 = reader[8].ToString(), Column10 = reader[9].ToString(), Column11 = reader[10].ToString(), Column12 = reader[11].ToString(), Column13 = reader[12].ToString() });
                        }
                    }
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT ID, MODEL, SERIE, AGENT, ANYDESK, STATUS, STARE, CATEGORIE, MOUSE, TASTATURA, CASTI, LICENTA, INTERNET FROM gestiune WHERE CATEGORIE = 'UNITATE' LIMIT {offset},{rowsPerPage}";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MyDataList2.Add(new DeviceModel2 { Column1 = reader[0].ToString(), Column2 = reader[1].ToString(), Column3 = reader[2].ToString(), Column4 = reader[3].ToString(), Column5 = reader[4].ToString(), Column6 = reader[5].ToString(), Column7 = reader[6].ToString(), Column8 = reader[7].ToString(), Column9 = reader[8].ToString(), Column10 = reader[9].ToString(), Column11 = reader[10].ToString(), Column12 = reader[11].ToString(), Column13 = reader[12].ToString() });
                        }
                    }
                }
            }

            MyDataGrid.ItemsSource = MyDataList;
            MyDataGrid2.ItemsSource = MyDataList2;
        }

        private void Refresh_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Refresh();
        }

        private void Cell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MyDataGrid.ItemsSource = MyDataList;
            }
            else
            {
                searchText = searchText.ToLower();
                MyDataGrid.ItemsSource = MyDataList.AsParallel().Where(item =>
                    item.Column1.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Column2.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Column3.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Column4.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Column5.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    item.Column6.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void MyDataGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (myTabControl.SelectedIndex == 0)
            {
                // Prompt the user for confirmation
                var result = MessageBox.Show("Sigur vrei să ștergi această înregistrare?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Get the selected row from the DataGrid
                    DeviceModel selectedRow = (DeviceModel)MyDataGrid.SelectedItem;

                    // Delete the row from the MySQL database
                    using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
                    {
                        string query = "DELETE FROM gestiune WHERE Id = @Id";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedRow.Column1);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Delete the row from the DataGrid
                    var data = MyDataGrid.ItemsSource.Cast<DeviceModel>().ToList();
                    var observableData = new ObservableCollection<DeviceModel>(data);

                    observableData.Remove(selectedRow);
                }
            }
            else if (myTabControl.SelectedIndex == 1)
            {
                // Prompt the user for confirmation
                var result = MessageBox.Show("Sigur vrei să ștergi această înregistrare?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Get the selected row from the DataGrid
                    DeviceModel2 selectedRow = (DeviceModel2)MyDataGrid2.SelectedItem;

                    // Delete the row from the MySQL database
                    using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
                    {
                        string query = "DELETE FROM gestiune WHERE Id = @Id";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedRow.Column1);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Delete the row from the DataGrid
                    var data = MyDataGrid2.ItemsSource.Cast<DeviceModel2>().ToList();
                    var observableData = new ObservableCollection<DeviceModel2>(data);

                    observableData.Remove(selectedRow);
                }
            }

            NavigationService.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();

            addDeviceWindow.Closing += Refresh_Closing;

            addDeviceWindow.Show();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MyDataGrid.Width = e.NewSize.Width - (e.NewSize.Width * .1);

            foreach (var column in MyDataGrid.Columns)
            {
                column.Width = MyDataGrid.Width / MyDataGrid.Columns.Count;
            }

            MyDataGrid2.Width = e.NewSize.Width - (e.NewSize.Width * .1);

            foreach (var column in MyDataGrid2.Columns)
            {
                column.Width = MyDataGrid2.Width / MyDataGrid2.Columns.Count;
            }
        }

        private void LaptopTab_Loaded(object sender, RoutedEventArgs e)
        {
            // Connect to the MySQL database
            string query = "SELECT COUNT(*) FROM gestiune WHERE CATEGORIE = 'LAPTOP'";

            using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    CountLaptops.Text = $"{count} Laptopuri";
                }

                connection.Close();
            }
        }

        private void DocButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime currentDate = DateTime.Now.Date;
            string formattedDate = currentDate.ToString("dd.MM.yyyy");

            string nume = user.CurrentUserAccount.Name.ToString();
            string prenume = user.CurrentUserAccount.LastName.ToString();

            // Get the data item bound to the clicked row
            if (((FrameworkElement)sender).DataContext is DeviceModel selectedItem)
            {
                int ID = int.Parse(selectedItem.Column1);

                SelectedId = ID;

                string name = selectedItem.Column4;

                // Code to open PDFAssets/Contracte EON/Actual_Assist_Electric.pdf"
                string fileName = "Assets/IT/Proces_Verbal_de_primire_laptop.pdf";

                if (!File.Exists(fileName))
                {
                    // Handle the case when the file does not exist.
                    MessageBox.Show("The file does not exist.");
                    return;
                }

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{name}_Proces_Verbal_de_primire_laptop.pdf");

                using (PdfReader pdfReader = new PdfReader(fileName))
                using (FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
                using (PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream))
                {
                    AcroFields acroFields = pdfStamper.AcroFields;
                    acroFields.SetField("Data", formattedDate);
                    acroFields.SetField("Reprezentant", nume + " " + prenume);
                    acroFields.SetField("Reprezentant2", nume + " " + prenume);
                    acroFields.SetField("NumeAgent", selectedItem.Column4);
                    acroFields.SetField("NumeAgent2", selectedItem.Column4);
                    acroFields.SetField("SerialNumber", selectedItem.Column3);
                    acroFields.SetField("TipLaptop", selectedItem.Column2);
                }

                // Show message box to confirm that PDF was saved
                // Display the username in the Prompt
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Success";
                    dialog.Status.Text = "PDF-ul a fost creat cu succes";
                    dialog.Descriere.Text = "Apasă butonul de mai jos pentru a deschide PDF-ul";
                };
                dialog.ShowDialog();

                // Code to open the saved PDF file
                Process.Start(newFileName);
            }
        }

        private void UnitatiTab_Loaded(object sender, RoutedEventArgs e)
        {
            // Connect to the MySQL database
            string query = "SELECT COUNT(*) FROM gestiune WHERE CATEGORIE = 'UNITATE'";

            using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    CountUnitati.Text = $"{count} Unitati";
                }

                connection.Close();
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;

            if (e.Delta > 0)
            {
                // Scroll up
                scrollViewer.LineUp();
            }
            else
            {
                // Scroll down
                scrollViewer.LineDown();
            }

            // Prevent the event from being handled by parent controls
            e.Handled = true;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            LoadData();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            LoadData();
        }

        public class MyData
        {
            public string Column1 { get; set; }

            public string Column2 { get; set; }

            public string Column3 { get; set; }

            public string Column4 { get; set; }

            public string Column5 { get; set; }

            public string Column6 { get; set; }

            public string Column7 { get; set; }

            public string Column8 { get; set; }

            public string Column9 { get; set; }

            public string Column10 { get; set; }

            public string Column11 { get; set; }

            public string Column12 { get; set; }

            public string Column13 { get; set; }
        }
    }
}

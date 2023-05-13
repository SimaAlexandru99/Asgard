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

namespace Asgard.Pages
{


    /// <summary>
    /// Interaction logic for Gestiune.xaml
    /// </summary>
    public partial class Gestiune : Page
    {
        public MainViewModel user;

        public ObservableCollection<DeviceModel> _myDataList;

        public ObservableCollection<DeviceModel2> _myDataList2;

        // Declare a variable to store the ID value of the selected row
        public int selectedId;
        public string selectedCategory;
        private string selectedMouse;
        private string selectedTastatura;
        private string selectedCasti;


        public Gestiune()
        {
            InitializeComponent();

            user = new MainViewModel();


        }


        // START Laptop Category //



        public void LoadData()
        {
            var connection = RepositoryBase.GetConnectionPublic();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ID, MODEL, SERIE, AGENT, ANYDESK, STATUS, STARE, CATEGORIE, MOUSE, TASTATURA, CASTI, LICENTA, INTERNET FROM gestiune WHERE CATEGORIE = 'LAPTOP'";
            MySqlDataReader reader = command.ExecuteReader();

            _myDataList = new ObservableCollection<DeviceModel>();

            while (reader.Read())
            {
                _myDataList.Add(new DeviceModel { Column1 = reader[0].ToString(), Column2 = reader[1].ToString(), Column3 = reader[2].ToString(), Column4 = reader[3].ToString(), Column5 = reader[4].ToString(), Column6 = reader[5].ToString(), Column7 = reader[6].ToString(), Column8 = reader[7].ToString(), Column9 = reader[8].ToString(), Column10 = reader[9].ToString(), Column11 = reader[10].ToString(), Column12 = reader[11].ToString(), Column13 = reader[12].ToString() });
            }

            MyDataGrid.ItemsSource = _myDataList;
            connection.Close();

            connection.Open();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "SELECT ID, MODEL, SERIE, AGENT, ANYDESK, STATUS, STARE, CATEGORIE, MOUSE, TASTATURA, CASTI, LICENTA, INTERNET FROM gestiune WHERE CATEGORIE = 'UNITATE'";

            MySqlDataReader reader2 = command2.ExecuteReader();

            _myDataList2 = new ObservableCollection<DeviceModel2>();

            while (reader2.Read())
            {
                _myDataList2.Add(new DeviceModel2 { Column1 = reader2[0].ToString(), Column2 = reader2[1].ToString(), Column3 = reader2[2].ToString(), Column4 = reader2[3].ToString(), Column5 = reader2[4].ToString(), Column6 = reader2[5].ToString(), Column7 = reader2[6].ToString(), Column8 = reader2[7].ToString(), Column9 = reader2[8].ToString(), Column10 = reader2[9].ToString(), Column11 = reader2[10].ToString(), Column12 = reader2[11].ToString(), Column13 = reader2[12].ToString() });
            }

            // Check if MyDataGrid2 is null before using it
            MyDataGrid2.ItemsSource = _myDataList2;


            connection.Close();


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






        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the data item bound to the clicked row
            var selectedItem = ((FrameworkElement)sender).DataContext as DeviceModel;

            var ID = int.Parse(selectedItem.Column1);

            // Store the ID value in a variable
            selectedId = ID;

            selectedCategory = selectedItem.Column8;

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




                edit.Closing += Refresh_Closing;
                // Open the popup
                edit.Show();


            }
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
            string searchText = SearchBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MyDataGrid.ItemsSource = _myDataList;

            }
            else
            {
                MyDataGrid.ItemsSource = _myDataList.Where(item => item.Column1.ToLower().Contains(searchText) || item.Column2.ToLower().Contains(searchText) || item.Column3.ToLower().Contains(searchText) || item.Column4.ToLower().Contains(searchText) || item.Column5.ToLower().Contains(searchText) || item.Column6.ToLower().Contains(searchText));

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
            // Bind the DataGrid to the MySQL database
            LoadData();


            // Connect to the MySQL database

            string connectionString = "datasource=192.168.100.18;port=3306;username=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";

            string query = "SELECT COUNT(*) FROM gestiune WHERE CATEGORIE = 'LAPTOP'";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

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
            var selectedItem = ((FrameworkElement)sender).DataContext as DeviceModel;

            if (selectedItem != null)
            {
                int ID = int.Parse(selectedItem.Column1);

                selectedId = ID;

                string name = selectedItem.Column4;

                // Code to open PDFAssets/Contracte EON/Actual_Assist_Electric.pdf"
                string fileName = "Assets/IT/Proces_Verbal_de_primire_laptop.pdf";
                PdfReader pdfReader = new PdfReader(fileName);

                // Code to save PDF with a modified name
                string newFileName = Path.Combine(Path.GetDirectoryName(fileName), $"{name}_Proces_Verbal_de_primire_laptop.pdf");
                FileStream fileStream = new FileStream(newFileName, FileMode.Create, FileAccess.Write);

                // Code to modify PDF fields
                PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
                AcroFields acroFields = pdfStamper.AcroFields;
                acroFields.SetField("Data", formattedDate);
                acroFields.SetField("Reprezentant", nume + " " + prenume);
                acroFields.SetField("Reprezentant2", nume + " " + prenume);
                acroFields.SetField("NumeAgent", selectedItem.Column4);
                acroFields.SetField("NumeAgent2", selectedItem.Column4);
                acroFields.SetField("SerialNumber", selectedItem.Column3);
                acroFields.SetField("TipLaptop", selectedItem.Column2);
                pdfStamper.Close();


                // Show message box to confirm that PDF was saved
                // Display the username in the Prompt
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Succes";
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
            // Bind the DataGrid to the MySQL database
            LoadData();


            // Connect to the MySQL database

            string connectionString = "datasource=192.168.100.18;port=3306;username=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";

            string query = "SELECT COUNT(*) FROM gestiune WHERE CATEGORIE = 'UNITATE'";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

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


    }


}

// <copyright file="UpdateDeviceWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.CustomControls
{
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;
    using Asgard.Pages;
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for UpdateDeviceWindow.xaml.
    /// </summary>
    public partial class UpdateDeviceWindow : Window
    {
        public UpdateDeviceWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var gestiune = new Gestiune();

            // Connect to the MySQL database
            var connection = RepositoryBase.GetConnectionPublic();

            try
            {
                // Create an UPDATE statement
                string sql = "UPDATE gestiune SET MODEL=@MODEL, SERIE=@SERIE, AGENT=@AGENT, ANYDESK=@ANYDESK, STATUS=@STATUS, STARE =@STARE, CATEGORIE =@CATEGORIE, MOUSE =@MOUSE, TASTATURA =@TASTATURA, CASTI =@CASTI, LICENTA = @LICENTA INTERNET=@INTERNET WHERE SERIE=@SERIE";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                // Set the parameter values
                cmd.Parameters.AddWithValue("@ID", gestiune.SelectedId);
                cmd.Parameters.AddWithValue("@MODEL", ModelTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@SERIE", SerieTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@AGENT", AgentTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@ANYDESK", AnydeskTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@STATUS", StatusTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@STARE", StareTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@CATEGORIE", CategorieTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@MOUSE", MouseTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@TASTATURA", TastaturaTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@CASTI", CastiTextBoxAdd.Text);
                cmd.Parameters.AddWithValue("@LICENTA", LicentaAdd.Text);
                cmd.Parameters.AddWithValue("@INTERNET", Internet.Text);

                // Execute the UPDATE statement
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Dispozitivul nu a fost actualizat";
                    dialog.Descriere.Text = "Dispozitivul tău nu a putut fi actualizat." + ex.Message;
                };
                dialog.ShowDialog();
            }
            finally
            {
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Succes";
                    dialog.Status.Text = "Dispozitivul a fost actualizat";
                    dialog.Descriere.Text = "Dispozitivul tău poate fi vizualizat în pagina anterioară.";
                };
                dialog.ShowDialog();

                // Close the connection
                connection.Close();
            }

            connection.Open();

            string sql2 = "INSERT INTO log_gestiune (SERIE, AGENT) VALUES (@SERIE, @AGENT)";
            MySqlCommand command = new MySqlCommand(sql2, connection);

            // set the parameter values
            command.Parameters.AddWithValue("@SERIE", SerieTextBoxAdd.Text);
            command.Parameters.AddWithValue("@AGENT", AgentTextBoxAdd.Text);

            // execute the command
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();

            Close();
        }

        private void MyDataGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void Cell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string filter = SerieTextBoxAdd.Text;
            MySqlConnection connection = null;

            try
            {
                connection = RepositoryBase.GetConnectionPublic();
                string query = "SELECT * FROM log_gestiune WHERE SERIE LIKE @filter";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filter + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                HistoryDatGrid.DataContext = table.DefaultView;

                DataView view = table.DefaultView;
                view.RowFilter = string.Format("SERIE LIKE '%{0}%'", filter);
            }
            catch (Exception)
            {
                // Handle any exceptions here
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Eroare";
                    dialog.Descriere.Text = "Eroare la filtru";
                };
                dialog.ShowDialog();
            }
            finally
            {
                connection?.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}

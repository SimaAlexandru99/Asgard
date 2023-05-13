using Asgard.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Input;

namespace Asgard.CustomControls
{
    /// <summary>
    /// Interaction logic for AddDeviceWindow.xaml
    /// </summary>
    public partial class AddDeviceWindow : Window
    {
        public AddDeviceWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelTextBoxAdd.Text == "" || SerieTextBoxAdd.Text == "" || AgentTextBoxAdd.Text == ""  || StatusTextBoxAdd.Text == "" || StareTextBoxAdd.Text == "" || CategorieTextBoxAdd.Text == "")
            {

                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Descriere.Text = "Nu ai completat toate câmpurile";
                };
                dialog.ShowDialog();

            }
            else
            {
                // Connect to the MySQL database
                var connection = RepositoryBase.GetConnectionPublic();

                try
                {
                    // Create an UPDATE statement
                    string sql = "INSERT INTO gestiune (ID, MODEL, SERIE, AGENT, ANYDESK, STATUS, STARE, CATEGORIE, MOUSE, TASTATURA, CASTI, LICENTA, INTERNET) " +
                         "VALUES (null, @MODEL, @SERIE, @AGENT, @ANYDESK, @STATUS, @STARE, @CATEGORIE, @MOUSE, @TASTATURA, @CASTI, @LICENTA, @INTERNET)";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // Set the parameter values
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




                    // Execute the ADD statement
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Prompt dialog = new Prompt();
                    dialog.Loaded += (s, ea) =>
                    {

                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Dispozitivul nu a fost adaugat";
                        dialog.Descriere.Text = "Dispozitivul tău nu a putut fi adaugat." + ex.Message;
                    };
                    dialog.ShowDialog();
                }
                finally
                {
                    Prompt dialog = new Prompt();
                    dialog.Loaded += (s, ea) =>
                    {

                        dialog.Title = "Succes";
                        dialog.Status.Text = "Dispozitivul a fost adăugat";
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

                // Close the popup without modifying the data
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

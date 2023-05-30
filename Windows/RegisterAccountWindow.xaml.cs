// <copyright file="RegisterAccountWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using Asgard.CustomControls;
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for RegisterAccountWindow.xaml.
    /// </summary>
    public partial class RegisterAccountWindow : Window
    {
        public RegisterAccountWindow()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            if (screenWidth >= 1920 && screenHeight >= 1080)
            {
                RegisterWindow.Width = 1000;
                RegisterWindow.Height = 600;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ButtonComeback_Click(object sender, RoutedEventArgs e)
        {
            var signin = new SignIn();
            signin.Show();

            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TopPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void ComboboxProiect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboboxProiect.SelectedItem;
            comboboxSubProiect.Items.Clear();
            comboboxTeamLeader.Items.Clear();
            switch (selectedItem.Content.ToString())
            {
                case "Vodafone":
                    comboboxSubProiect.Items.Add("Achizitie");
                    comboboxSubProiect.Items.Add("Retentie");
                    comboboxTeamLeader.Items.Add("Anca Alexandru");
                    comboboxTeamLeader.Items.Add("Paula Bilha");
                    comboboxTeamLeader.Items.Add("Madalina Aldea");
                    comboboxTeamLeader.Items.Add("Andrei Cristian");
                    comboboxTeamLeader.Items.Add("Camelia Grama");
                    comboboxTeamLeader.Items.Add("Cristina Ruxandar");
                    comboboxTeamLeader.Items.Add("Florin Dascalu");
                    comboboxTeamLeader.Items.Add("Andrei Preutescu");

                    break;
                case "Telekom":
                    comboboxSubProiect.Items.Add("Savedesk");
                    comboboxSubProiect.Items.Add("Antichurn");
                    comboboxSubProiect.Items.Add("TKRM");
                    comboboxTeamLeader.Items.Add("Mălina Șerbănoiu");
                    comboboxTeamLeader.Items.Add("Silvia Isaia");
                    comboboxTeamLeader.Items.Add("Ionut Călărășanu");

                    break;
                case "CEC":
                    comboboxTeamLeader.Items.Add("Simona Scutaru");
                    break;
                case "EON":
                    comboboxTeamLeader.Items.Add("Simona Scutaru");
                    break;
                case "Orange":
                    comboboxTeamLeader.Items.Add("Constantin Rusu");
                    break;
            }
        }

        private void ComboboxSubProiect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string status = "Offline";
            string newPassword = parolaNoua.Password;
            string confirmNewPassword = parolaConfirm.Password;
            string departament = "-";
            string subproiect = "-";
            string idbria = "-";
            string quality = "-";

            // Check if the required fields are empty or if passwords do not match
            if (string.IsNullOrWhiteSpace(txtNume.Text) ||
                string.IsNullOrWhiteSpace(txtPrenume.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmNewPassword) ||
                newPassword != confirmNewPassword)
            {
                // Show a dialog message instead of writing to the console
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Te rog completează toate câmpurile";
                    dialog.Descriere.Text = "Nu ai completat toate câmpurile, te rog sa revi și să completezi tot.";
                };
                dialog.ShowDialog();
                return;
            }

            // Extract the domain name from the email address
            string email = Email.Text.Trim();
            int atIndex = email.IndexOf('@');
            string domain = email.Substring(atIndex + 1);

            // Check if the domain is equal to "optimacall.ro"
            if (domain != "optimacall.ro")
            {
                // Show a dialog message instead of writing to the console
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Email-ul nu este corect";
                    dialog.Descriere.Text = "Email ul nu are particularitatea optimacall.ro";
                };
                dialog.ShowDialog();
                return;
            }

            try
            {
                using (var connection = RepositoryBase.GetConnectionPublic())
                {
                    // Extract the username from the email address
                    string username = email.Substring(0, atIndex);

                    // Check if the email already exists in the table
                    bool emailExists = CheckIfEmailExists(connection, email);

                    if (emailExists)
                    {
                        // Display an error message or take appropriate action
                        Prompt dialog = new Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Email-ul există deja";
                            dialog.Descriere.Text = "Adresa de email " + Email.Text + " există deja în sistem. Te rog să introduci o altă adresă de email sau să te loghezi";
                        };
                        dialog.ShowDialog();
                        return;
                    }

                    // Determine the appropriate SQL query based on comboboxProiect.Text value
                    string query;
                    if (comboboxProiect.Text == "Vodafone" || comboboxProiect.Text == "Telekom")
                    {
                        query = "INSERT INTO users (ID, Username, Email, Nume, Prenume, Password, Proiect, Subproiect, Departament, TeamLeader, Quality, ID_Bria, Status) " +
                                "VALUES (NULL, @Username, @Email, @Nume, @Prenume, @Password, @Proiect, @Subproiect, @Departament, @TeamLeader, @Quality, @ID_Bria, @Status)";
                        subproiect = comboboxSubProiect.Text;
                    }
                    else
                    {
                        query = "INSERT INTO users (ID, Username, Email, Nume, Prenume, Password, Proiect, Subproiect, Departament, TeamLeader, Quality, ID_Bria, Status) " +
                                "VALUES (NULL, @Username, @Email, @Nume, @Prenume, @Password, @Proiect, @Subproiect, @Departament, @TeamLeader, @Quality, @ID_Bria, @Status)";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Set parameter values
                        command.Parameters.Add("@Username", MySqlDbType.VarChar).Value = username;
                        command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = email;
                        command.Parameters.Add("@Nume", MySqlDbType.VarChar).Value = txtNume.Text;
                        command.Parameters.Add("@Prenume", MySqlDbType.VarChar).Value = txtPrenume.Text;
                        command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = newPassword;
                        command.Parameters.Add("@Proiect", MySqlDbType.VarChar).Value = comboboxProiect.Text;
                        command.Parameters.Add("@Subproiect", MySqlDbType.VarChar).Value = subproiect;
                        command.Parameters.Add("@Departament", MySqlDbType.VarChar).Value = departament; // TODO: Add departament combobox
                        command.Parameters.Add("@TeamLeader", MySqlDbType.VarChar).Value = comboboxTeamLeader.Text;
                        command.Parameters.Add("@Quality", MySqlDbType.VarChar).Value = quality;
                        command.Parameters.Add("@ID_Bria", MySqlDbType.VarChar).Value = idbria;
                        command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = status;

                        int rowsAffected = command.ExecuteNonQuery();

                        // Show a dialog message instead of writing to the console
                        Prompt dialog = new Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Success";
                            dialog.Status.Text = "User creat";
                            dialog.Descriere.Text = "User-ul " + username + " a fost creat cu succes. Întoarce-te la pagina de logare pentru a te loga în cont";
                        };
                        dialog.ShowDialog();
                    }

                    // Close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Show a dialog message with the error details
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Contul nu a fost creat";
                    dialog.Descriere.Text = "A intervenit o eroare: " + ex.Message;
                };
                dialog.ShowDialog();
            }
        }

        private bool CheckIfEmailExists(MySqlConnection connection, string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE Email = @Email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = email;
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = Email.Text.Trim();

            // Implement your logic to check if the email exists in the table
            bool emailExists = CheckIfEmailExists(email);

            if (emailExists)
            {
                // Display an error message or take appropriate action
                // Show a dialog message with the error details
                Prompt dialog = new Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Acest email există deja";
                    dialog.Descriere.Text = "Adresa de email pe care vrei să o folosești există deja în baza de date.";
                };
                dialog.ShowDialog();
            }
        }

        private bool CheckIfEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @Email";

            try
            {
                using (var connection = RepositoryBase.GetConnectionPublic())
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Handle the exception (e.g., log, display error message, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // or throw an exception if desired
            }
        }
    }
}

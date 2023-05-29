// <copyright file="RegisterAccountWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;

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
            string nume = txtNume.Text;
            string username = (txtNume.Text + "." + txtPrenume.Text).ToLower();
            string prenume = txtPrenume.Text;
            string email = Email.Text;
            string proiect = comboboxProiect.Text;
            string subProiect = comboboxSubProiect.Text;
            string teamLeader = comboboxTeamLeader.Text;
            string newPassword = parolaNoua.Password;
            string confirmPassword = parolaConfirm.Password;

            if (!string.IsNullOrEmpty(nume) && !string.IsNullOrEmpty(prenume) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(proiect) && !string.IsNullOrEmpty(teamLeader) && newPassword == confirmPassword)
            {
                try
                {
                    using (var connection = RepositoryBase.GetConnectionPublic())
                    {
                        string sql;
                        MySqlCommand command = new MySqlCommand();

                        if (proiect != "Vodafone" && proiect != "Telekom")
                        {
                            sql = "INSERT INTO users (Password, Username, Email, Proiect, TeamLeader) VALUES (@NewPassword, @Username, @Email, @Proiect, @TeamLeader)";
                            command.Parameters.AddWithValue("@Proiect", proiect);
                        }
                        else
                        {
                            sql = "INSERT INTO users (Password, Username, Email, Proiect, Subproiect, TeamLeader) VALUES (@NewPassword, @Username, @Email, @Proiect, @Subproiect, @TeamLeader)";
                            command.Parameters.AddWithValue("@Proiect", proiect);
                            command.Parameters.AddWithValue("@Subproiect", subProiect);
                        }

                        command.CommandText = sql;
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@TeamLeader", teamLeader);

                        command.ExecuteNonQuery();
                    }

                    // Handle successful database operation or perform any additional logic here
                }
                catch (Exception ex)
                {
                    // Handle the exception or display an error message
                    Console.WriteLine("An error occurred while executing the database operation: " + ex.Message);
                }
            }
        }

    }
}

// <copyright file="RecoverPasswordWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// </summary>
    public partial class RecoverPasswordWindow : Window
    {
        // int count = 0;
        public RecoverPasswordWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            // Get the current screen resolution
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Set the window size based on the screen resolution
            Width = screenWidth * 0.3; // set the width to 80% of the screen width
            Height = screenHeight * 0.4; // set the height to 80% of the screen height
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;

            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ticketReset.Text == "Parola")
            {
                string username = txtUser.Text;
                string newPassword = parolaNoua.Password;
                string confirmPassword = parolaConfirm.Password;

                string sql = "UPDATE users SET Password=@NewPassword WHERE Username=@Username";

                if (username != null && newPassword == confirmPassword)
                {
                    using (var connection = RepositoryBase.GetConnectionPublic())
                    {
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            // Display the username in the Prompt
                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Succes";
                                dialog.Status.Text = "Parola a fost resetată";
                                dialog.Descriere.Text = "Ai resetat parola cu succes, revino la pagina de logare și intră în cont cu noua parolă";
                            };
                            dialog.ShowDialog();
                        }
                        else
                        {
                            // Display the username in the Prompt
                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Eroare";
                                dialog.Status.Text = "Parola nu a fost resetată";
                                dialog.Descriere.Text = "Nu ai băgat username-ul corect, te rog sa reîncerci";
                            };
                            dialog.ShowDialog();
                        }
                    }
                }
                else if (username != null && newPassword != confirmPassword)
                {
                    // Display the username in the Prompt
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Parola nu a fost resetată";
                        dialog.Descriere.Text = "Parolele nu coincid, te rog sa mai încerci";
                    };
                    dialog.ShowDialog();
                }
                else if (username == null && newPassword == confirmPassword)
                {
                    // Display the username in the Prompt
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Parola nu a fost resetată";
                        dialog.Descriere.Text = "Te rog să introduci username-ul pentru a putea reseta parola.";
                    };
                    dialog.ShowDialog();
                }
            }
            else if (ticketReset.Text == "Username")
            {
                // Define the user's email
                string userEmail = txtUser2.Text;

                // Define a variable to store the username
                string userName = string.Empty;

                // Retrieve a database connection object
                using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
                {
                    // Define the SQL query to retrieve the username based on the email
                    string query = "SELECT Username FROM users WHERE Email = @Email";

                    // Create a MySqlCommand object to execute the query
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add the user's email as a parameter to the query
                        command.Parameters.AddWithValue("@Email", userEmail);

                        // Execute the query and retrieve the username
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userName = reader.GetString(0);
                            }
                        }
                    }
                }

                // Check if a username was found for the given email
                if (!string.IsNullOrEmpty(userName))
                {
                    // Display the username in the Prompt
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "Username-ul pentru adresa de email " + userEmail + " este " + userName;
                    };
                    dialog.ShowDialog();
                }
                else
                {
                    // Display the username in the Prompt
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Informare";
                        dialog.Status.Text = "Informare";
                        dialog.Descriere.Text = "Nu a fost găsită nicio adresa de email " + userEmail;
                    };
                    dialog.ShowDialog();
                }
            }
        }

        private void RevinoBtn_Click(object sender, RoutedEventArgs e)
        {
            var loginwindow = new SignIn();
            loginwindow.Show();

            this.Close();
        }

        private void TopPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
    }
}

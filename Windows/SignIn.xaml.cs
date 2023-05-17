// <copyright file="SignIn.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using Asgard.CustomControls;
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for SignIn.xaml.
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            if (screenWidth >= 1920 && screenHeight >= 1080)
            {
                SignInPage.Width = 1000;
                SignInPage.Height = 600;
                TextAboutAccount.FontSize = 12;
                CreeazaCont.FontSize = 12;
                loginBtn.Height = 50;

                txtUser.Height = 40;
                txtPassword.Height = 40;
            }
            else if (screenWidth <= 1366 && screenHeight <= 768)
            {
                // Set the size for lower-resolution displays
                SignInPage.Width = 700;
                SignInPage.Height = 500;
                TextAboutAccount.FontSize = 8;
                CreeazaCont.FontSize = 8;
            }
            else
            {
                // Set the default size for lower-resolution displays
                SignInPage.Width = 700;
                SignInPage.Height = 500;
                TextAboutAccount.FontSize = 8;
                CreeazaCont.FontSize = 8;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            // Create an instance of the window you want to open
            RecoverPasswordWindow recoverPassword = new RecoverPasswordWindow();

            // Show the window
            recoverPassword.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resetwindow = new RecoverPasswordWindow();
            resetwindow.Show();

            Close();
        }

        private void WindowLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get the Windows system user name
            string userNameToCheck = WindowsIdentity.GetCurrent().Name;

            // Create a connection to the MySQL database
            using (var connection = RepositoryBase.GetConnectionPublic())
            {
                // Check if the user exists
                string query = $"SELECT COUNT(*) FROM users WHERE Username='{userNameToCheck}'";
                MySqlCommand command = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    var primarywindow = new PrimaryWindow();
                    primarywindow.Show();

                    Close();
                }
                else
                {
                    // Display the username in the Prompt
                    Prompt dialog = new Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Contul nu există";
                        dialog.Descriere.Text = "Contul acesta nu există";
                    };
                    dialog.ShowDialog();
                }

                connection.Close();
            }
        }

        private void TopPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void CreeazaCont_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

// <copyright file="RecoverPasswordWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using System.Security.Authentication;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Asgard.Repositories;
    using Asgard.ViewModels;
    using MailKit;
    using MailKit.Net.Smtp;
    using MimeKit;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// </summary>
    public partial class RecoverPasswordWindow : Window
    {
        string userpassword;
        // int count = 0;
        public RecoverPasswordWindow()
        {

            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            // Get the current screen resolution
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            if (screenWidth >= 1920 && screenHeight >= 1080)
            {
                RecoverPassword.Width = 1000;
                RecoverPassword.Height = 600;
                Button.Height = 50;
                Button.Width = 400;
                Button.FontSize = 12;
                ForgotPasswordRadioButton.Height = 70;
                ForgotPasswordRadioButton.Width = 400;
                ForgotUsernameRadioButton.Height = 70;
                ForgotUsernameRadioButton.Width = 400;
                TextIForgetPassword.FontSize = 16;
                TextIForgetUsername.FontSize = 16;
                TextIForgetPasswordHelper.FontSize = 10;
                TextIForgetUsernameHelper.FontSize = 10;

                CheckPassword.Height = 15;
                CheckPassword.Width = 15;

                CheckUsername.Height = 15;
                CheckUsername.Width = 15;

                Header.FontSize = 35;
                Header2.FontSize = 35;
                Header3.FontSize = 35;
                Subheading.FontSize = 15;
                Subheading2.FontSize = 15;
                Subheading3.FontSize = 15;

                txtUser.Height = 40;
                txtUser2.Height = 40;
               

                TextComeBack.FontSize = 10;
                ButtonComeback.FontSize = 10;
            }
            else if (screenWidth <= 1366 && screenHeight <= 768)
            {
                // Set the size for lower-resolution displays
                RecoverPassword.Width = 800;
                RecoverPassword.Height = 500;
            }
            else
            {
                // Set the default size for lower-resolution displays
                RecoverPassword.Width = 800;
                RecoverPassword.Height = 500;
            }
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

        private void ForgotPasswordRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            PasswordImage.Source = new BitmapImage(new Uri("/Assets/Icons/keyselected.png", UriKind.Relative));
            CheckPassword.Source = new BitmapImage(new Uri("/Assets/Icons/checked.png", UriKind.Relative));
        }

        private void ForgotPasswordRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordImage.Source = new BitmapImage(new Uri("/Assets/Icons/keynoselected.png", UriKind.Relative));
            CheckPassword.Source = new BitmapImage(new Uri("/Assets/Icons/unchecked.png", UriKind.Relative));
        }

        private void ForgotUsernameRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UserImage.Source = new BitmapImage(new Uri("/Assets/Icons/userselected.png", UriKind.Relative));
            CheckUsername.Source = new BitmapImage(new Uri("/Assets/Icons/checked.png", UriKind.Relative));
        }

        private void ForgotUsernameRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            UserImage.Source = new BitmapImage(new Uri("/Assets/Icons/usernoselected.png", UriKind.Relative));
            CheckUsername.Source = new BitmapImage(new Uri("/Assets/Icons/unchecked.png", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Panel1.Visibility == Visibility.Visible)
            {
                if (ForgotPasswordRadioButton.IsChecked == true)
                {
                    Panel1.Visibility = Visibility.Collapsed;
                    Panel2.Visibility = Visibility.Visible;
                    Button.Content = "Recuperează parola";
                }
                else if (ForgotUsernameRadioButton.IsChecked == true)
                {
                    Panel1.Visibility = Visibility.Collapsed;
                    Panel3.Visibility = Visibility.Visible;
                    Button.Content = "Află nume de utilizator";
                }

                Indicator.Background = new SolidColorBrush(Color.FromRgb(217, 217, 217));
                Indicator2.Background = new SolidColorBrush(Color.FromRgb(0, 127, 255));
            }
            else if (Panel2.Visibility == Visibility.Visible)
            {
                string username = txtUser.Text;

                string emailAddress = "asgard@optimacall.ro";
                string password = "Optima#321";
                MimeMessage message = new MimeMessage
                {
                    Subject = "Resetare parola ASGARD ",
                };
                message.From.Add(new MailboxAddress("ASGARD", "asgard@optimacall.ro"));
                message.To.Add(MailboxAddress.Parse(username));
                string query = "SELECT Password FROM users WHERE Email = @Email";
                using (MySqlConnection connection = RepositoryBase.GetConnectionPublic())
                {

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userpassword = reader.GetString(0);
                                // Use the retrieved password to send the email or perform other operations
                            }
                            else
                            {
                                // Handle the case when the user email is not found in the database
                            }
                        }
                    }
                }
                if (username != string.Empty && username.Contains("@optimacall.ro"))
                {
                  

                    message.Body = new TextPart("plain")
                    {
                        Text = @"Salut," + "\r\n" + "\r\n" + "Parola aferanta contului tau este: " + userpassword + "\r\n" + "\r\n" + "O zi buna," + "\r\n" + "Echipa ASGARD",
                    
                    };
                    SmtpClient client = new SmtpClient(new ProtocolLogger("imap.log"));
                    try
                    {
                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = Mail.MySslCertificateValidationCallback;
                        client.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Ssl2 | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                        client.Connect("zmail.optimacall.ro", 465, true);
                        client.Authenticate(emailAddress, password);
                        client.Send(message);
                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Succes";
                            dialog.Status.Text = "Parola a fost trimisa cu succes.";
                            dialog.Descriere.Text = "Urmeaza sa primesti parola pe adresa de mail completata mai sus.";
                        };
                        dialog.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        CustomControls.Prompt dialog = new CustomControls.Prompt();
                        dialog.Loaded += (s, ea) =>
                        {
                            dialog.Title = "Eroare";
                            dialog.Status.Text = "Mail-ul nu a fost trimis";
                            dialog.Descriere.Text = "Nu am gasit nici un cont aferent adresei de email completate de tine. Te rog sa iei legatura cu departamentul IT.";
                        };
                        dialog.ShowDialog();
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }

                }
                else if(username == string.Empty || !username.Contains("@optimacall.ro"))
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Mail-ul nu a fost trimis";
                        dialog.Descriere.Text = "Nu am putut trimite un mail cu parola, este necesar sa folosesti o adresa de mail de genul exemplu@optimacall.ro.";
                    };
                    dialog.ShowDialog();
                }

            }
            else if (Panel3.Visibility == Visibility.Visible)
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

        private void Indicator_Click(object sender, RoutedEventArgs e)
        {
            if (Panel1.Visibility == Visibility.Visible)
            {
            }
            else if (Panel2.Visibility == Visibility.Visible)
            {
                Panel2.Visibility = Visibility.Collapsed;
                Panel1.Visibility = Visibility.Visible;
                Button.Content = "Mai departe";
            }
            else if (Panel3.Visibility == Visibility.Visible)
            {
                Panel3.Visibility = Visibility.Collapsed;
                Panel1.Visibility = Visibility.Visible;
                Button.Content = "Mai departe";
            }

            Indicator.Background = new SolidColorBrush(Color.FromRgb(0, 127, 255));
            Indicator2.Background = new SolidColorBrush(Color.FromRgb(217, 217, 217));
        }

        private void Indicator2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonComeback_Click(object sender, RoutedEventArgs e)
        {
            var signin = new SignIn();
            signin.Show();

            Close();
        }
    }
}

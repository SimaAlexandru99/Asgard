﻿using Asgard.Repositories;
using Asgard.Themes;
using Asgard.ViewModels;
using Asgard.Windows;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Asgard
{
    /// <summary>
    /// Interaction logic for PrimaryWindowVodafone.xaml
    /// </summary>
    public partial class PrimaryWindow : Window
    {

        public MainViewModel user;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Define three ICommand properties for minimizing, maximizing, and closing the window
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public PrimaryWindow()
        {
            InitializeComponent();


            // Access the Windows identity from the DataContext

            // Do something with the Windows identity
            if (DataContext is WindowsIdentity identity)
            {
                // Get the Windows user token
                IntPtr userToken = identity.Token;
            }



            user = new MainViewModel();
            Style = (Style)FindResource("CustomWindowStyle");
            DataContext = this;

            MinimizeCommand = new Commands.RelayCommand(Minimize);
            MaximizeCommand = new Commands.RelayCommand(Maximize);
            CloseCommand = new Commands.RelayCommand(Close);
            // Get the current screen resolution
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Set the window size based on the screen resolution
            this.Width = screenWidth * 0.7; // set the width to 80% of the screen width
            this.Height = screenHeight * 0.7; // set the height to 80% of the screen height

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            Main.Content = new Pages.FrontPage();

        }

        private void Minimize()
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize()
        {
            WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        new void Close()
        {

            string username = user.CurrentUserAccount.Username.ToString();

            // Set Status to Offline
            using (var connection = RepositoryBase.GetConnectionPublic())
            using (var command = new MySqlCommand("UPDATE users SET Status = 'Offline' WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
            }

            // Close App
            Application.Current.Shutdown();

        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the left mouse button is pressed
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                // Start dragging the window
                this.DragMove();
            }
        }


        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                /*MaximizeIcon.Kind = MahApps.Metro.IconPacks.PackIconBoxIconsKind.RegularCopy;*/

            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                /*MaximizeIcon.Kind = MahApps.Metro.IconPacks.PackIconBoxIconsKind.RegularSquareRounded;*/
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            string username = user.CurrentUserAccount.Username.ToString();

            // Set Status to Offline
            using (var connection = RepositoryBase.GetConnectionPublic())
            using (var command = new MySqlCommand("UPDATE users SET Status = 'Offline' WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
            }

            // Close App
            Application.Current.Shutdown();

        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                /*MaximizeIcon.Kind = MahApps.Metro.IconPacks.PackIconBoxIconsKind.RegularSquareRounded;*/

            }
            else if (this.WindowState == WindowState.Maximized)
            {
                /*MaximizeIcon.Kind = MahApps.Metro.IconPacks.PackIconBoxIconsKind.RegularCopy;*/
            }
        }

        private void ProfileLetter_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            ProfileLetter.Text = ProfileLetter.Text.ToUpper();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            string username = user.CurrentUserAccount.Username.ToString();

            // Set Status to Offline
            using (var connection = RepositoryBase.GetConnectionPublic())
            using (var command = new MySqlCommand("UPDATE users SET Status = 'Offline' WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
            }

            Close();

            // Open LoginWindow
            SignIn loginWindow = new SignIn();
            loginWindow.Show();




        }

        private void TogglePopupButton_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = !myPopup.IsOpen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string username = user.CurrentUserAccount.Username;
            string displayname = user.CurrentUserAccount.DisplayName;
            string email = user.CurrentUserAccount.Email;
            string proiect = user.CurrentUserAccount.Proiect;

            int rows_count = 0;

            using (var connection = RepositoryBase.GetConnectionPublic())
            {
                using (var command = new MySqlCommand("SELECT COUNT(Status) FROM users WHERE Status='Online' AND Username <> @Username;", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    rows_count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            CountFriendsOnline.Text = rows_count.ToString();
            ProfileLetter.Text = displayname.ToUpper();
            UsernameText.Text = email;
            ProjectText.Text = proiect;

            GestiuneButton.Visibility = (proiect == "IT") ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ButtonTickete_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new Pages.TicketsPage());
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.FrontPage();
        }

        private void ButtonLearning_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.ComingSoon();
        }

        private void JoburiButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.ComingSoon();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.ComingSoon();
        }

        private void GestiuneButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Gestiune();
        }

        private void DarkLightToggle_Click(object sender, RoutedEventArgs e)
        {
            IBaseTheme baseTheme;
            Uri themeUri;
            BitmapImage logo;

            if (DarkLightToggle.IsChecked == true)
            {
                baseTheme = new MaterialDesignDarkTheme();
                themeUri = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                logo = new BitmapImage(new Uri("pack://application:,,,/Assets/AsgardLogoWhiteBorders.png"));
            }
            else
            {
                baseTheme = new MaterialDesignLightTheme();
                themeUri = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                logo = new BitmapImage(new Uri("pack://application:,,,/Assets/AsgardLogoBlackBorders.png"));
            }

            ThemesController.ChangeTheme(themeUri);
            logoImage.Source = logo;

        }
    }
}
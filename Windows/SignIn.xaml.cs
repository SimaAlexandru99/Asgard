using Asgard.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;


namespace Asgard.Windows
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            // Get the current screen resolution
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Set the window size based on the screen resolution
            Width = screenWidth * 0.4; // set the width to 80% of the screen width
            Height = screenHeight * 0.5; // set the height to 80% of the screen height

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


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
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
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
    }
}

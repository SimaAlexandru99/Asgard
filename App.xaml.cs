// <copyright file="App.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Asgard.CustomControls;
    using Asgard.Repositories;
    using Asgard.Windows;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new SignIn();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    Windows.SplashScreen splash = new Windows.SplashScreen();
                    splash.Show();
                    loginView.Close();
                }
            };

            // Subscribe to the SessionEnding event
            SessionEnding += App_SessionEnding;
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Start a new task to check the connection in the background
            Task<bool> checkConnectionTask = CheckConnectionAsync();

            // Delay execution for 3 seconds
            Task timeoutTask = Task.Delay(5000);

            // Wait for either the connection check or the timeout to complete
            Task completedTask = await Task.WhenAny(checkConnectionTask, timeoutTask);

            // Check if the connection check completed before the timeout
            if (completedTask == checkConnectionTask)
            {
                bool isConnected = await checkConnectionTask;

                // Connection check completed, show the dialog
                ShowConnectionDialog(isConnected);

                // Perform remaining startup logic...
            }
            else
            {
                // Timeout occurred, show the dialog with timeout message
                ShowConnectionDialog(false);
            }
        }

        private void ShowConnectionDialog(bool isConnected)
        {
            // Create a new dialog window
            Notifications notifications = new Notifications();
            notifications.Loaded += async (s, ea) =>
            {
                // Get the SlideInAnimation storyboard from the window resources
                Storyboard slideInAnimation = notifications.Resources["SlideInAnimation"] as Storyboard;

                // Begin the slide-in animation
                slideInAnimation.Begin();

                // Delay for 3 seconds before closing the dialog
                await Task.Delay(3000);

                // Get the SlideOutAnimation storyboard from the window resources
                Storyboard slideOutAnimation = notifications.Resources["SlideOutAnimation"] as Storyboard;

                // Set a fixed duration for the slide-out animation
                TimeSpan slideOutDuration = TimeSpan.FromSeconds(0.8);
                slideOutAnimation.Duration = slideOutDuration;

                // Begin the slide-out animation
                slideOutAnimation.Begin();

                // Delay for the duration of the slide-out animation
                await Task.Delay(slideOutDuration);

                // Close the dialog
                notifications.Close();
            };

            // Set dialog message based on the connection status
            notifications.Title.Text = isConnected ? "CONEXIUNE DISPONIBILĂ: Te poți loga la Asgard" : "PROBLEME LA CONEXIUNE:  Verifică conexiunea la VPN";

            // Set dialog message based on the connection status
            notifications.Description.Text = isConnected ? "Conexiunea la VPN este disponibilă, tot ce-ți rămâne de făcut este să-ți introduci datele de logare!" : "Dacă nu te poți conecta la Asgard, există posibilitatea să nu te fi conectat la VPN Optima, intră în FortiClient și conectează-te!";

            notifications.Show();
        }

        private async Task<bool> CheckConnectionAsync()
        {
            MySqlConnection connection = null;
            try
            {
                MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = "192.168.100.18",
                    Port = 3306,
                    UserID = "eoverart",
                    Password = "P3CZV4pgc7jtT4z",
                    Database = "asgard",
                    ConnectionTimeout = 30,
                };

                int maxRetries = 3;
                int retryDelaySeconds = 10;

                for (int retry = 0; retry < maxRetries; retry++)
                {
                    try
                    {
                        connection = new MySqlConnection(connectionStringBuilder.ConnectionString);
                        await connection.OpenAsync();

                        // Perform additional checks or operations if needed
                        return true;
                    }
                    catch (MySqlException)
                    {
                        // Handle the exception here or log it
                        // ...
                        ShowConnectionDialog(false);
                        await Task.Delay(TimeSpan.FromSeconds(retryDelaySeconds));
                    }
                    finally
                    {
                        // Close the connection
                        connection?.Close();
                    }
                }

                ShowConnectionDialog(false);
                return false;
            }
            catch (Exception)
            {
                // Handle any other exceptions here
                // ...
                ShowConnectionDialog(false);
                return false;
            }
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // Perform any cleanup or save operations here

            // Save user preferences
            SaveUserPreferences();

            // Close any open files or connections
            CloseOpenFiles();
            CloseDatabaseConnections();

            // Optionally, prevent the session from ending immediately by setting e.Cancel to true
            // e.Cancel = true;

            // Close your application
            Current.Shutdown();
        }

        private void SaveUserPreferences()
        {
            // Code to save user preferences goes here
            // For example, save settings to a configuration file or database
        }

        private void CloseOpenFiles()
        {
            // Code to close any open files goes here
            // For example, close log files or temporary files
        }

        private void CloseDatabaseConnections()
        {
            var connection = RepositoryBase.GetConnectionPublic();

            // Close the connection if it is not null
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}

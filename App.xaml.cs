// <copyright file="App.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard
{
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;
    using Asgard.CustomControls;
    using Asgard.Repositories;
    using Asgard.Windows;

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
                    var splash = new Windows.SplashScreen();
                    splash.Show();
                    loginView.Close();
                }
            };
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Delay execution for 3 seconds
            await Task.Delay(3000);

                            // Get the connection object
            var connection = RepositoryBase.GetConnectionPublic();

            try
            {
                // Check if the connection is available
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    // Show the dialog to inform the user that the connection is not available
                }
            }
            finally
            {
                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}

using Asgard.Windows;
using System.Windows;

namespace Asgard
{
    /// <summary>
    /// Interaction logic for App.xaml
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
    }
}

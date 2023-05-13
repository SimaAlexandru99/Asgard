using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Asgard.Tickets
{
    /// <summary>
    /// Interaction logic for TicketsOrange.xaml
    /// </summary>
    public partial class TicketsOrange : Page
    {
        public TicketsOrange()
        {
            InitializeComponent();
        }

        private void HomeNet_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Orange.HomeNet());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Open the hyperlink in the default web browser
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            // Mark the event as handled
            e.Handled = true;
        }
    }
}

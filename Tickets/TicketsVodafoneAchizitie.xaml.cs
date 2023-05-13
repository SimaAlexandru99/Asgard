using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Asgard.Tickets
{
    /// <summary>
    /// Interaction logic for TicketsVodafoneAchizitie.xaml
    /// </summary>
    public partial class TicketsVodafoneAchizitie : Page
    {
        // Retrieve the current date and time
        DateTime currentDate = DateTime.Now;

        public TicketsVodafoneAchizitie()
        {
            InitializeComponent();

            // Set the TextBlock's Text property to display the date in a specific format
            DateDayTextBlock.Text = currentDate.ToString("dd");
            /*DateMonthTextBlock.Text = currentDate.ToString("MMMM");*/
        }

        private void ButtonAchizitie_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Vodafone.OrderAchizitie());
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

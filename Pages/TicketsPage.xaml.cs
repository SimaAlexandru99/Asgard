using Asgard.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Asgard.Pages
{
    /// <summary>
    /// Interaction logic for TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        // Retrieve the current date and time
        DateTime currentDate = DateTime.Now;

        public MainViewModel user;

        public TicketsPage()
        {
            InitializeComponent();

            user = new MainViewModel();





        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string project = user.CurrentUserAccount.Proiect.ToString();
            string subproject = user.CurrentUserAccount.Subproiect.ToString();

            switch (project)
            {
                case "Telekom":
                    MainTickets.Content = new Tickets.TicketsTelekom();
                    break;
                case "Orange":
                    MainTickets.Content = new Tickets.TicketsOrange();
                    break;
                case "Vodafone":
                    switch (subproject)
                    {
                        case "Retentie":
                            MainTickets.Content = new Tickets.TicketeVodafone();
                            break;
                        case "Achizitie":
                            MainTickets.Content = new Tickets.TicketsVodafoneAchizitie();
                            break;
                    }
                    break;
                    case "EON":
                    MainTickets.Content = new Tickets.TicketsEon();
                    break;
            }



        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = System.Windows.Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new FrontPage());
            window.ButtonHome.IsChecked = true;
        }
    }
}

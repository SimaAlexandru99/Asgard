// <copyright file="TicketsPage.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using Asgard.ViewModels;

    /// <summary>
    /// Interaction logic for TicketsPage.xaml.
    /// </summary>
    public partial class TicketsPage : Page
    {
        private readonly MainViewModel user;

        public TicketsPage()
        {
            InitializeComponent();

            user = new MainViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
                case "CEC":
                    MainTickets.Content = new Tickets.TicketsCEC();
                    break;
                case "IT":
                    MainTickets.Content = new Tickets.TicketsAdmin();
                    break;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new FrontPage());
            window.ButtonHome.IsChecked = true;
        }
    }
}

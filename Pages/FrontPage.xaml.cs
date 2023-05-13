using Asgard.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Asgard.Pages
{
    public partial class FrontPage : Page
    {
        public MainViewModel user;


        public FrontPage()
        {
            InitializeComponent();
            user = new MainViewModel();

            string project = user.CurrentUserAccount.Proiect.ToString();
            string subproject = user.CurrentUserAccount.Subproiect.ToString();

            switch (project)
            {
                case "Telekom":
                    TextHeader.Text = "Tickete Suport";
                    LogoBrand1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/telekomlogo2.jpg"));
                    TextBrand1.Text = "Ticket Suport";
                    SubtextBrand1.Text = "Backoffice";
                    BorderBrand2.Visibility = Visibility.Collapsed;
                    BannerBorder.Background = new SolidColorBrush(Color.FromRgb(227, 0, 116));
                    LogoBanner.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/telekomlogo2.jpg"));
                    BannerText.Text = "IN CURAND";
                    HyperlinkBanner.NavigateUri = new Uri("https://www.telekom.ro/");
                    break;

                case "Orange":
                    TextHeader.Text = "Tickete";
                    LogoBrand1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/orange_logo.png"));
                    TextBrand1.Text = "Comanda Home Net";
                    SubtextBrand1.Text = "Testing";
                    BorderBrand2.Visibility = Visibility.Collapsed;
                    BannerBorder.Background = new SolidColorBrush(Color.FromRgb(255, 121, 0));
                    LogoBanner.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/orange_logo.png"));
                    BannerText.Text = "IN CURAND";
                    HyperlinkBanner.NavigateUri = new Uri("https://www.orange.ro/");
                    break;

                case "EON":
                    TextHeader.Text = "Tickete";
                    LogoBrand1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/eonlogo.png"));
                    TextBrand1.Text = "Ticket Contract";
                    SubtextBrand1.Text = "EON";
                    BorderBrand2.Visibility = Visibility.Collapsed;
                    BannerBorder.Background = new SolidColorBrush(Color.FromRgb(229, 0, 0));
                    LogoBanner.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/eonlogo.png"));
                    BannerText.Text = "IN CURAND";
                    HyperlinkBanner.NavigateUri = new Uri("https://www.eon.ro/");
                    break;

                case "Vodafone":
                    BannerBorder.Background = new SolidColorBrush(Color.FromRgb(229, 0, 0));
                    LogoBrand1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/vodafonelogo.png"));
                    LogoBrand2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/vodafonelogo.png"));
                    LogoBanner.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/logo_vodafone_white.png"));
                    BannerText.Text = "STOCURI";
                    TextHeader2.Text = "Stocuri";
                    HyperlinkBanner.NavigateUri = new Uri("https://docs.google.com/spreadsheets/d/1EKGOZ6ODwnCGo0BG97vRmJQ34OyqGRplIbKBodNMWec/edit#gid=0");

                    switch (subproject)
                    {
                        case "Retentie":
                            TextHeader.Text = "Retentie";
                            TextBrand1.Text = "Comanda DEX";
                            SubtextBrand1.Text = "Retentie";
                            TextBrand2.Text = "Ticket Suport";
                            SubtextBrand2.Text = "Retentie";
                            break;

                        case "Achizitie":
                            TextHeader.Text = "Achizitie";
                            TextBrand1.Text = "Comanda Achizitie";
                            SubtextBrand1.Text = "Achizitie";
                            BorderBrand2.Visibility = Visibility.Collapsed;
                            break;

                        default:
                            // handle unknown subproject
                            break;
                    }
                    break;

                default:
                    // handle unknown project
                    break;
            }

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Open the hyperlink in the default web browser
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            // Mark the event as handled
            e.Handled = true;
        }

        private void Button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            string project = user.CurrentUserAccount.Proiect.ToString();
            string subproject = user.CurrentUserAccount.Subproiect.ToString();

            switch (project)
            {
                case "Telekom":
                    window.Main.Navigate(new Tickets.Telekom.TicketsBackoffice());
                    break;
                case "Orange":
                    window.Main.Navigate(new Tickets.Orange.HomeNet());
                    break;
                case "EON":
                    window.Main.Navigate(new Tickets.EON.TicketContracte());
                    break;
                case "Vodafone":
                    switch (subproject)
                    {
                        case "Retentie":
                            window.Main.Navigate(new Tickets.Vodafone.OrderDex());
                            break;
                        case "Achizitie":
                            window.Main.Navigate(new Tickets.Vodafone.OrderAchizitie());
                            break;
                    }
                    break;
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Tickets.Vodafone.TicketsBackoffice()); ;
        }
    }
}

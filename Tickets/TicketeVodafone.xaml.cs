// <copyright file="TicketeVodafone.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Asgard.ViewModels;

    /// <summary>
    /// Interaction logic for TicketeVodafone.xaml.
    /// </summary>
    public partial class TicketeVodafone : Page
    {
        private readonly MainViewModel user;

        // Retrieve the current date and time
        private readonly DateTime currentDate = DateTime.Now;

        public TicketeVodafone()
        {
            InitializeComponent();

            user = new MainViewModel();

            string username = user.CurrentUserAccount.Username.ToString();
            // Set the TextBlock's Text property to display the date in a specific format
            DateDayTextBlock.Text = currentDate.ToString("dd");
            /*DateMonthTextBlock.Text = currentDate.ToString("MMMM");*/

            if (username == "ana.coca" || username == "florentina.tanase" || username == "florin.raus" || username == "teodor.postolache")
            {
                EON.Visibility = Visibility.Visible;
            }
        }

        private void ButtonDex_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            _ = window.Main.Navigate(new Vodafone.OrderDex());
        }

        private void ButtonUfe_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Vodafone.OrderUfe());
        }

        private void TicketBackoffice_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Vodafone.TicketsBackoffice());
        }

        private void TicketRetur_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Vodafone.TicketRetur());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Open the hyperlink in the default web browser
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            // Mark the event as handled
            e.Handled = true;
        }

        private void ButtonAchizitie_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Vodafone.OrderAchizitie());
        }

        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new EON.TicketContracte());
        }
    }
}

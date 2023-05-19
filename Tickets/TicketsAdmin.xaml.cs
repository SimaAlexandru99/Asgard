// <copyright file="TicketsAdmin.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for TicketsAdmin.xaml.
    /// </summary>
    public partial class TicketsAdmin : Page
    {
        // Retrieve the current date and time
        private readonly DateTime currentDate = DateTime.Now;

        public TicketsAdmin()
        {
            InitializeComponent();

            // Set the TextBlock's Text property to display the date in a specific format
            DateDayTextBlock.Text = currentDate.ToString("dd");
            /*DateMonthTextBlock.Text = currentDate.ToString("MMMM");*/
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

        private void ButtonTelokom_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            _ = window.Main.Navigate(new Telekom.TicketsBackoffice());
        }

        private void HomeNet_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Orange.HomeNet());
        }

        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new EON.TicketContracte());
        }

        private void ButtonCEC_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new CEC.Formular());
        }
    }
}

// <copyright file="TicketsTelekom.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for TicketsTelekom.xaml.
    /// </summary>
    public partial class TicketsTelekom : Page
    {
        public TicketsTelekom()
        {
            InitializeComponent();
        }

        private void ButtonTicket_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            _ = window.Main.Navigate(new Telekom.TicketsBackoffice());
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

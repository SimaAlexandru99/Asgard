// <copyright file="EvaluariPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Asgard.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for EvaluariPage.xaml.
    /// </summary>
    public partial class EvaluariPage : Page
    {
        public EvaluariPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainTickets.Content = new Tickets.EvaluariTab();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new FrontPage());
            window.ButtonHome.IsChecked = true;
        }
    }
}

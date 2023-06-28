// <copyright file="EvaluariTab.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Asgard.Tickets
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for EvaluariTab.xaml.
    /// </summary>
    public partial class EvaluariTab : Page
    {
        public EvaluariTab()
        {
            InitializeComponent();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Evaluari.Vodafone());
        }

        private void ButtonGoOrange_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Evaluari.OROC2023());
        }

        private void ButtonGoOrange2_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new Evaluari.Orange());
        }
    }
}

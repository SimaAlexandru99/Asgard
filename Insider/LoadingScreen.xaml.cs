// <copyright file="LoadingScreen.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Insider
{
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LoadingScreen.xaml.
    /// </summary>
    public partial class LoadingScreen : Window
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000); // Wait for 3 seconds

            PrimaryWindow primaryWindow = new PrimaryWindow();
            Close();
            primaryWindow.ShowDialog();
        }
    }
}

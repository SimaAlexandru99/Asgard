// <copyright file="Notifications.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.CustomControls
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Notifications.xaml.
    /// </summary>
    public partial class Notifications : Window
    {
        public Notifications()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
{
            // Set the position of the window to the bottom right corner of the screen
            Left = SystemParameters.WorkArea.Right - Width - 10;
            Top = SystemParameters.WorkArea.Bottom - Height - 10;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

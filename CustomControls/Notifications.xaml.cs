// <copyright file="Notifications.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.CustomControls
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

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

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the CloseButton reference
            Button closeButton = sender as Button;

            // Get the parent window (assuming the button is inside a Window)
            Window window = Window.GetWindow(closeButton);

            // Get the SlideOutAnimation storyboard from the window resources
            Storyboard slideOutAnimation = window.Resources["SlideOutAnimation"] as Storyboard;

            // Set a fixed duration for the slide-out animation
            TimeSpan slideOutDuration = TimeSpan.FromSeconds(0.5);
            slideOutAnimation.Duration = slideOutDuration;

            // Begin the slide-out animation for the window
            slideOutAnimation.Begin(window);

            // Delay for the duration of the slide-out animation
            await Task.Delay(slideOutDuration);

            // Close the window
            window.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}

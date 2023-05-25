// <copyright file="RegisterAccountWindow.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Interaction logic for RegisterAccountWindow.xaml.
    /// </summary>
    public partial class RegisterAccountWindow : Window
    {
        public RegisterAccountWindow()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            if (screenWidth >= 1920 && screenHeight >= 1080)
            {
                RegisterWindow.Width = 1000;
                RegisterWindow.Height = 600;
                Column1.Width = new GridLength(180);
                Column3.Width = new GridLength(180);
                VodafoneRadioButton.Width = 180;
                OrangeRadioButton.Width = 180;
                TelekomRadioButton.Width = 180;
                CECRadioButton.Width = 180;
                BCRRadioButton.Width = 180;
                EONRadioButton.Width = 180;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ButtonComeback_Click(object sender, RoutedEventArgs e)
        {
            var signin = new SignIn();
            signin.Show();

            Close();
        }

        private void VodafoneRadioButton_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void VodafoneRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TopPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
    }
}

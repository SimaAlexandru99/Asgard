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

        private void ComboboxProiect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboboxProiect.SelectedItem;
            comboboxSubProiect.Items.Clear();
            switch (selectedItem.Content.ToString())
            {
                case "Vodafone":
                    comboboxSubProiect.Items.Add("Achizitie");
                    comboboxSubProiect.Items.Add("Retentie");

                    break;
                case "Telekom":
                    comboboxSubProiect.Items.Add("Savedesk");
                    comboboxSubProiect.Items.Add("Antichurn");
                    comboboxSubProiect.Items.Add("TKRM");
                    break;
            }
        }
    }
}

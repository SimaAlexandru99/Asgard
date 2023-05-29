// <copyright file="SignIn.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Demo
{
    using System.Windows;

    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            if (screenWidth >= 1920 && screenHeight >= 1080)
            {
                SignInPage.Width = 1420;
                SignInPage.Height = 890;
            }

            SizeChanged += SignInPage_SizeChanged;
        }

        private void SignInPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 1120)
            {
                ColumnDynamic.Visibility = Visibility.Collapsed;
            }
            else
            {
                ColumnDynamic.Visibility = Visibility.Visible;
            }
        }
    }
}

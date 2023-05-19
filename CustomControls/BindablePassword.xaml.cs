// <copyright file="BindablePassword.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.CustomControls
{
    using System.Security;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for BindablePassword.xaml.
    /// </summary>
    public partial class BindablePassword : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePassword));

        public BindablePassword()
        {
            InitializeComponent();
            txtPass.PasswordChanged += OnPasswordChanged;
        }

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = txtPass.SecurePassword;
        }
    }
}

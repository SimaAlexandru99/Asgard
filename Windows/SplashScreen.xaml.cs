// <copyright file="SplashScreen.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Windows
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using Asgard.ViewModels;

    /// <summary>
    /// Interaction logic for SplashScreen.xaml.
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();

            var user = new MainViewModel();
            string last = user.CurrentUserAccount.Name.ToString();
            TextUser.Text = "Bună " + last + ", Bine ai revenit!";
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
            };
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            if (progressBar.Value == 100)
            {
                PrimaryWindow primaryWindow = new PrimaryWindow();
                Close();
                primaryWindow.ShowDialog();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(80);
            }
        }
    }
}

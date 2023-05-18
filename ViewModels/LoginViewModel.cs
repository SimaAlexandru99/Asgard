// <copyright file="LoginViewModel.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.ViewModels
{
    using System;
    using System.Net;
    using System.Security;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Input;
    using Asgard.Models;
    using Asgard.Repositories;

    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private readonly IUserRepository userRepository;
        private string username;
        private SecureString password;
        private string errorMessage;
        private bool isViewVisible = true;

        // Builder
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand(string.Empty));
        }

        // -> Commands
        public ICommand LoginCommand { get; }

        public ICommand RecoverPasswordCommand { get; }

        public ICommand ShowPasswordCommand { get; }

        // properties
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }

            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return isViewVisible;
            }

            set
            {
                isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password?.ToString()))
            {
                ErrorMessage = "* Nume utilizator sau parolă invalidă";
                return;
            }

            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            try
            {
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                    IsViewVisible = false;

                    var user = new MainViewModel();
                    string proiect = user.CurrentUserAccount.Proiect.ToString();
                }
                else
                {
                    ErrorMessage = "* Nume utilizator sau parolă greșită";
                }
            }
            catch (Exception ex)
            {
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "A aparut o eroare";
                    dialog.Descriere.Text = "Am intampinat o eroare: " + ex.Message;
                };
                dialog.ShowDialog();
            }
        }

        private void ExecuteRecoverPassCommand(string username)
        {
        }
    }
}

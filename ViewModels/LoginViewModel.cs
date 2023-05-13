using Asgard.Models;
using Asgard.Repositories;
using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;


namespace Asgard.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //properties


        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        private readonly IUserRepository userRepository;

        //Builder
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand(""));
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
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
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null);
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

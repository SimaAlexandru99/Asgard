// <copyright file="MainViewModel.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.ViewModels
{
    using System.Threading;
    using Asgard.Models;
    using Asgard.Repositories;

    public class MainViewModel : ViewModelBase
    {
        // Fields
        private readonly IUserRepository userRepository;
        private UserAccountModel currentUserAccount;

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return currentUserAccount;
            }

            set
            {
                currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = user.Username.Substring(0, 1);
                CurrentUserAccount.ProfilePicture = null;
                CurrentUserAccount.Proiect = user.Proiect;
                CurrentUserAccount.Email = user.Email;
                CurrentUserAccount.Subproiect = user.Subproiect;
                CurrentUserAccount.TeamlLeader = user.TeamlLeader;
                CurrentUserAccount.Quality = user.Quality;
                CurrentUserAccount.ID_Bria = user.ID_Bria;
                CurrentUserAccount.Status = user.Status;
                CurrentUserAccount.Name = user.Name;
                CurrentUserAccount.LastName = user.LastName;
            }
            else
            {
                CurrentUserAccount.DisplayName = "User invalid, nu ai fost logat";

                // Hide child views.
            }
        }
    }
}
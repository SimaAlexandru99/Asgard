using Asgard.Models;
using Asgard.Repositories;
using System.Threading;

namespace Asgard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        //Fields
        private UserAccountModel _currentUserAccount;
        private readonly IUserRepository _userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        public void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
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
                //Hide child views.
            }
        }


    }
}
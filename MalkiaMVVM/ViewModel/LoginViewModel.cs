using MalkiaMVVM.Common;
using MalkiaMVVM.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace MalkiaMVVM.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {

        private string _username;
        private string _password;
        private AdoptersCatalogSingleton ocs;
        private Adopters _loggedIn;
        private Visibility _loginErrorVisibility = Visibility.Collapsed;
        private Adopters adopter;

        public LoginViewModel()
        {
            Username = _username;
            Password = _password;
            ocs = AdoptersCatalogSingleton.Instance;
            LogInCommand = new RelayCommand(LogIn);
            LogOutCommand = new RelayCommand(LogOut);
        }


        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Visibility LoginErrorVisibility
        {
            get { return _loginErrorVisibility; }
            set
            {
                _loginErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Adopters LoggedIn
        {
            get { return AdoptersCatalogSingleton.Instance.CurrentAdopter; }
            set
            {
                _loggedIn = value;
                OnPropertyChanged();
            }
        }

       
        public void LogIn()
        {
            if (AdoptersCatalogSingleton.Instance.LoginCheck(Username, Password) != null)
            {
                AdoptersCatalogSingleton.Instance.LogIn(Username, Password);
                LoggedIn = AdoptersCatalogSingleton.Instance.CurrentAdopter;
                LoginErrorVisibility = Visibility.Collapsed;
               
            }
            else
            {
                LoginErrorVisibility = Visibility.Visible;
                Username = null;
                Password = null;
            }
        }
        public bool CanNavigate(string username, string password)
        {
            Adopters a = new Adopters();
            if ( a.Username==username && a.Password==password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogOut()
        {
            AdoptersCatalogSingleton.Instance.LogOut();
            LoggedIn = null;
            
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
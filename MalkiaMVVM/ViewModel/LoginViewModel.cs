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

namespace MalkiaMVVM.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {


        private AdoptersCatalogSingleton ocs;


        public LoginViewModel()
        {
            ocs = AdoptersCatalogSingleton.Instance;
            //LogInCommand = new RelayCommand(LogIn);
            //LogOutCommand = new RelayCommand(LogOut);
        }


        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
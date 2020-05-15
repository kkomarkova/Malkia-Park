using MalkiaMVVM.Common;
using MalkiaMVVM.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using System.Windows;

namespace MalkiaMVVM.ViewModel
{
    class AnimalsViewModel:INotifyPropertyChanged
    {

        private string _image;
        private string _username;
        private string _password;
        private AnimalsCatalogSingleton acs;
        private AdoptersCatalogSingleton ocs;
        private AnimalsAdoptersCatalogSingleton aocs;
        private TypesCatalogSingleton tcs;
        private Animals _selectedAnimal;
        private Types _selectedType;
        private AnimalsAdopters _selectedAnimalsAdopter;
        private Adopters _selectedAdopter;
        private Types _typeDetails;
        private Adopters _loggedIn;
        private Visibility _loginErrorVisibility = Visibility.Collapsed;
        private Adopters adopter;
        private ICommand _addAdoptionCommand;
        private ICommand _deleteAdoptionCommand;
        private ICommand _updateAdoptionCommand;

        public AnimalsViewModel()
        {
            _selectedAnimal = new Animals();
            _selectedType = new Types();
            _selectedAdopter = new Adopters();
            _typeDetails = new Types();
            Username = _username;
            Password = _password;
            tcs = TypesCatalogSingleton.Instance;
            acs = AnimalsCatalogSingleton.Instance;
            ocs = AdoptersCatalogSingleton.Instance;
            aocs = AnimalsAdoptersCatalogSingleton.Instance;
            AddAdoptionCommand = new RelayCommand(CreateAdoption);

            DeleteAdoptionCommand = new RelayCommand(DeleteAdoption );
            //_updateAdoptionCommand = new RelayCommand(UpdateAdoption);
            //LogInCommand = new RelayCommand(LogIn);
            LogOutCommand = new RelayCommand(LogOut);
            AddAdopterCommand = new RelayCommand(CreateNewAdopter);

        }
        public ICommand AddAdoptionCommand { get; set; }
        public ICommand DeleteAdoptionCommand { get; set; }
        public ICommand UpdateAdoptionCOmmand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand AddAdopterCommand { get; set; }

        public TypesCatalogSingleton TypesCatalogSingleton 
        { 
            get { return tcs; } 
            set { tcs = value; } 
        }
        
        public AnimalsCatalogSingleton AnimalcatalogSingleton
        {
            get { return acs; }
            set { acs = value; }
        }
        public AnimalsAdoptersCatalogSingleton AnimalsAdoptersCatalogSingleton
        {
            get { return aocs; }
            set { aocs = value; }
        }
        public AdoptersCatalogSingleton AdoptersCatalogSingleton
        {
            get { return ocs; }
            set { ocs = value; }
        }
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


        public int AId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime Dob { get; set; }
        public int TId { get; set; }
        public string Type { get; set; }
        public string Origine { get; set; }
        public int El { get; set; }
        public int ZooMap { get; set; }
         public int OId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Date { get; set; }
        public string Image
        {
            get => _image;
            set => _image = ApplicationData.Current.LocalFolder.Path + "\\" + value;

            
        }

        public Animals SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }
        public Types SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(animalOfType));
            }
        }

        public Adopters SelectedAdopter
        {
            get { return _selectedAdopter; }
            set
            {
                _selectedAdopter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(animalOfType));
            }
        }

        public bool LogIn()
        {
            string u = Username;
            string p = Password;
            if (AdoptersCatalogSingleton.LoginCheck(Username, Password)  )
            {
                //AdoptersCatalogSingleton.Instance.LogIn(Username, Password);
                //LoggedIn = AdoptersCatalogSingleton.Instance.CurrentAdopter;
                LoginErrorVisibility = Visibility.Collapsed;
                return true;
            }
            else
            {  
                LoginErrorVisibility = Visibility.Visible;
                Username = null;
                Password = null;
                return false;
            }
        }
        public bool CanNavigate(string username, string password)
        {
            Adopters a = new Adopters();
            if (a.Username == username && a.Password == password)
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

        public ObservableCollection<Animals> allAnimals

        {
            get
            {
                ObservableCollection<Animals> animals = acs.Animals;
                return new ObservableCollection<Animals>(acs.getAnimals());
            }

        }
        public ObservableCollection<Types> allTypes 
        {
            get
            {
                ObservableCollection<Types> types = tcs.AllTypes;

                return new ObservableCollection<Types>(tcs.getTypes());
            }
        }
        public ObservableCollection<Adopters> allAdopters 
        {
            get
            {
                ObservableCollection<Adopters> adopters = ocs.AllAdopters;

                return new ObservableCollection<Adopters>(ocs.getAdopters());
            }
        }

        public ObservableCollection<AnimalsAdopters> allAnimalsAdopters
        {
            get
            {
                ObservableCollection<AnimalsAdopters> animalsAdopters = aocs.AllAnimalsAdopters;

                return new ObservableCollection<AnimalsAdopters>(aocs.getAnimalsAdopters());
            }
        }
        public void CreateAdoption()
        {
            DateTime today = DateTime.Today;
            AnimalsAdopters adoption = new AnimalsAdopters( OId, SelectedAnimal.AId, today);

            AnimalsAdoptersCatalogSingleton.AddAdoption(adoption);
        }


        public void CreateNewAdopter()
        {
            Adopters a = new Adopters() {  OId= OId,  Password= Password, Username= Username} ;
            AdoptersCatalogSingleton.AddAdopter(a);
        }
        public void DeleteAdoption()
        {
            DateTime today = DateTime.Today;
            AnimalsAdopters adoption = new AnimalsAdopters(SelectedAnimal.AId, SelectedAdopter.OId, today);
            AnimalsAdoptersCatalogSingleton.DeleteAdoption(adoption);

        }

        
       
        public ObservableCollection<AnimalsAdopters> adopterOfAnAnimal
        {
            get
            {
                return new ObservableCollection<AnimalsAdopters>(aocs.AllAnimalsAdopters.Where(a => a.AId == SelectedAnimal.AId));
            }
        }
        public ObservableCollection<Animals> animalOfType
        {
            get
            {
                return new ObservableCollection<Animals>(acs.Animals.Where(a => a.TId == SelectedType.TId));

            }
        }

       
   
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


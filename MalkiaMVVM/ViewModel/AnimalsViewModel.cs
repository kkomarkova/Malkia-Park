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
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MalkiaMVVM.ViewModel

{
    public class AnimalsViewModel : INotifyPropertyChanged
    {

        private string _image;
        private string _username;
        private string _password;
        private AnimalsCatalogSingleton acs;     
        private AnimalsAdoptersCatalogSingleton aocs;
        private TypesCatalogSingleton tcs;
        private Animals _selectedAnimal;
        private Types _selectedType;       
        private Adopters _selectedAdopter;
        private AnimalsAdopters _selectedAdoption;
        private Types _typeDetails;
        private Adopters _loggedIn;
        private Visibility _loginErrorVisibility = Visibility.Collapsed;
        private Visibility _loginVisibility = Visibility.Collapsed;
        private Visibility _adoptionVisibility = Visibility.Collapsed;
        private Visibility _cancelAdoptionVisibility = Visibility.Collapsed;
        private Visibility _registrationConfirmationVisibility = Visibility.Collapsed;
        private Visibility _myPageVisibility = Visibility.Collapsed;
        private Visibility _adoptionNoLogVisibility = Visibility.Collapsed;
        private Visibility _cancelAccountVisibility = Visibility.Collapsed;
        private Visibility _changeUsernameVisibility = Visibility.Collapsed;
        private Visibility _emptyFields = Visibility.Collapsed;
        private Visibility _adoptionNoAnimal = Visibility.Collapsed;
        private Visibility _adoptionNoAmount = Visibility.Collapsed;
        
        public AnimalsViewModel()
        {
            _selectedAnimal = new Animals();
            _selectedType = new Types();
            _selectedAdopter = new Adopters();
            _selectedAdoption = new AnimalsAdopters();
            _typeDetails = new Types();
            Username = _username;
            Password = _password;
            tcs = TypesCatalogSingleton.Instance;
            acs = AnimalsCatalogSingleton.Instance;
            ocs = AdoptersCatalogSingleton.Instance;
            aocs = AnimalsAdoptersCatalogSingleton.Instance;
            AddAdoptionCommand = new RelayCommand(CreateAdoption);
            DeleteAdoptionCommand = new RelayCommand(CancelAdoption);                       
            LogOutCommand = new RelayCommand(LogOut);
            AddAdopterCommand = new RelayCommand(CreateNewAdopter);
            OpenMyPageCommand = new RelayCommand(OpenPage);
            DeleteAccountCommand = new RelayCommand(CancelAccount);
            AddAnimalCommand = new RelayCommand(CreateNewAnimal);
            DeleteAnimalCommand = new RelayCommand(CancelAnimal);
            AddTypeCommand = new RelayCommand(CreateNewType);
            DeleteTypeCommand = new RelayCommand(CancelType);

        }

        public ICommand AddAdoptionCommand { get; set; }
        public ICommand DeleteAdoptionCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand AddAdopterCommand { get; set; }
        public ICommand OpenMyPageCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand AddAnimalCommand { get; set; }
        public ICommand DeleteAnimalCommand { get; set; }
        public ICommand AddTypeCommand { get; set; }
        public ICommand DeleteTypeCommand { get; set; }
       
        public AdoptersCatalogSingleton ocs { get; set; }
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
       
        public Visibility EmptyFields
        {
            get { return _emptyFields; }
            set { _emptyFields = value;
                OnPropertyChanged();
            }
          
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
        public Visibility LoginVisibility
        {
            get { return _loginVisibility; }
            set
            {
                _loginVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility RegisterConfirmationVisibility
        {
            get { return _registrationConfirmationVisibility; }
            set
            {
                _registrationConfirmationVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ChangeUsernameVisibility
        {
            get { return _changeUsernameVisibility; }
            set
            {
                _changeUsernameVisibility = value;
                OnPropertyChanged();
            }

        }
        public Visibility AdoptionVisability
        {
            get { return _adoptionVisibility; }
            set
            {
                _adoptionVisibility = value;
                OnPropertyChanged();
                
            }
        }
        public Visibility AdoptionWithNoLoginVisibility
        {
            get { return _adoptionNoLogVisibility; }
            set
            {
                _adoptionNoLogVisibility = value;
                OnPropertyChanged();

            }
        }
        public Visibility AdoptionNoAnimal
        {
            get { return _adoptionNoAnimal; }
            set
            {
                _adoptionNoAnimal = value;
                OnPropertyChanged();
            }
        }

        public Visibility AdoptionNoAmount
        {

            get { return _adoptionNoAmount; }
            set
            {
                _adoptionNoAmount = value;
                OnPropertyChanged();
            }
        }
        public Visibility CancelAdoptionVisability
        {
            get { return _cancelAdoptionVisibility; }
            set
            {
                _cancelAdoptionVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility CancelAccountVisibitily
        {
            get { return _cancelAccountVisibility; }
            set
            {
                _cancelAccountVisibility = value;
                OnPropertyChanged();
            }
        }
            
        public Visibility MyPageVisibility
        {
            get { return _myPageVisibility; }
            set
            {
                _myPageVisibility = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyAdoption));
            }
        }
       
        public Adopters LoggedIn
        {
            get { return AdoptersCatalogSingleton.CurrentAdopter; }
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
        public int AdoptionId { get; set; }
        public int Amount { get; set; }
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
                OnPropertyChanged(nameof(SelectedAnimal));
                OnPropertyChanged(nameof(AnimalsAdopters));
                OnPropertyChanged(nameof(TypesOfAnimal));
               
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
                OnPropertyChanged(nameof(TypesOfAnimal));
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
                OnPropertyChanged(nameof(MyAdoption));
            }
        }

        public AnimalsAdopters SelectedAdoption
        {
            get { return _selectedAdoption; }
            set
            {
                _selectedAdoption = value;
                OnPropertyChanged();
            }
        }

        public Types TypesOfAnimal
        {
            get
            {
                return (tcs.AllTypes.Where(a => a.TId == SelectedAnimal.TId)).FirstOrDefault();
            }
        }
        
        public ObservableCollection <AnimalsAdopters> AnimalsAdopters
        {
            get
            { if (SelectedAnimal != null)
                {
                    IEnumerable<AnimalsAdopters> ad = (aocs.AllAnimalsAdopters.Where(a => a.AId == SelectedAnimal.AId));
               return new ObservableCollection<AnimalsAdopters>(ad);                  
                }
                return null;
            }         
        }
        public ObservableCollection<AnimalsAdopters> MyAdoption
        {
            get
            {
                if (ocs.CurrentAdopter != null)
                {
                    IEnumerable<AnimalsAdopters> aa = (aocs.allAnimalsAdopters.Where(a => a.OId == ocs.CurrentAdopter.OId));
                    return new ObservableCollection<AnimalsAdopters>(aa);
                }
                return null;
            }                      
        }
        public bool LogIn()
        {
            
            if (AdoptersCatalogSingleton.LoginCheck(Username, Password)  )
            {               
                LoginErrorVisibility = Visibility.Collapsed;
                LoginVisibility = Visibility.Visible;              
                return true;
                
            }
            else
            {  
                LoginErrorVisibility = Visibility.Visible;
                LoginVisibility = Visibility.Collapsed;
                Username = null;
                Password = null;
                return false;
            }
        }
       
        
        public void OpenPage()
        {            
            LoginErrorVisibility = Visibility.Collapsed;
            MyPageVisibility = Visibility.Visible;
        }

        public bool AdminCanNavigate(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return true;
            }
            else return false;
        }

        public void LogOut()
        {
            AdoptersCatalogSingleton.Instance.LogOut();
            LoggedIn = null;
            MyPageVisibility = Visibility.Collapsed;

        }

        public ObservableCollection<Animals> allAnimals

        { 
            get
            {              
                return new ObservableCollection<Animals>(acs.getAnimals().OrderBy(s => s.Name));
            }

        }
        public ObservableCollection<Types> allTypes 
        {
            get
            {
                return new ObservableCollection<Types>(tcs.getTypes().OrderBy(s => s.Type));
            }
        }
        public ObservableCollection<Adopters> allAdopters 
        {
            get
            {
                return new ObservableCollection<Adopters>(ocs.getAdopters());
            }
        }

        public ObservableCollection<AnimalsAdopters> allAnimalsAdopters
        {
            get
            {
                return new ObservableCollection<AnimalsAdopters>(aocs.getAnimalsAdopters());
            }
        }
               
        public void CreateAdoption()
        {  
            DateTime? today = DateTime.Today;
            if(ocs.CurrentAdopter.Username != null)
            {
                AnimalsAdopters adoption =
                    new AnimalsAdopters() { OId = ocs.CurrentAdopter.OId, AId = SelectedAnimal.AId, Date = today, Amount = Amount };

                AnimalsAdoptersCatalogSingleton.AddAdoption(adoption);
                AdoptionWithNoLoginVisibility = Visibility.Collapsed;
                AdoptionVisability = Visibility.Visible;
                AdoptionNoAnimal = Visibility.Collapsed;
                AdoptionNoAmount = Visibility.Collapsed;
            }

              else if  ( SelectedAnimal.AId==0)
            {
                AdoptionNoAnimal = Visibility.Visible;
                AdoptionNoAmount = Visibility.Collapsed;
                AdoptionWithNoLoginVisibility = Visibility.Collapsed;
                AdoptionVisability = Visibility.Collapsed;
            }
            else if ( Amount ==0)
            {
                AdoptionNoAmount = Visibility.Visible;
                AdoptionWithNoLoginVisibility = Visibility.Collapsed;
                AdoptionVisability = Visibility.Collapsed;
                AdoptionNoAnimal = Visibility.Collapsed;
            }
            
            else 
            {               
                AdoptionVisability = Visibility.Collapsed;
                AdoptionNoAnimal = Visibility.Collapsed;
                AdoptionNoAmount = Visibility.Collapsed;
                AdoptionWithNoLoginVisibility = Visibility.Visible;
            }
        }
        
            public void CancelAdoption()
        {         
                AnimalsAdoptersCatalogSingleton.DeleteAdoption(AdoptionId);
                CancelAdoptionVisability = Visibility.Visible;
            CancelAccountVisibitily = Visibility.Collapsed;
        }
        
        public void CreateNewAdopter()
        {
                        
            Adopters a = new Adopters() { Password= Password, Username= Username} ;
            if (Username == null || Password == null)
            {
                EmptyFields = Visibility.Visible;
            }
            else if (AdoptersCatalogSingleton.UserNameCheck(Username ) )
            {             
                 AdoptersCatalogSingleton.AddAdopter(a);
                RegisterConfirmationVisibility = Visibility.Visible;
                EmptyFields = Visibility.Collapsed;
                ChangeUsernameVisibility = Visibility.Collapsed;
            }
            else
            {
                ChangeUsernameVisibility = Visibility.Visible;
                RegisterConfirmationVisibility = Visibility.Collapsed;
                EmptyFields = Visibility.Collapsed;
            }
           
        }

        public void CancelAccount()
        {           
            AdoptersCatalogSingleton.DeleteAdopter(AdoptersCatalogSingleton.CurrentAdopter.OId);
            CancelAccountVisibitily = Visibility.Visible;
            CancelAdoptionVisability = Visibility.Collapsed;

        }
       
        public void CreateNewAnimal()
        {
            Animals a = new Animals() { AId= AId, Dob = Dob, Image=Image, Name =Name, TId =TId  } ;
            AnimalcatalogSingleton.AddAnimal(a);
        }

        public void CancelAnimal()
        {
            AnimalcatalogSingleton.DeleteAnimal( AId);
        }

        public void CreateNewType()
        {
            Types t = new Types() { TId = TId, El= El, Origine = Origine, Type = Type, ZooMap= ZooMap };
            TypesCatalogSingleton.AddType(t);
        }
        public void CancelType()
        {
            TypesCatalogSingleton.DeleteType(TId);
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
                return new ObservableCollection<Animals>(acs.Animals.Where(a=> a.TId == SelectedType.TId));
            }
        }

        public ObservableCollection<Types> typeOfAnimal
        {
            
            get
            {
               return new ObservableCollection<Types> (tcs.allTypes.Where(a=>a.TId== SelectedAnimal.TId));
            }
           
        }

       
   
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


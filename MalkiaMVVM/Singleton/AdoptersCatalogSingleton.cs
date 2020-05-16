using MalkiaMVVM.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MalkiaMVVM.Singleton
{
    class AdoptersCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "api/adopters";

        const string serverURL = "http://localhost:54223/";

        private AdoptersCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            adopters = new ObservableCollection<Adopters>();
            CurrentAdopter = new Adopters();
            adopters.Add(new Adopters() { OId = 101, Username = "Rania", Password = "ra12" });
            adopters.Add(new Adopters() { OId = 102, Username = "James", Password = "ja12" });
            adopters.Add(new Adopters() { OId = 103, Username = "Katerina", Password = "ka12" });

            // adopters=getAdopters();

        }

        private static AdoptersCatalogSingleton _Instance;


        private ObservableCollection<Adopters> adopters;
        public static AdoptersCatalogSingleton Instance // here its a public Instance for other classes to be able to use it 
        {
            get
            {
                return _Instance ?? (_Instance = new AdoptersCatalogSingleton());
            }
        }

        public Adopters CurrentAdopter { get; set; }

        public int Count
        {
            get { return adopters.Count; }


        }

        public ObservableCollection<Adopters> AllAdopters
        {
            get { return adopters; }
        }


        
        public ObservableCollection<Adopters> getAdopters()
        {
            GenericWebApiServices<Adopters> gAdopters = new GenericWebApiServices<Adopters>( a_url);

            List<Adopters> aList = gAdopters.getAll();
            return new ObservableCollection<Adopters>(aList);
        }
        public void AddAdopter(Adopters s)
        {
            
            GenericWebApiServices<Adopters> newAdopters = new GenericWebApiServices<Adopters>(a_url);
            newAdopters.createNewOne(s);
            OnPropertyChanged(nameof(adopters));
            OnPropertyChanged(nameof(Count));
        }
        public ObservableCollection<Adopters> allAdopters 
        {
            get
            {
                ObservableCollection<Adopters> adopters = AllAdopters;

                return new ObservableCollection<Adopters>(getAdopters());
            }
        }

        //Checks if the entered information matches with one of the accounts
        public bool LoginCheck(string username, string password)
        {
           bool status = false;
               foreach (var v in AllAdopters)
                {
                    if(v.Username== username && v.Password == password)
                    {
                        CurrentAdopter.Username = username;
                        status=true;
                    }
                }
            return status;
            //return adopters.FirstOrDefault(data => data.Username == username && data.Password == password);
        }
            
          
        

        //Actual logging in, only used after the method above checks for the existence of the account
        public void LogIn(string username, string password)
        {
            CurrentAdopter = AllAdopters.FirstOrDefault(data => data.Username == username && data.Password == password);
        }

       

        public void LogOut()
        {
            CurrentAdopter = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

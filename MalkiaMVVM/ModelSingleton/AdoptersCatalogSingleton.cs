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
    public class AdoptersCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "api/Adopters";

        const string serverURL = "http://localhost:50948/";

        private AdoptersCatalogSingleton()
        {
            adopters = new ObservableCollection<Adopters>();
            CurrentAdopter = new Adopters();
            adopters =getAdopters();
        }

        private static AdoptersCatalogSingleton _Instance;

        private ObservableCollection<Adopters> adopters;
        public static AdoptersCatalogSingleton Instance 
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
            set { }
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
      
        public void DeleteAdopter(int OId)
        {
            GenericWebApiServices<Adopters> deleteAdopters = new GenericWebApiServices<Adopters>(a_url);
            deleteAdopters.deleteOne(OId);
            OnPropertyChanged(nameof(adopters));
            OnPropertyChanged(nameof(Count));
        }
       
        public bool LoginCheck(string username, string password)
        {
           bool status = false;
               foreach (var v in AllAdopters)
                {
                    if(v.Username== username && v.Password == password)
                    {
                    CurrentAdopter = AllAdopters.Where((ad) => ad.Username == username).FirstOrDefault();
                        status=true;
                    }
                }
            return status;           
        }

        public bool UserNameCheck(string username)
        {
            bool status = true;
            foreach (var u in AllAdopters)
            {
                if (u.Username == username)
                {
                    status = false;
                }
            }
            return status;
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

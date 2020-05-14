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
        static string a_url = "/api/Adopters";

        const string serverURL = "http://localhost:59561/";

        private AdoptersCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            adopters = new ObservableCollection<Adopters>();

            adopters.Add( new Adopters() { OId=101, Username= "Rania", Password="ra12"});
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
            GenericWebApiServices<Adopters> gAdopters = new GenericWebApiServices<Adopters>(serverURL, a_url);

            List<Adopters> aList = gAdopters.getAll();
            return new ObservableCollection<Adopters>(aList);
        }

        public ObservableCollection<Adopters> allAdopters 
        {
            get
            {
                ObservableCollection<Adopters> adopters = AllAdopters;

                return new ObservableCollection<Adopters>(getAdopters());
            }
        }


        //public Adopters LoginCheck(string username, string password)
        //{
        //    try
        //    {
        //        return Adopters.FirstorDefault(data => data.Email == email && data.Password == password);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        ////Actual logging in, only used after the method above checks for the existence of the account
        //public void LogIn(string username, string password)
        //{
        //    CurrentAdopter = Adopters.Where(data => data.Email == email && data.Password == password);
        //}



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

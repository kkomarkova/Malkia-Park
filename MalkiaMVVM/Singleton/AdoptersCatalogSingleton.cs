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

        const string serverURL = "http://localhost:50617/";

        private AdoptersCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            adopters = new ObservableCollection<Adopters>();

            getAdopters();

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


        public int Count
        {
            get { return adopters.Count; }


        }

        public ObservableCollection<Adopters> Adopters
        {
            get { return adopters; }
        }


        
        public ObservableCollection<Adopters> getAdopters()
        {
            GenericWebApiServices<Adopters> gAdopters = new GenericWebApiServices<Adopters>(serverURL, a_url);

            List<Adopters> aList = gAdopters.getAll();
            return new ObservableCollection<Adopters>(aList);
        }






        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

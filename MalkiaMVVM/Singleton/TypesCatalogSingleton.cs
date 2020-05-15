using MalkiaMVVM.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input;

namespace MalkiaMVVM.Singleton
{
    class TypesCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "/api/types";

        const string serverURL = "http://localhost:59561/";

        private TypesCatalogSingleton tcs;
        private TypesCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            type = new ObservableCollection<Types>();

            //type.Add(new Types() { El = 1, Origine = "Africa", Type = "Lion", TId = 11, ZooMap = 2 });
            //type.Add(new Types() { El = 2, Origine = "Asia", Type = "Tiger", TId = 12, ZooMap = 4 });

            type = getTypes();

        }

        private static TypesCatalogSingleton _Instance;


        private ObservableCollection<Types> type;
        public static TypesCatalogSingleton Instance // here its a public Instance for other classes to be able to use it 
        {
            get
            {
                return _Instance ?? (_Instance = new TypesCatalogSingleton());
            }
        }


        public int Count
        {
            get { return type.Count; }


        }

        public ObservableCollection<Types> AllTypes
        {
            get { return type; }
        }

        public ObservableCollection<int>allTypesID
        {
            get
            {
                ObservableCollection<int> myList = new ObservableCollection<int>();
                foreach(var t in AllTypes)
                {
                    myList.Add(t.TId);
                }
                return myList;
            }
        }
       
        public ObservableCollection<Types> getTypes()
        {
            GenericWebApiServices<Types> gTypes = new GenericWebApiServices<Types>(a_url);

            List<Types> tList = gTypes.getAll();
            return new ObservableCollection<Types>(tList);
        }

        public ObservableCollection<Types> allTypes // we just need get 
        {
            get
            {
                ObservableCollection<Types> types = AllTypes;

                return new ObservableCollection<Types>(getTypes());
            }
        }
       

        


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}

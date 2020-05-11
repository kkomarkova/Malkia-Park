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
    class TypesCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "/api/Types";

        const string serverURL = "http://localhost:50617/";


        private TypesCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            type = new ObservableCollection<Types>();

            getTypes();

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
            get { return AllTypes; }
        }


       

        public ObservableCollection<Types> getTypes()
        {
            GenericWebApiServices<Types> gTypes = new GenericWebApiServices<Types>(serverURL, a_url);

            List<Types> tList = gTypes.getAll();
            return new ObservableCollection<Types>(tList);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}

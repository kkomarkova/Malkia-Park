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
    public class TypesCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "api/Types";

        const string serverURL = "http://localhost:50948/";

        private TypesCatalogSingleton tcs;
        private TypesCatalogSingleton()
        {
            type = new ObservableCollection<Types>();

            type = getTypes();

        }

        private static TypesCatalogSingleton _Instance;


        private ObservableCollection<Types> type;
        public static TypesCatalogSingleton Instance 
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
       
        public ObservableCollection<Types> getTypes()
        {
            GenericWebApiServices<Types> gTypes = new GenericWebApiServices<Types>(a_url);

            List<Types> tList = gTypes.getAll();
            return new ObservableCollection<Types>(tList);
        }

        public ObservableCollection<Types> allTypes 
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

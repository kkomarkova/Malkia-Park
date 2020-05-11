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
    class AnimalsCatalogSingleton: INotifyPropertyChanged
    {
        static string a_url = "/api/Animals";

        const string serverURL = "http://localhost:50617/";


        private AnimalsCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            animals = new ObservableCollection<Animals>();

            getAnimals();

        }

        private static AnimalsCatalogSingleton _Instance;


        private ObservableCollection<Animals> animals;
        public static AnimalsCatalogSingleton Instance // here its a public Instance for other classes to be able to use it 
        {
            get
            {
                return _Instance ?? (_Instance = new AnimalsCatalogSingleton());
            }
        }


        public int Count
        {
            get { return animals.Count; }


        }

        public ObservableCollection<Animals> Animals
        {
            get { return animals; }
        }


        

        public ObservableCollection<Animals> getAnimals()
        {
            GenericWebApiServices<Animals> gAnimal = new GenericWebApiServices<Animals>(serverURL, a_url);

            List<Animals> aList = gAnimal.getAll();
            return new ObservableCollection<Animals>(aList);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

using MalkiaMVVM.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.AllJoyn;

namespace MalkiaMVVM.Singleton
{
    public class AnimalsCatalogSingleton : INotifyPropertyChanged
    {
        static string a_url = "api/Animals";

        const string serverURL = "http://localhost:50948/";

       
        private AnimalsCatalogSingleton()
        {
            CurrentAnimal = new Animals();
            animals = new ObservableCollection<Animals>();
            animals = getAnimals();
            
        }

        private static AnimalsCatalogSingleton _Instance;


        private ObservableCollection<Animals> animals;
        public static AnimalsCatalogSingleton Instance 
        {
            get
            {
                return _Instance ?? (_Instance = new AnimalsCatalogSingleton());
            }
        }

        public Animals CurrentAnimal { get; set; }
        public int Count
        {
            get { return animals.Count; }

            set { }
        }

        public ObservableCollection<Animals> Animals
        {
            get { return animals; }
            
        }

        
        public ObservableCollection<Animals> getAnimals()
        {
            GenericWebApiServices<Animals> gAnimal = new GenericWebApiServices<Animals>( a_url);

            List<Animals> aList = gAnimal.getAll();
            return new ObservableCollection<Animals>(aList);
        }

        public void AddAnimal(Animals a)
        {
            GenericWebApiServices<Animals> newAnimals = new GenericWebApiServices<Animals>(a_url);
            newAnimals.createNewOne(a);
            OnPropertyChanged(nameof(animals));
            OnPropertyChanged(nameof(Count));
        }
         public void DeleteAnimal( int AId)
        {
            GenericWebApiServices<Animals> deleteAnimals = new GenericWebApiServices<Animals>(a_url);
            deleteAnimals.deleteOne(AId);
            OnPropertyChanged(nameof(animals));
            OnPropertyChanged(nameof(Count));

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

using MalkiaMVVM.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MalkiaMVVM.Singleton
{
    class AnimalsAdoptersCatalogSingleton: INotifyPropertyChanged
    {

        static string a_url = " api/AnimalsAdopters";

        const string serverURL = "http://localhost:59561/";

        private AnimalsAdoptersCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            animalsAdopters = new ObservableCollection<AnimalsAdopters>();

            //animalsAdopters.Add(new AnimalsAdopters() { AId = 3, OId = 101, Date = new DateTime(2019, 06, 25) });
            //animalsAdopters.Add(new AnimalsAdopters() { AId = 3, OId = 102, Date = new DateTime(2019, 05, 10) });

            animalsAdopters =getAnimalsAdopters();

        }

        public void AddAdoption(AnimalsAdopters s)
        {
            GenericWebApiServices<AnimalsAdopters> newAnimalsAdopters = new GenericWebApiServices<AnimalsAdopters>(a_url);
           newAnimalsAdopters.createNewOne(s);
            OnPropertyChanged(nameof(animalsAdopters));
            OnPropertyChanged(nameof(Count));
        }
        
        public void DeleteAdoption(AnimalsAdopters s)
        { 
            
            animalsAdopters.Remove(s);
            OnPropertyChanged(nameof(animalsAdopters));
            OnPropertyChanged(nameof(Count));
        }

        private static AnimalsAdoptersCatalogSingleton _Instance;


        private ObservableCollection<AnimalsAdopters> animalsAdopters;
        public static AnimalsAdoptersCatalogSingleton Instance // here its a public Instance for other classes to be able to use it 
        {
            get
            {
                return _Instance ?? (_Instance = new AnimalsAdoptersCatalogSingleton());
            }
        }


        public int Count
        {
            get { return animalsAdopters.Count; }


        }


        public ObservableCollection<AnimalsAdopters> AllAnimalsAdopters
        {
            get { return animalsAdopters; }
        }


        public ObservableCollection<AnimalsAdopters> getAnimalsAdopters()
        {
            GenericWebApiServices<AnimalsAdopters> gAnimalsAdopters = new GenericWebApiServices<AnimalsAdopters>( a_url);

            List<AnimalsAdopters> aList = gAnimalsAdopters.getAll();
            return new ObservableCollection<AnimalsAdopters>(aList);
        }

        
        public ObservableCollection<AnimalsAdopters> allAnimalsAdopters 
        {
            get
            {
                ObservableCollection<AnimalsAdopters> animalsAdopters = AllAnimalsAdopters;

                return new ObservableCollection<AnimalsAdopters>(getAnimalsAdopters());
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

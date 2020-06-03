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
    public class AnimalsAdoptersCatalogSingleton : INotifyPropertyChanged
    {

        static string a_url = " api/AnimalsAdopters";

        const string serverURL = "http://localhost:50948/";

        private AnimalsAdoptersCatalogSingleton()
        {
            CurrentAdoption = new AnimalsAdopters();
            animalsAdopters = new ObservableCollection<AnimalsAdopters>();
            animalsAdopters = getAnimalsAdopters();
        }
        private static AnimalsAdoptersCatalogSingleton _Instance;


        private ObservableCollection<AnimalsAdopters> animalsAdopters;
        public static AnimalsAdoptersCatalogSingleton Instance
        {
            get
            {
                return _Instance ?? (_Instance = new AnimalsAdoptersCatalogSingleton());
            }
        }
        public AnimalsAdopters CurrentAdoption {get;set;}

       
       
        public int Count
        {
            get { return animalsAdopters.Count; }

            set { }
        }

        public void AddAdoption(AnimalsAdopters s)
        {
            GenericWebApiServices<AnimalsAdopters> newAnimalsAdopters = new GenericWebApiServices<AnimalsAdopters>(a_url);
           newAnimalsAdopters.createNewOne(s);
            OnPropertyChanged(nameof(animalsAdopters));
            OnPropertyChanged(nameof(Count));

          
        }
        
        public void DeleteAdoption (int AdoptionId)
        {
           GenericWebApiServices<AnimalsAdopters> deleteAnimalsAdopters = new GenericWebApiServices<AnimalsAdopters>(a_url);
           deleteAnimalsAdopters.deleteOne(AdoptionId);

            OnPropertyChanged(nameof(animalsAdopters));
            OnPropertyChanged(nameof(Count));
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

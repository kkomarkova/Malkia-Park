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
    class AnimalsAdoptersCatalogSingleton: INotifyPropertyChanged
    {

        static string a_url = " /api/AnimalsAdopters";

        const string serverURL = "http://localhost:50617/";

        private AnimalsAdoptersCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            animalsAdopters = new ObservableCollection<AnimalsAdopters>();

            getAnimalsAdopters();

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

        public ObservableCollection<AnimalsAdopters> AnimalsAdopters
        {
            get { return animalsAdopters; }
        }


        
        public ObservableCollection<AnimalsAdopters> getAnimalsAdopters()
        {
            GenericWebApiServices<AnimalsAdopters> gAnimalsAdopters = new GenericWebApiServices<AnimalsAdopters>(serverURL, a_url);

            List<AnimalsAdopters> aaList = gAnimalsAdopters.getAll();
            return new ObservableCollection<AnimalsAdopters>(aaList);
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

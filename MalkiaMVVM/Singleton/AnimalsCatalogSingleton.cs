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
    class AnimalsCatalogSingleton : INotifyPropertyChanged
    {
        static string a_url = "/api/Animals";

        const string serverURL = "http://localhost:50617/";

        public TypesCatalogSingleton tcs { get; set; }
        private AnimalsCatalogSingleton()// the constructor for singleton patern have to be private 
        {
            animals = new ObservableCollection<Animals>();

            getAnimals();
            animals.Add(new Animals()
                {AId = 1, Image = "/Assets/Malkia.jpg", Dob = new DateTime(2013, 06, 25), Name = "Malkia", TId = 1017});
            animals.Add(new Animals
                { AId = 2, Image = "/Assets/Adelle.jpg", Dob = new DateTime(2014, 8, 15), Name = "Adele", TId = 1017 });
            animals.Add(new Animals()
                { AId = 3, Image = "/Assets/Benji.jpg", Dob = new DateTime(2016, 2, 17), Name = "Benji", TId = 1008 });

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

        public Animals Animal { get; set; }
        public int Count
        {
            get { return animals.Count; }


        }

        public ObservableCollection<Animals> Animals
        {
            get { return animals; }
        }
       
        public ObservableCollection<Animals> allAnimals

        {
            get
            {
                ObservableCollection<Animals> animals = Instance.Animals;
                return new ObservableCollection<Animals>(Instance.getAnimals());
                
            }

        }
        //public ObservableCollection<Animals>AnimalsOfType
        //{
        //    get
        //    {
        //        ObservableCollection<Animals> animalTypeList = new ObservableCollection<Animals>();
                 

        //         foreach( var a in allAnimals )
        //        {
                  

        //        }

        //        return animalTypeList;
        //    }
        //}
        

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

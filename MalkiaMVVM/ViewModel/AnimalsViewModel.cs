using MalkiaMVVM.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MalkiaMVVM.ViewModel
{
    class AnimalsViewModel
    {

        private string _image;
        private TypesCatalogSingleton tcs;
        private AnimalsCatalogSingleton acs;
        private AdoptersCatalogSingleton ocs;
        private AnimalsAdoptersCatalogSingleton aocs;
        private Animals _selectedAnimal;
        private Types _selectedType;
        private Types _typeDetails;


        public AnimalsViewModel()
        {
            _selectedAnimal = new Animals();
            _selectedType = new Types();
            _typeDetails = new Types();
            tcs = TypesCatalogSingleton.Instance;
            acs = AnimalsCatalogSingleton.Instance;
            ocs = AdoptersCatalogSingleton.Instance;
            aocs = AnimalsAdoptersCatalogSingleton.Instance;
        }

        public TypesCatalogSingleton KindCatalogSingleton { get; set; }
        public AnimalsCatalogSingleton AnimalcatalogSingleton { get; set; }
        public AnimalsAdoptersCatalogSingleton AnimalsAdoptersCatalogSingleton { get; set; }
        public AdoptersCatalogSingleton AdoptersCatalogSingleton { get; set; }

        public int AId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime Dob { get; set; }
        public int TId { get; set; }
        public string Type { get; set; }
        public string Origine { get; set; }
        public int El { get; set; }
        public int ZooMap { get; set; }

        public string Image
        {
            get => _image;
            set => _image = ApplicationData.Current.LocalFolder.Path + "\\" + value;

            
        }
       
        //public Animals SelectedAnimal
        //{
        //    get { return _selectedAnimal; }
        //    set 
        //    {
        //        //OnPropertyChanged(nameOf) 
                
        //    }
        //}

        //public Types TypeDetails
        //{
        //    get
        //    {
                
        //        return null;
        //    }
        //}

        public ObservableCollection<Types> allTypes // we just need get 
        {
            get
            {
                ObservableCollection<Types> types = tcs.AllTypes;
               
                return new ObservableCollection<Types>(tcs.getTypes());
            }
        }


        public ObservableCollection<Animals> allAnimals

        {
            get
            {
                ObservableCollection<Animals> animals = acs.Animals;
                return new ObservableCollection<Animals>(acs.getAnimals());
                //return acs.getAnimals();
            }

        }
    }
}


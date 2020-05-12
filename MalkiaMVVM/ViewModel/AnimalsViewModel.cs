using MalkiaMVVM.Common;
using MalkiaMVVM.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MalkiaMVVM.ViewModel
{
    class AnimalsViewModel:INotifyPropertyChanged
    {

        private string _image;
       
        private AnimalsCatalogSingleton acs;
        private AdoptersCatalogSingleton ocs;
        private AnimalsAdoptersCatalogSingleton aocs;
        private TypesCatalogSingleton tcs;
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

        public TypesCatalogSingleton TypesCatalogSingleton { get; set; }
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
         public int OId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image
        {
            get => _image;
            set => _image = ApplicationData.Current.LocalFolder.Path + "\\" + value;

            
        }

        public Animals SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged();
            }
        }
        public Types SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Animals> allAnimals

        {
            get
            {
                ObservableCollection<Animals> animals = acs.Animals;
                return new ObservableCollection<Animals>(acs.getAnimals());
               
            }

        }
        public ObservableCollection<Types> allTypes // we just need get 
        {
            get
            {
                ObservableCollection<Types> types = tcs.AllTypes;

                return new ObservableCollection<Types>(tcs.getTypes());
            }
        }




        //public ObservableCollection<Animals>animalOfType
        //{
        //    get
        //    {
                
        //        return new ObservableCollection<Animals>(acs.Where(a => a.TId == SelectedType.TId));


        //    }
        //}
        

        public RelayCommand DeleteCOmmand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


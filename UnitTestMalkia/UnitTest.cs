
using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using MalkiaMVVM.Singleton;
using MalkiaMVVM.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace UnitTestMalkia
{
    [TestClass]
    public class UnitTest1
    {

        AnimalsViewModel avm = new AnimalsViewModel();
        [TestMethod]
        public void ValidLogin()
        {
            string username = "rania";
            string password = "ra12";

            avm.Username = username;
            avm.Password = password;

            bool results = avm.LogIn();

            Assert.AreEqual(results, true);
        }

        [TestMethod]
        public void WrongUsername()
        {
            string username = "rani";
            string password = "ra12";

            avm.Username = username;
            avm.Password = password;

            bool results = avm.LogIn();

            Assert.AreEqual(results, false);
        }

        [TestMethod]
        public void WrongPassword()
        {

            string username = "rania";
            string password = "ra2";

            avm.Username = username;
            avm.Password = password;

            bool results = avm.LogIn();

            Assert.AreEqual(results, false);
        }


        [TestMethod]
        public void UsernameProperty()
        {
             avm.Username = "rania";
            string myUsername = avm.Username;
            Assert.AreEqual("rania", myUsername);
        }
        [TestMethod]
        public void PasswordProperty()
        {
            avm.Password = "ra12";
            string myPassword = avm.Password;
           
            Assert.AreEqual("ra12", myPassword);
        }

        [TestMethod]
       
        public void AnimalNameProperty()
        {
            
            avm.Name = "Malkia";
            string animalName = avm.Name ;
            Assert.AreEqual("Malkia", animalName);
        }
       
        [TestMethod]
        public void TypeProperty()
        {
            avm.Type = "Desert Lion";
             string type = avm.Type;
            
            Assert.AreEqual("Desert Lion", type);
        }
        [TestMethod]
        public void CountAnimals()
        {
            AnimalsCatalogSingleton.Instance.Count = 40;

           int animalsCount = AnimalsCatalogSingleton.Instance.Count ;

            Assert.AreEqual(40, animalsCount );
        }

        [TestMethod]
        public void CountTypes()
        {
            AnimalsCatalogSingleton.Instance.Count = 24;

            int typesCount = TypesCatalogSingleton.Instance.Count;

            Assert.AreEqual(24, typesCount);
        }
        [TestMethod]
        public void CountAnimalAdopters()
        {
            AnimalsAdoptersCatalogSingleton.Instance.Count = AnimalsAdoptersCatalogSingleton.Instance.Count + 1;

            int AnimaladoptersCount = AnimalsAdoptersCatalogSingleton.Instance.Count + 1;

            Assert.AreEqual(AnimalsAdoptersCatalogSingleton.Instance.Count + 1, AnimaladoptersCount);
        }

    }



    }


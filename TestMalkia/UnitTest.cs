
using System;
using MalkiaMVVM.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMalkia
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            AnimalsViewModel L = new AnimalsViewModel();
            string Username = "rania";
            string Password = "ra12";
            //Act
            L.Password = Password;
            L.Username = Username;
            bool Result = L.LogIn();
            //Assert
            Assert.AreEqual(true, Result);

        }
    }
}

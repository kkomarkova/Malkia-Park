using MalkiaMVVM.Singleton;
using MalkiaMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MalkiaMVVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        
        AnimalsViewModel evm = new AnimalsViewModel();
        
        public Login()
        {
            this.InitializeComponent();
           this.DataContext = evm;
          
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
           
            if (!evm.LogIn())
            {
                //textErrorText.Text = "Your username and or password is incorrect";
                //var message = new MessageDialog("Your username and or password is incorrect");
                //message.ShowAsync();
            }
            else
            { 
               evm.OpenPage();
                             
            }
        }

       

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void CancelAdoption_Click(object sender, RoutedEventArgs e)
        { 
            
        }

          private void UsernameAdopter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CancelAccount_Click(object sender, RoutedEventArgs e)
        {
            {
                   var message = new MessageDialog ( "are you sure?");
                
            }

        }
    }
}

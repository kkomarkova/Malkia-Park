using MalkiaMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AdminPage : Page
    {
        AnimalsViewModel avm = new AnimalsViewModel();
        public AdminPage()
        {
            this.InitializeComponent();
        }
         
        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            avm.CreateNewAnimal();
            Message.Text = "Successfully added";
          
        }
        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            avm.CancelAnimal();
            Message.Text = "Successfully deleted";

        }
        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            avm.CreateNewType();
            MessageType.Text = "Successfully added";

        }
        private void DeleteType_Click(object sender, RoutedEventArgs e)
        {
            avm.CancelType();
            MessageType.Text = "Successfully deleted";

        }
    }
}

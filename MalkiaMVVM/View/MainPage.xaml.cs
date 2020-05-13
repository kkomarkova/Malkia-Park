using MalkiaMVVM.Singleton;
using MalkiaMVVM.View;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MalkiaMVVM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(HomePage));
        }
        private void BtnHamburger_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void Animal_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AnimalsList));
            SplitView.IsPaneOpen = false;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SearchAnimal));
            SplitView.IsPaneOpen = false;
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Contact));
            SplitView.IsPaneOpen = false;
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Map));
            SplitView.IsPaneOpen = false;
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Rules));
            SplitView.IsPaneOpen = false;
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Information));
            SplitView.IsPaneOpen = false;
        }
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Adopt_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Adopt));
            SplitView.IsPaneOpen = false;
        }
        //private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        //{

        //}
    }
}

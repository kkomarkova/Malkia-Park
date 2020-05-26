using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class Contacts : Page
    {
        public Contacts()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {           
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 48.017260, Longitude = 17.529440 };
            Geopoint malkiacenter = new Geopoint(cityPosition);

            MyMap.Center = malkiacenter;
            MyMap.ZoomLevel = 12;
            MyMap.LandmarksVisible = true;

            Border border = new Border
            {
                Height = 100,
                Width = 100,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Maroon),
                BorderThickness = new Thickness(4),
            };
            MyMap.Center = malkiacenter;
            MyMap.ZoomLevel = 12;          
            MyMap.Children.Add(border);
            MapControl.SetLocation(border, malkiacenter);
            MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));
        }

        //Reference button

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.SetWebLink(new Uri("https://www.malkiapark.sk/en/"));
            args.Request.Data.Properties.Title = "Malkia Park Reference";
            args.Request.Data.Properties.Description = "Share your experience with us malkiapark@hotmail.com or with your friends";
            args.Request.Data.SetText("Hey, I just visited Malkia Park and I would like to tell you about my experience ...");
        }

        private void MenuFlyoutItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}

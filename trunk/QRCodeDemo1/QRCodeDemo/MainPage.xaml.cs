using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QRCodeDemo.Resources;
using Microsoft.Phone.Tasks;
using ZXing;
using System.Windows.Media.Imaging;

namespace QRCodeDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            img.Source = GenerateQRCode("sdasjdlsakdjaklsdjasklklghjsfdkghljgksdljgdskljgfdkljdkljglfdjglkdfjglkdfjklsad");

        }

        private void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {

        }

        private static WriteableBitmap GenerateQRCode(string s)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {
                Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 255) // blue
            };

            _writer.Format = BarcodeFormat.QR_CODE;



            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = 1;

            var barcodeImage = _writer.Write(s); //tel: prefix for phone numbers

            return barcodeImage;
        }

        private void btScan_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Scan.xaml", UriKind.RelativeOrAbsolute));
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}
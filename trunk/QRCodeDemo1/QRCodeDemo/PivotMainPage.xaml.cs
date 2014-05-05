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
using Newtonsoft.Json;
using Microsoft.Devices;
using System.Windows.Media.Imaging;
using ZXing;
using Windows.Phone.System.UserProfile;

namespace QRCodeDemo
{

    public partial class PivotMainPage : PhoneApplicationPage
    {
      

        private OpticalReaderLib.OpticalReaderTask _task = new OpticalReaderLib.OpticalReaderTask();
        private OpticalReaderLib.OpticalReaderResult _result = null;
        public PivotMainPage()
        {
            InitializeComponent();
            _task.Completed += OpticalReaderTask_Completed;
            BuildLocalizedApplicationBar();
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton_Scan = new ApplicationBarIconButton(new Uri("/Assets/AppBar/scan.png", UriKind.Relative));
            appBarButton_Scan.Text = "Scan";
            appBarButton_Scan.Click += appBarButton_Scan_Click;
            ApplicationBar.Buttons.Add(appBarButton_Scan);

            ApplicationBarIconButton appBarButton_MyQR = new ApplicationBarIconButton(new Uri("/Assets/AppBar/myQR.png", UriKind.Relative));
            appBarButton_MyQR.Text = "My QR";
            appBarButton_MyQR.Click += appBarButton_MyQR_Click;
            ApplicationBar.Buttons.Add(appBarButton_MyQR);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private void appBarButton_MyQR_Click(object sender, EventArgs e)
        {
            pvMain.SelectedIndex = 1;
        }

        void appBarButton_Scan_Click(object sender, EventArgs e)
        {
            if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary))
            {
               // _task.Show();
                NavigationService.Navigate(new Uri( "/ScanPage.xaml",UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Primary camera is not available!");
            }
        }

        private void OpticalReaderTask_Completed(object sender, OpticalReaderLib.OpticalReaderResult e)
        {
            _result = e;

            //string s = "{\"name\":\"nam\",\"phone\":\"0101021212\"}";
            string s = FormatString(e.Text);
            Contact ct;
            if (s != null)
                ct = JsonConvert.DeserializeObject<Contact>(FormatString(s));
        }

        string FormatString(string s)
        {
            if (!string.IsNullOrEmpty(s))
                return s.Replace("\\\"", "\"");
            else return null;
        }

        private void pvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(pvMain.SelectedIndex)
            {
                case 0:
                    img.Source = GenerateQRCode("dasjkdhaskjdhaskjdhsakjdhaskjdhsajkd",1);
                    break;
                case 1:

                    break;
                default: break;
            }
        }

        private static WriteableBitmap GenerateQRCode(string s, int margin)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {
                Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 255) // blue
            };

            _writer.Format = BarcodeFormat.QR_CODE;



            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = margin;

            var barcodeImage = _writer.Write(s); //tel: prefix for phone numbers

            return barcodeImage;
        }

        string stUri = "isostore:/Shared/ShellContent/336x336.jpg";
        string stUri1 = "isostore:/Shared/ShellContent/691x336.jpg";
        string stUri2 = "ms-appdata:///Local/Shared/ShellContent/800x480.jpg";
        private ShellTileData CreateFlipTileData()
        {
            return new FlipTileData()
            {

                SmallBackgroundImage = new Uri(stUri, UriKind.Absolute),
                BackgroundImage = new Uri(stUri, UriKind.Absolute),
                WideBackgroundImage = new Uri(stUri1, UriKind.Absolute),
            };
        }
        private async void SetLockScreen()
        {

            if (!LockScreenManager.IsProvidedByCurrentApplication)
            {

                await LockScreenManager.RequestAccessAsync();
            }


            if (LockScreenManager.IsProvidedByCurrentApplication)
            {

                Uri imageUri = new Uri(stUri2, UriKind.RelativeOrAbsolute);
                LockScreen.SetImageUri(imageUri);
            }
        }
        private void BtLockScreen_Click(object sender, RoutedEventArgs e)
        {
            SetLockScreen();
        }

        private void BtPin_Click(object sender, RoutedEventArgs e)
        {
            ShellTile oTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("flip".ToString()));
            if (oTile != null && oTile.NavigationUri.ToString().Contains("flip"))
            {
                FlipTileData oFliptile = new FlipTileData();
                oFliptile.SmallBackgroundImage = new Uri(stUri, UriKind.Absolute);

                oFliptile.BackgroundImage = new Uri(stUri, UriKind.Absolute);
                oFliptile.WideBackgroundImage = new Uri(stUri1, UriKind.Absolute);

                oFliptile.BackBackgroundImage = new Uri(stUri, UriKind.Absolute);
                oFliptile.WideBackBackgroundImage = new Uri(stUri1, UriKind.Absolute);
                oTile.Update(oFliptile);

            }
            else
            {
                // once it is created flip tile
                Uri tileUri = new Uri("/MainPage.xaml?tile=flip", UriKind.Relative);
                ShellTileData tileData = this.CreateFlipTileData();
                ShellTile.Create(tileUri, tileData, true);
            }
        }

    }
}
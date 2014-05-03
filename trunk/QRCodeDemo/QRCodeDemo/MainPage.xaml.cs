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
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Xna.Framework.Media;
using System.Windows.Resources;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Microsoft.Phone;
using Windows.Phone.System.UserProfile;


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
            string contact ="{\"name\":\"Nguyen Si Thang\",\"phone\":\"01632169553\"}";
            img.Source = GenerateQRCode(contact);
            WriteableBitmap wb = GenerateQRCode(contact);
            WriteableBitmap wb1 = GenerateQRCodeLockScreen(contact);
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (myIsolatedStorage.FileExists("Shared\\ShellContent\\336x336.jpg") || myIsolatedStorage.FileExists("Shared\\ShellContent\\691x336.jpg") || myIsolatedStorage.FileExists("Shared\\ShellContent\\800x480.jpg"))
                    {
                        myIsolatedStorage.DeleteFile("Shared\\ShellContent\\336x336.jpg");
                        myIsolatedStorage.DeleteFile("Shared\\ShellContent\\691x336.jpg");
                        myIsolatedStorage.DeleteFile("Shared\\ShellContent\\800x480.jpg");

                    }
                    IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile("Shared\\ShellContent\\336x336.jpg");
                    IsolatedStorageFileStream fileStream1 = myIsolatedStorage.CreateFile("Shared\\ShellContent\\691x336.jpg");
                    IsolatedStorageFileStream fileStream2 = myIsolatedStorage.CreateFile("Shared\\ShellContent\\800x480.jpg");

                    wb.SaveJpeg(fileStream,336,336, 0, 100);
                    wb.SaveJpeg(fileStream1,691,336, 0, 100);
                    wb1.SaveJpeg(fileStream2,800,480, 0, 100);
                    fileStream.Close();
                    fileStream1.Close();
                    fileStream2.Close();

                }
            }
            

        }
       

        private void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {

        }
        private static WriteableBitmap GenerateQRCode(string s)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {//102, 51, 0(255, 0, 0, 255)
                Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 255)// blue
            };

            _writer.Format = BarcodeFormat.QR_CODE;
            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = 1;

            var barcodeImage = _writer.Write(s); //tel: prefix for phone numbers

            return barcodeImage;

        }
        private static WriteableBitmap GenerateQRCodeLockScreen(string s)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {//102, 51, 0(255, 0, 0, 255)
                Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 255),// blue
                Background = System.Windows.Media.Color.FromArgb(255,255,125,0)
            };

            _writer.Format = BarcodeFormat.QR_CODE;
            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = 35;

            var barcodeImage = _writer.Write(s); //tel: prefix for phone numbers

            return barcodeImage;

        }
        private void btScan_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Scan.xaml", UriKind.RelativeOrAbsolute));
        }
        string stUri = "isostore:/Shared/ShellContent/336x336.jpg";
        string stUri1 = "isostore:/Shared/ShellContent/691x336.jpg";
        string stUri2 = "ms-appdata:///Local/Shared/ShellContent/800x480.jpg";

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //SetLockScreen();

            //Pin to start with Flip
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
        private ShellTileData CreateFlipTileData()
        {
            return new FlipTileData()
            {

                SmallBackgroundImage = new Uri(stUri, UriKind.Absolute),
                BackgroundImage = new Uri(stUri, UriKind.Absolute),
                WideBackgroundImage = new Uri(stUri1, UriKind.Absolute),
            };
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
       
    }
}
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
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone;
using System.Windows.Threading;
using QRCodeDemo.WebService;
using Microsoft.Phone.Tasks;

namespace QRCodeDemo
{

    public partial class PivotMainPage : PhoneApplicationPage
    {

        public PivotMainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (!IsolatedData.isSignedIn && IsolatedData.LaunchCount == 1 && NavigationContext.QueryString["cancel"]!="1")
            {
                QRCodeDemo.App.RootFrame.Navigate(new Uri("/SignUp.xaml", UriKind.Relative));
            }
            ReadFromIsolatedStorage("/Shared/ShellContent/336x336.jpg");

            if (pvMain.SelectedItem == ScanItem)
            {
                if (!cameraInitialized)
                {
                    _phoneCamera = new PhotoCamera();
                    _phoneCamera.Initialized += cam_Initialized;
                    _phoneCamera.AutoFocusCompleted += _phoneCamera_AutoFocusCompleted;

                    CameraButtons.ShutterKeyHalfPressed += CameraButtons_ShutterKeyHalfPressed;

                    //Display the camera feed in the UI
                    viewfinderBrush.SetSource(_phoneCamera);


                    // This timer will be used to scan the camera buffer every 250ms and scan for any barcodes
                    _scanTimer = new DispatcherTimer();
                    _scanTimer.Interval = TimeSpan.FromMilliseconds(250);
                    _scanTimer.Tick += (o, arg) => ScanForBarcode();

                    viewfinderCanvas.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(focus_Tapped);
                    cameraInitialized = true;
                }
            }

            base.OnNavigatedFrom(e);
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

            ApplicationBarIconButton appBarButton_Generate = new ApplicationBarIconButton(new Uri("/Assets/AppBar/generate.png", UriKind.Relative));
            appBarButton_Generate.Text = "Generate";
            appBarButton_Generate.Click += appBarButton_Generate_Click;
            ApplicationBar.Buttons.Add(appBarButton_Generate);

            ApplicationBarIconButton appBarButton_Setting = new ApplicationBarIconButton(new Uri("/Assets/AppBar/feature.settings.png", UriKind.Relative));
            appBarButton_Setting.Text = "Setting";
            appBarButton_Setting.Click += appBarButton_Setting_Click;
            ApplicationBar.Buttons.Add(appBarButton_Setting);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        void appBarButton_Setting_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));

        }

        void appBarButton_Generate_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Generate.xaml", UriKind.Relative));

        }

        private void appBarButton_MyQR_Click(object sender, EventArgs e)
        {
            pvMain.SelectedItem = MyQRItem;
        }

        void appBarButton_Scan_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FriendList.xaml", UriKind.Relative));
            if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary))
            {
                pvMain.SelectedItem = ScanItem;
               

            }
            else
            {
                MessageBox.Show("Primary camera is not available!");
            }
        }



        string FormatString(string s)
        {
            if (!string.IsNullOrEmpty(s))
                return s.Replace("\\\"", "\"");
            else return null;
        }
        private void ReadFromIsolatedStorage(string fileName)
        {

            WriteableBitmap bitmap = new WriteableBitmap(200, 200);
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                    {
                        // Decode the JPEG stream.
                        bitmap = PictureDecoder.DecodeJpeg(fileStream);
                        img.Source = bitmap;

                    }
                }
                else
                {
                    BitmapImage tn = new BitmapImage();
                    tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/SquareTile71x71.png", UriKind.Relative)).Stream);
                    img.Source = tn;
                }

            }
        }

        bool cameraInitialized=false;
        private void pvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (pvMain.SelectedIndex)
            {
                case 0:
                    ReadFromIsolatedStorage("/Shared/ShellContent/336x336.jpg");
                    break;
                case 2:
                    if (!cameraInitialized)
                    // Initialize the camera object
                    {
                        _phoneCamera = new PhotoCamera();
                        _phoneCamera.Initialized += cam_Initialized;
                        _phoneCamera.AutoFocusCompleted += _phoneCamera_AutoFocusCompleted;

                        CameraButtons.ShutterKeyHalfPressed += CameraButtons_ShutterKeyHalfPressed;

                        //Display the camera feed in the UI
                        viewfinderBrush.SetSource(_phoneCamera);


                        // This timer will be used to scan the camera buffer every 250ms and scan for any barcodes
                        _scanTimer = new DispatcherTimer();
                        _scanTimer.Interval = TimeSpan.FromMilliseconds(250);
                        _scanTimer.Tick += (o, arg) => ScanForBarcode();

                        viewfinderCanvas.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(focus_Tapped);
                        cameraInitialized = true;
                    }
                    break;
                default:
                    
                    break;
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

        private void img_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Generate.xaml", UriKind.Relative));

        }





        private PhotoCamera _phoneCamera;
        private IBarcodeReader _barcodeReader;
        private DispatcherTimer _scanTimer;
        private WriteableBitmap _previewBuffer;

        void _phoneCamera_AutoFocusCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                focusBrackets.Visibility = Visibility.Collapsed;
            });
        }

        void focus_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                if (_phoneCamera != null)
                {
                    if (_phoneCamera.IsFocusAtPointSupported == true)
                    {
                        // Determine the location of the tap.
                        Point tapLocation = e.GetPosition(viewfinderCanvas);

                        // Position the focus brackets with the estimated offsets.
                        focusBrackets.SetValue(Canvas.LeftProperty, tapLocation.X - 30);
                        focusBrackets.SetValue(Canvas.TopProperty, tapLocation.Y - 28);

                        // Determine the focus point.
                        double focusXPercentage = tapLocation.X / viewfinderCanvas.ActualWidth;
                        double focusYPercentage = tapLocation.Y / viewfinderCanvas.ActualHeight;

                        // Show the focus brackets and focus at point.
                        focusBrackets.Visibility = Visibility.Visible;
                        _phoneCamera.FocusAtPoint(focusXPercentage, focusYPercentage);
                    }
                }
            }
            catch
            {
            }
        }

        void CameraButtons_ShutterKeyHalfPressed(object sender, EventArgs e)
        {
            _phoneCamera.Focus();
        }

        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //we're navigating away from this page, we won't be scanning any barcodes
            if (cameraInitialized)
            {
                _scanTimer.Stop();

                if (_phoneCamera != null)
                {
                    // Cleanup
                    _phoneCamera.Dispose();
                    _phoneCamera.Initialized -= cam_Initialized;
                    CameraButtons.ShutterKeyHalfPressed -= CameraButtons_ShutterKeyHalfPressed;
                    cameraInitialized = false;

                }
            }
        }

        

        void cam_Initialized(object sender, Microsoft.Devices.CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                this.Dispatcher.BeginInvoke(delegate()
                {
                    _phoneCamera.FlashMode = FlashMode.Off;
                    _previewBuffer = new WriteableBitmap((int)_phoneCamera.PreviewResolution.Width, (int)_phoneCamera.PreviewResolution.Height);

                    _barcodeReader = new BarcodeReader();
                    _barcodeReader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE };
                    // By default, BarcodeReader will scan every supported barcode type
                    // If we want to limit the type of barcodes our app can read, 
                    // we can do it by adding each format to this list object

                    //var supportedBarcodeFormats = new List<BarcodeFormat>();
                    //supportedBarcodeFormats.Add(BarcodeFormat.QR_CODE);
                    //supportedBarcodeFormats.Add(BarcodeFormat.DATA_MATRIX);
                    //_bcReader.PossibleFormats = supportedBarcodeFormats;

                    _barcodeReader.Options.TryHarder = true;

                    _barcodeReader.ResultFound += _bcReader_ResultFound;
                    _scanTimer.Start();
                });
            }
            else
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Unable to initialize the camera");
                });
            }
        }

        void _bcReader_ResultFound(Result obj)
        {
            // If a new barcode is found, vibrate the device and display the barcode details in the UI
            try
            {
                if (!obj.Text.Equals(tbBarcodeData.Text))
                {
                    VibrateController.Default.Start(TimeSpan.FromMilliseconds(100));
                    tbBarcodeData.Text = obj.Text;
                    ct = JsonConvert.DeserializeObject<MyContact>(obj.Text);

                    tbBarcodeData.Text = "Name:" + ct.name + "\nPhone number:" + ct.phone + "\nEmail:" + ct.email + "\nAddress:" + ct.address + "\nBirthday:" + ct.birthday.ToShortDateString() + "\nWebsite:" + ct.website;

                    ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                    btn.IconUri = new Uri("/Assets/AppBar/save.png", UriKind.Relative);
                    btn.Text = "Save";
                    btn.Click -= appBarButton_Scan_Click;
                    btn.Click += appBarButton_Save_Click;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Cannot get contact's information from this image\n" + ex.Message);
            }
        }
        MyContact ct;
        private void ScanForBarcode()
        {
            //grab a camera snapshot
            _phoneCamera.GetPreviewBufferArgb32(_previewBuffer.Pixels);
            _previewBuffer.Invalidate();

            //scan the captured snapshot for barcodes
            //if a barcode is found, the ResultFound event will fire
            _barcodeReader.Decode(_previewBuffer);

        }

        private void BuildLocalizedApplicationBar2()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsVisible = false;
            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton_Save = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButton_Save.Text = "Save";
            appBarButton_Save.Click += appBarButton_Save_Click;
            ApplicationBar.Buttons.Add(appBarButton_Save);




        }



        void appBarButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationBarIconButton bt = (ApplicationBarIconButton)sender;
                bt.Text = "scan";
                bt.Click -= appBarButton_Save_Click;
                bt.Click += appBarButton_Scan_Click;
                bt.IconUri = new Uri("/Assets/AppBar/scan.png", UriKind.Relative);

                var saveContact = new SaveContactTask();
                saveContact.Completed += saveContact_Completed;
                saveContact.FirstName = ct.name;

                saveContact.HomeAddressCity = ct.address;

                string[] s = ct.phone.Split('|');
                saveContact.MobilePhone = s[0];
                saveContact.WorkPhone = s[1];
                saveContact.HomePhone = s[2];

                s = ct.address.Split('|');
                saveContact.HomeAddressStreet = s[0];
                saveContact.WorkAddressStreet = s[1];

                s = ct.email.Split('|');
                saveContact.PersonalEmail = s[0];
                saveContact.WorkEmail = s[1];
                saveContact.OtherEmail = s[2];

                saveContact.Website = ct.website;

                saveContact.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Cannot save this contact to your phone\nDetail: " + ex.Message);
            }

           

        }

        void saveContact_Completed(object sender, SaveContactResult e)
        {
            switch (e.TaskResult)
            {
                //Logic for when the contact was saved successfully
                case TaskResult.OK:
                    MessageBox.Show("Contact saved.");
                    break;

                //Logic for when the task was cancelled by the user
                case TaskResult.Cancel:
                    MessageBox.Show("Save cancelled.");
                    break;

                //Logic for when the contact could not be saved
                case TaskResult.None:
                    MessageBox.Show("Contact could not be saved.");
                    break;
            }
        }
    }
}
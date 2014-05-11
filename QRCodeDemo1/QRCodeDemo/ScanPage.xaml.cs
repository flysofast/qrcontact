using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using ZXing.QrCode;
using Microsoft.Devices;
using ZXing;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Newtonsoft.Json;
using QRCodeDemo.WebService;
using Microsoft.Phone.Tasks;

namespace QRCodeDemo
{
    public partial class ScanPage : PhoneApplicationPage
    {
        private PhotoCamera _phoneCamera;
        private IBarcodeReader _barcodeReader;
        private DispatcherTimer _scanTimer;
        private WriteableBitmap _previewBuffer;

        public ScanPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Initialize the camera object
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
            base.OnNavigatedTo(e);
        }

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
            _scanTimer.Stop();

            if (_phoneCamera != null)
            {
                // Cleanup
                _phoneCamera.Dispose();
                _phoneCamera.Initialized -= cam_Initialized;
                CameraButtons.ShutterKeyHalfPressed -= CameraButtons_ShutterKeyHalfPressed;

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
                    tbBarcodeType.Text = obj.BarcodeFormat.ToString();
                    tbBarcodeData.Text = obj.Text;
                    ct = new MyContact();
                    string s = JsonConvert.SerializeObject(ct);
                   // string s2 = "{\"name\":\"Nguyen Si Thang\",\"phone\":\"06356565849\",\"email\":\"sithangvngb@gmail.com\",\"address\":\"hue jvj j \",\"website\":null,\"birthday\":\"1992-09-23T00:00:00\"}";
                    MessageBox.Show(tbBarcodeData.Text + "\n" + s+"\n"+tbBarcodeType.Text);
                    ct = JsonConvert.DeserializeObject<MyContact>(obj.Text);
                    tbBarcodeData.Text = "Name:" + ct.name + "\nPhone number:" + ct.phone + "\nEmail:" + ct.email + "\nAddress:" + ct.address + "\nBirthday:" + ct.birthday.ToShortDateString() + "\nWebsite:" + ct.website;

                    ApplicationBar.IsVisible = true;

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

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsVisible = false;
            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton_Save = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButton_Save.Text = "Save";
            appBarButton_Save.Click += appBarButton_Save_Click;
            ApplicationBar.Buttons.Add(appBarButton_Save);

            ApplicationBarIconButton appBarButton_Cancel = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancel.png", UriKind.Relative));
            appBarButton_Cancel.Text = "Cancel";
            appBarButton_Cancel.Click += appBarButton_Cancel_Click;
            ApplicationBar.Buttons.Add(appBarButton_Cancel);


        }

        void appBarButton_Cancel_Click(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
            else NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));
            

        }

        void appBarButton_Save_Click(object sender, EventArgs e)
        {
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
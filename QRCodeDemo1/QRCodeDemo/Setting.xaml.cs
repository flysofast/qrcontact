using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace QRCodeDemo
{
    public partial class Setting : PhoneApplicationPage
    {

        int i=0,j = 0;
        string QrcodeColor =IsolatedData.appSettings.QrcodeColor, BackgroundCode=IsolatedData.appSettings.BackgroundQrCode;
        
        public Setting()
        {
            InitializeComponent();
        }
        public static Color HexColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(QrcodeColor!=null&& BackgroundCode!=null)
            {
                CpBacground.Color = HexColor(BackgroundCode);
                CpQrcode.Color = HexColor(QrcodeColor);
            }
            else
            {
                CpBacground.Color = Color.FromArgb(255, 0, 0, 255);
                CpQrcode.Color = Color.FromArgb(255,255,255,255);
            }
            base.OnNavigatedTo(e);
        }
        public void ReadAppSetting()
        {
            ReadAppSetting();
        }
        public void WriteAppSetting()
        {
            AppSetting a = IsolatedData.appSettings;
            a.QrcodeColor =QrcodeColor;
            a.BackgroundQrCode = BackgroundCode;
            IsolatedData.appSettings = a;
        }
        private void TbBackgrioundCorlor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (i == 0)
            {
                CpBacground.Visibility = Visibility.Collapsed;
                i = 1;
            }
            else
                if (i == 1)
                {
                    CpBacground.Visibility = Visibility.Visible;
                    i = 0;
                }
        }

        private void TbQrCodeColor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (j == 0)
            {
                CpQrcode.Visibility = Visibility.Collapsed;
                j = 1;
            }
            else
            if (j == 1)
            {
                CpQrcode.Visibility = Visibility.Visible;
                j = 0;
            }
        }

        private void CpQrcode_ColorChanged(object sender, System.Windows.Media.Color color)
        {
            QrcodeColor = color.ToString();
           // MessageBox.Show(color.ToString());
        }

        private void CpBacground_ColorChanged(object sender, System.Windows.Media.Color color)
        {
            BackgroundCode = color.ToString();
        }

        private void AppBarSave_Click(object sender, EventArgs e)
        {
            WriteAppSetting();
            //if (NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
            //else
            {
                NavigationService.Navigate(new Uri("/Generate.xaml", UriKind.Relative));

            }
        }

        private void CbAllowShare_Click(object sender, RoutedEventArgs e)
        {
            if(IsolatedData.isSignedIn)
            {
                CbAllowShare.IsChecked = true;
            }
            else
            {
               if (MessageBox.Show("Login or Sign Up to Share", "Note", MessageBoxButton.OKCancel)==MessageBoxResult.OK)
                {
                    NavigationService.Navigate(new Uri("/SignUp.xaml", UriKind.Relative));
                }
               else
               {
                   if(NavigationService.CanGoBack)
                   {
                       NavigationService.GoBack();
                   }
                   else
                   {
                       NavigationService.Navigate(new Uri("/SignUp.xaml", UriKind.Relative));

                   }
               }
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace QRCodeDemo
{
    public partial class Setting : PhoneApplicationPage
    {
        int i=0,j = 0;
        string QrcodeColor,BackgroundCode;
        
        public Setting()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        public void ReadAppSetting()
        {
            ReadAppSetting();
        }
        public void WriteAppSetting()
        {

        }
        private void TbBackgrioundCorlor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(i==0)
            {
                CpBacground.Visibility = Visibility.Collapsed;
                i = 1;
            }
            else
            if(i==1)
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
        }

        private void CpBacground_ColorChanged(object sender, System.Windows.Media.Color color)
        {
            BackgroundCode = color.ToString();
        }

        private void AppBarSave_Click(object sender, EventArgs e)
        {
            WriteAppSetting();
        }
    }
}
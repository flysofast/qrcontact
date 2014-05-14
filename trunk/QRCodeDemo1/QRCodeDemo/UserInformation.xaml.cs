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
    public partial class UserInformation : PhoneApplicationPage
    {
        public UserInformation()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UserInfo a = new UserInfo();
            MessageBox.Show(a.username);
            base.OnNavigatedTo(e);
        }
      

        private void BtChangePass_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtChangePass_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
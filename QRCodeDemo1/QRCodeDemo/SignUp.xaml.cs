using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace QRCodeDemo
{
    public partial class SignUp : PhoneApplicationPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            tbRepassword.Visibility = Visibility.Visible;
            lbRePassword.Visibility = Visibility.Visible;
            if (tbRepassword.Text != tbPassword.Text)
            {
                MessageBox.Show("Passwords don't match!");
                return;
            }

            try
            {
                

                int su = await WebServiceHelper.SignUp(tbUsername.Text, tbPassword.Text);

                if (su == 2) MessageBox.Show("This username has already existed!");
                else if (su == 1) MessageBox.Show("Signed up successfully!");
                else MessageBox.Show("Cannot sign up");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            tbRepassword.Visibility = Visibility.Collapsed;
            lbRePassword.Visibility = Visibility.Collapsed;
         
            ProgressIndicator progress = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = "Downloading details..."
            };
            SystemTray.SetProgressIndicator(this, progress);
            //if (tbRepassword.Text != tbPassword.Text)
            //{
            //    MessageBox.Show("Passwords don't match!");
            //    return;
            //}

            //try
            //{
            //    int su = await WebServiceHelper.SignIn(tbUsername.Text, tbPassword.Text);


            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
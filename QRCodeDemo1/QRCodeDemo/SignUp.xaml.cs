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
using System.Windows.Input;

namespace QRCodeDemo
{
    public partial class SignUp : PhoneApplicationPage
    {
        public SignUp()
        {
            if (IsolatedData.isSignedIn)
            {
                MessageBox.Show("You have already signed in");
                NavigationService.Navigate(new Uri ("/PivotMainPage.xaml", UriKind.Relative));
            }
            InitializeComponent();
            rdSignUp.IsChecked = true;
            rdSignUp.Checked+=rdSignUp_Checked;
        }

       
        private async void btSubmit_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("You must fill in all fields ");
                return;
            }

            ProgressIndicator progress = new ProgressIndicator
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = "Connecting to server..."
            };
            SystemTray.SetProgressIndicator(this, progress);

            if (rdSignIn.IsChecked==true)
            {
                int si = await WebServiceHelper.SignIn(tbUsername.Text, tbPassword.Text);

                progress.IsVisible = false;
                progress.IsIndeterminate = false;
                if (si > 0)
                {
                    MessageBox.Show("Signed in successfully!");
                    UserInfo uinfo = new UserInfo();
                    uinfo.password = tbPassword.Text;
                    uinfo.username = tbUsername.Text;
                    uinfo.contactData.id = si;
                    IsolatedData.userInfo = uinfo;
                    IsolatedData.isSignedIn = true;
                }
                else MessageBox.Show("Sign in failed");



            }
            else
            {
                if (tbRepassword.Text != tbPassword.Text)
                {
                    MessageBox.Show("Passwords don't match!");
                    return;
                }

                try
                {
                  
                    int su = await WebServiceHelper.SignUp(tbUsername.Text, tbPassword.Text);
                    progress.IsVisible = false;
                    progress.IsIndeterminate = false;
                    if (su == 2) MessageBox.Show("This username has already existed!");
                    else if (su == 1) MessageBox.Show("Signed up successfully!");
                    else MessageBox.Show("Sign up failed");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
           
        }

        private void BtSkip_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotMainPage.xaml", UriKind.Relative));

        }

        private void rdSignUp_Checked(object sender, RoutedEventArgs e)
        {
           
            tbRepassword.Visibility = Visibility.Visible;
            lbRePassword.Visibility = Visibility.Visible;
        }

        private void rdSignIn_Checked(object sender, RoutedEventArgs e)
        {
            tbRepassword.Visibility = Visibility.Collapsed;
            lbRePassword.Visibility = Visibility.Collapsed;
        }

        private void tbPassword_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btSubmit_Click(btLogIn, new RoutedEventArgs() );
            }
        }
    }
}
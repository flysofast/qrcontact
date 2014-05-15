using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace QRCodeDemo
{
    public partial class ContactDetail : PhoneApplicationPage
    {
        FriendsContactInfo contact;
        public ContactDetail()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsVisible = false;

            ApplicationBarIconButton appBarButton_Save = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButton_Save.Text = "save";
            appBarButton_Save.Click += appBarButton_Save_Click;
            ApplicationBar.Buttons.Add(appBarButton_Save);

          

           
        }

        private void appBarButton_Save_Click(object sender, EventArgs e)
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string encodedValue = NavigationContext.QueryString["nick"];
            string nickname = Uri.UnescapeDataString(encodedValue);
            contact = FriendContactList.GetContacts(true).friendList.FirstOrDefault(p => p.nickname == nickname);

            cbkShare.IsChecked = contact.shareMyContactInfo;
            cbkShare.Checked += cbkShare_Checked;
            tbNickname.Text = contact.nickname;
            string[] values;

            if (!string.IsNullOrEmpty(contact.contactInfo.phone))
            {
                values = contact.contactInfo.phone.Split('\n');
                tbPhoneNumber1.Text = values[0];
                tbPhoneNumberText1.Text = values[0];
                if (values.Count() >= 2)
                {
                    tbPhoneNumber2.Text = values[1];
                    tbPhoneNumberText2.Text = values[1];
                    if (values.Count() >= 3)
                    {
                        tbPhoneNumberText3.Text = values[2];
                        tbPhoneNumber3.Text = values[2];
                    }
                }

            }
            else
            {
                grdPhone.Visibility = Visibility.Collapsed;
            }

            if (!string.IsNullOrEmpty(contact.contactInfo.email))
            {
                values = contact.contactInfo.email.Split('|');
                tbEmail1.Text = values[0];
                if (values.Count() >= 2)
                {
                    tbEmail2.Text = values[1];
                    if (values.Count() >= 3)
                    {
                        tbEmail3.Text = values[2];
                    }
                }
            }
            else
            {
                grdEmail.Visibility = Visibility.Collapsed;
            }

            if (!string.IsNullOrEmpty(contact.contactInfo.address))
            {
                values = contact.contactInfo.address.Split('|');
                tbAdd1.Text = values[0];
                if (values.Count() >= 2)
                    tbAdd2.Text = values[1];
            }
            else
            {
                grdAddress.Visibility = Visibility.Collapsed;
            }

            if (contact.contactInfo.birthday != new DateTime())
            {
                tbBirthday.Text = contact.contactInfo.birthday.ToShortDateString();
            }
            else grdBirthday.Visibility = Visibility.Collapsed;

            if (!string.IsNullOrEmpty(contact.contactInfo.website))
                tbWebsite.Text = contact.contactInfo.website;
            else grdWebsite.Visibility = Visibility.Collapsed;


        }

        void cbkShare_Checked(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = !ApplicationBar.IsVisible;
        }

        private void tbPhoneNumber_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = ((TextBlock)sender).Text;
            phoneCallTask.DisplayName = tbNickname.Text;
            phoneCallTask.Show();
        }

        private void tbPhoneNumberText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SmsComposeTask smsTask = new SmsComposeTask();
            smsTask.To = ((TextBlock)sender).Text;
            smsTask.Show();
        }

        private void tbPhoneNumberEmail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Cc = ((TextBlock)sender).Text;
            emailTask.Show();


        }

        private void cbkShare_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = !ApplicationBar.IsVisible;
        }




    }
}
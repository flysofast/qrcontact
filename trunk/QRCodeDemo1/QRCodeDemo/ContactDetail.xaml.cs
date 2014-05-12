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
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string encodedValue = NavigationContext.QueryString["nick"];
           string  nickname = Uri.UnescapeDataString(encodedValue);
           contact = FriendContactList.GetContacts(true).friendList.FirstOrDefault(p => p.nickname == nickname);

           tbNickname.Text = contact.nickname;
           string[] values;

           if (!string.IsNullOrEmpty(contact.contactInfo.phone))
           {
               values = contact.contactInfo.phone.Split('\n');
               tbPhoneNumber1.Text = values[0];
               tbPhoneNumber2.Text = values[1];
               tbPhoneNumber3.Text = values[2];

               tbPhoneNumberText1.Text = values[0];
               tbPhoneNumberText2.Text = values[1];
               tbPhoneNumberText3.Text = values[2]; 
           }
           else
           {
               grdPhone.Visibility = Visibility.Collapsed;
           }

           if (!string.IsNullOrEmpty(contact.contactInfo.email))
           {
               values = contact.contactInfo.email.Split('|');
               tbEmail1.Text = values[0];
               tbEmail2.Text = values[1];
               tbEmail3.Text = values[2];
           }
           else
           {
               grdEmail.Visibility = Visibility.Collapsed;
           }

           if (!string.IsNullOrEmpty(contact.contactInfo.address))
           {
               values = contact.contactInfo.address.Split('|');
               tbAdd1.Text = values[0];
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



    }
}
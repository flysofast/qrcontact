using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;
using QRCodeDemo.WebService;

namespace QRCodeDemo
{
    public partial class ContactList : PhoneApplicationPage
    {
        public ContactList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
           
            
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts cons = new Contacts();
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");




         //   int s = await WebServiceHelper.GetContactList(1,"2");
          //  MessageBox.Show(s.ToString());






        }

        void  Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            //Do something with the results.

            //Microsoft.Phone.UserData.Contact a = e.Results.Single(p => p.CompleteName.FirstName != "A");
            //MessageBox.Show(a.PhoneNumbers.First().PhoneNumber);
            IEnumerable<Contact> contacts = e.Results; //Here your result
            string everynames = "";
            foreach (var item in contacts)
            {
                //We can get attributes from each item
               // everynames += (item.PhoneNumbers.Count() > 0 ? (item.PhoneNumbers.FirstOrDefault()).PhoneNumber + ";" : "");
                foreach (var sdt in item.PhoneNumbers)
                {
                    everynames += sdt.PhoneNumber + "|";
                   
                }
            }
            string res = everynames;
            while (true)
            {
                int index1 = res.IndexOf('(');
                int index2 = res.IndexOf(')');
                int index3 = res.IndexOf('-');
                if (index1 != -1)
                {
                    res = res.Remove(index1, 1); // Use integer from IndexOf.

                }
                if (index2 != -1)
                {
                    res = res.Remove(index2, 1); // Use integer from IndexOf.

                }
                if (index3 != -1)
                {
                    res = res.Remove(index3, 1); // Use integer from IndexOf.

                }
                if (index1 == -1 && index2 == -1 && index3 == -1) break;

            }
            MessageBox.Show(res);
        }
    }
}
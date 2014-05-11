using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QRCodeDemo.WebService;

namespace QRCodeDemo
{
    public partial class FriendList : PhoneApplicationPage
    {
       

         FriendContactList FriendsInfoList;
        public FriendList()
        {
            InitializeComponent();
            FriendsInfoList = FriendContactList.GetContacts();
            // CreatePersonalInfoList();
            BuildLocalizedApplicationBar();
            SortingListAZ();

            FriendContactList a = FriendContactList.GetContacts();
            MessageBox.Show(a.friendList.First().nickname);
        }

        private void CreatePersonalInfoList()
        {
            MyContact ct = new MyContact();
            FriendsContactInfo frct = new FriendsContactInfo();

            ct.name = "name 1";
            ct.phone = "phone 1";
            ct.email = "email 1";

            frct.contactInfo = ct;
            frct.nickname = "a1";
            frct.shareMyContactInfo = true;
            
            ct = new MyContact();
            ct.name = "name 2";
            ct.phone = "phone 2";
            ct.email = "email 2";

            frct = new FriendsContactInfo();
            frct.contactInfo = ct;
            frct.nickname = "b2";
            frct.shareMyContactInfo = true;
            FriendsInfoList.AddContact(frct);
            ct = new MyContact();
            ct.name = "name 3";
            ct.phone = "phone 3";
            ct.email = "email 3";
            frct = new FriendsContactInfo();
            frct.contactInfo = ct;
            frct.nickname = "a3";
            frct.shareMyContactInfo = true;
            FriendsInfoList.AddContact(frct);
            ct = new MyContact();
            ct.name = "name 4";
            ct.phone = "phone 4";
            ct.email = "email 4";
            frct = new FriendsContactInfo();
            frct.contactInfo = ct;
            frct.nickname = "caca4";
            frct.shareMyContactInfo = true;
            FriendsInfoList.AddContact(frct);

            
            FriendsInfoList.SaveFriendList();
            //FriendsInfoList.Add(new FriendsInfo("Sanka Bulathgama", "/Assets/Img/my.jpg", "www.csharpteacher.com")); 
            //FriendsInfoList.Add(new FriendsInfo("Ann MMC", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Astor", "/Assets/Img/my.jpg", "www.csharpteacher.com")); 
            //FriendsInfoList.Add(new FriendsInfo("Anela WRD", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Alison DEC", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Brad", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Boni", "/Assets/Img/my.jpg", "www.csharpteacher.com")); 
            //FriendsInfoList.Add(new FriendsInfo("Corolein", "/Assets/Img/my.jpg", "www.csharpteacher.com")); 
            //FriendsInfoList.Add(new FriendsInfo("Demon", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Elaric", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Fox", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Ian Bell", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Jaliya Udagedara", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Klaus VD", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Lenis BB", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Matt VD", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Fiqri Smile", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Welington Perera", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Sheldon Cooper", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Penny BBT", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Zee Mar", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Trisha Mag", "/Assets/Img/my.jpg", "www.csharpteacher.com")); 
            //FriendsInfoList.Add(new FriendsInfo("Dimple SI", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Mom", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Dad", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
            //FriendsInfoList.Add(new FriendsInfo("Vanel Bidel", "/Assets/Img/my.jpg", "www.csharpteacher.com"));
        }
        private void SortingListAZ()
        {
            List<AlphaKeyGroup<FriendsContactInfo>> DataSource = AlphaKeyGroup<FriendsContactInfo>.CreateGroups(FriendsInfoList.friendList,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (FriendsContactInfo s) => { return s.nickname; }, true);

            lstFriendList.ItemsSource = DataSource;

        }
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            //ApplicationBar.IsVisible = false;
            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton_Select = new ApplicationBarIconButton(new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative));
            appBarButton_Select.Text = "select";
            appBarButton_Select.Click += appBarButton_Select_Click;
            ApplicationBar.Buttons.Add(appBarButton_Select);

            //ApplicationBarIconButton appBarButton_Cancel = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancel.png", UriKind.Relative));
            //appBarButton_Cancel.Text = "Cancel";
            //appBarButton_Cancel.Click += appBarButton_Cancel_Click;
            //ApplicationBar.Buttons.Add(appBarButton_Cancel);


        }

        void appBarButton_Select_Click(object sender, EventArgs e)
        {
            lstFriendList.IsSelectionEnabled = !lstFriendList.IsSelectionEnabled;
        }
    }
}
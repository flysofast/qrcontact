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
using Newtonsoft.Json;

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

            ApplicationBarIconButton appBarButton_Save = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancel.png", UriKind.Relative));
            appBarButton_Save.Text = "Cancel";
            appBarButton_Save.Click += appBarButton_Save_Click;
            ApplicationBar.Buttons.Add(appBarButton_Save);


        }

        void appBarButton_Save_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScanPage.xaml",UriKind.Relative));
        }

        void appBarButton_Select_Click(object sender, EventArgs e)
        {
            string s = "{\"name\":\"nam\",\"phone\":\"010022\"}";
            string s2 = "{\"name\":\"Nguyen Si Thang\",\"phone\":\"06356565849\",\"email\":\"sithangvngb@gmail.com\",\"address\":\"hue jvj j \",\"website\":null,\"birthday\":\"1992-09-23T00:00:00\"}";
            lstFriendList.IsSelectionEnabled = !lstFriendList.IsSelectionEnabled;
            var  ct = JsonConvert.DeserializeObject<MyContact>(s2);
            MessageBox.Show(s2);
           MessageBox.Show( "Name:" + ct.name + "\nPhone number:" + ct.phone + "\nEmail:" + ct.email + "\nAddress:" + ct.address + "\nBirthday:" + ct.birthday.ToShortDateString() + "\nWebsite:" + ct.website);
        }

        private void grdContact_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ContactDetail.xaml",UriKind.Relative));
        }
    }
}
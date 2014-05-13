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
using System.Windows.Media;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;
using QRCodeDemo.Resources;
using System.IO.IsolatedStorage;

namespace QRCodeDemo
{
    public partial class FriendList : PhoneApplicationPage
    {


        FriendContactList FriendsInfoList;
        public FriendList()
        {
            InitializeComponent();
            FriendsInfoList = FriendContactList.GetContacts(true);
            UpdateNewInfomation();

            // CreatePersonalInfoList();

            BuildLocalizedApplicationBar();



        }

        async void UpdateNewInfomation()
        {
            var progress = new ProgressIndicator
             {
                 IsVisible = true,
                 IsIndeterminate = true,
                 Text = "Updating your contact list..."
             };
            SystemTray.SetProgressIndicator(this, progress);

            MyContact[] cts = await WebServiceHelper.UpdateFriendsInfo(IsolatedData.userInfo.contactData.id);

            foreach (var ct in cts)
            {
                MessageBox.Show(ct.id.ToString());
                int index = FriendsInfoList.friendList.FindIndex(p => p.contactInfo.id == ct.id);
                if (index != -1)
                    FriendsInfoList.friendList[index].contactInfo = ct;
                else
                {
                    FriendsContactInfo fc = new FriendsContactInfo();
                    fc.nickname = ct.name;
                    fc.shareMyContactInfo = IsolatedData.appSettings.Share;
                    fc.contactInfo = ct;
                    FriendsInfoList.AddContact(fc,false);
                }

                FriendsInfoList.SaveFriendList();
            }

           
            progress.IsIndeterminate = false;
            progress.IsVisible = false;
            SortingListAZ();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateNewInfomation();
            base.OnNavigatedTo(e);
        }


        //private void CreatePersonalInfoList()
        //{
        //    MyContact ct = new MyContact();
        //    FriendsContactInfo frct = new FriendsContactInfo();

        //    ct.name = "name 1";
        //    ct.phone = "phone 1|phone2|phone 3";
        //    ct.email = "email 1|email 2|emial3";
        //    ct.address = "add|add2";
        //    ct.birthday = new DateTime(1992, 1, 1);
        //    ct.website = "dấdasdassd";

        //    frct.contactInfo = ct;
        //    frct.nickname = "a1";
        //    frct.shareMyContactInfo = true;
        //    FriendsInfoList.AddContact(frct,false);

        //    ct = new MyContact();
        //    ct.name = "name 2";
        //    ct.phone = "phone 1|phone2|";
        //    ct.email = "email 1|email 2|";
        //    ct.address = "add|";
        //    // ct.birthday = new DateTime(1992, 1, 1);
        //    ct.website = "dấdasdassd";
        //    frct = new FriendsContactInfo();
        //    frct.contactInfo = ct;
        //    frct.nickname = "b1";
        //    frct.shareMyContactInfo = true;
        //    FriendsInfoList.AddContact(frct);

        //    ct = new MyContact();
        //    ct.name = "name 2";
        //    ct.phone = "phone 1|||";
        //    ct.email = "email 1||";
        //    ct.address = "add|";
        //    ct.birthday = new DateTime(1992, 1, 1);
        //    //ct.website = "dấdasdassd";
        //    frct = new FriendsContactInfo();
        //    frct.contactInfo = ct;
        //    frct.nickname = "c1";
        //    frct.shareMyContactInfo = true;
        //    FriendsInfoList.AddContact(frct);

        //    ct = new MyContact();
        //    ct.name = "name 2";
        //    ct.phone = "phone 1|||";
        //    ct.email = "email 1||";
        //    //  ct.address = "add";
        //    ct.birthday = new DateTime(1992, 1, 1);
        //    ct.website = "dấdasdassd";
        //    frct = new FriendsContactInfo();
        //    frct.contactInfo = ct;
        //    frct.nickname = "c21";
        //    frct.shareMyContactInfo = true;
        //    FriendsInfoList.AddContact(frct);

        //    ct = new MyContact();
        //    ct.name = "name 2";
        //    ct.phone = "phone 1|||";
        //    // ct.email = "email 1|email 2";
        //    ct.address = "add|";
        //    // ct.birthday = new DateTime(1992, 1, 1);
        //    ct.website = "dấdasdassd";
        //    frct = new FriendsContactInfo();
        //    frct.contactInfo = ct;
        //    frct.nickname = "d1";
        //    frct.shareMyContactInfo = true;
        //    FriendsInfoList.AddContact(frct);

        //    FriendsInfoList.SaveFriendList();

        //}
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

            ApplicationBarIconButton appBarButton_Delete = new ApplicationBarIconButton(new Uri("/Toolkit.Content/ApplicationBar.Delete.png", UriKind.Relative));
            appBarButton_Delete.Text = "delete";
            appBarButton_Delete.Click += appBarButton_Delete_Click;
            ApplicationBar.Buttons.Add(appBarButton_Delete);


        }

        private async void appBarButton_Delete_Click(object sender, EventArgs e)
        {
            if (lstFriendList.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Do you really want to delete these item?", "Attention", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    var selectedItems = lstFriendList.SelectedItems;
                    int[] list = new int[selectedItems.Count];
                    int i = 0;
                    foreach (FriendsContactInfo item in selectedItems)
                    {
                        list[i] = item.contactInfo.id;
                        i++;
                    }

                    bool del = await WebServiceHelper.DeleteFriend(IsolatedData.userInfo.contactData.id, list);
                    if (del)
                    {
                        MessageBox.Show("Deleted succcessfully");
                        FriendsInfoList.friendList.RemoveAll(p => list.Contains(p.contactInfo.id));
                        FriendsInfoList.SaveFriendList();
                    }
                    else
                        MessageBox.Show("Deleted failed");

                    UpdateNewInfomation();
                }
            }
            else
                MessageBox.Show("You haven't chosen any contact!");
        }

        void appBarButton_Save_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScanPage.xaml", UriKind.Relative));
        }

        void appBarButton_Select_Click(object sender, EventArgs e)
        {
            lstFriendList.IsSelectionEnabled = !lstFriendList.IsSelectionEnabled;
        }

        private void grdContact_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid gr = (Grid)sender;
            gr.Background = new SolidColorBrush(Color.FromArgb(255, 20, 107, 12));
            TextBlock tbPhonenum = gr.FindName("tbPhoneNumber") as TextBlock;
            TextBlock tbName = gr.FindName("tbName") as TextBlock;

            string number = tbPhonenum.Text.Split('\n')[0];


            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = number;
            phoneCallTask.DisplayName = tbName.Text;
            phoneCallTask.Show();
            grdContact_ManipulationCompleted(sender, new System.Windows.Input.ManipulationCompletedEventArgs());


        }



        private void grdContact_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            Grid gr = (Grid)sender;
            gr.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            TextBlock tbCall = gr.FindName("CallSymbol") as TextBlock;
            tbCall.Visibility = Visibility.Collapsed;
        }


        private void grdContact_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {

            double tran = e.CumulativeManipulation.Translation.X * 0.5;
            // if (tran > 255) tran = 255;

            Grid gr = (Grid)sender;
            gr.Background = new SolidColorBrush(Color.FromArgb((byte)tran, 20, 107, 12));
            TextBlock tbPhonenum = gr.FindName("tbPhoneNumber") as TextBlock;
            TextBlock tbName = gr.FindName("tbName") as TextBlock;
            TextBlock tbCall = gr.FindName("CallSymbol") as TextBlock;
            tbCall.Visibility = Visibility.Visible;

            if (tran > 150)
            {
                string encodedValue = Uri.EscapeDataString(tbName.Text);
                NavigationService.Navigate(new Uri("/ContactDetail.xaml?nick=" + encodedValue, UriKind.Relative));
                grdContact_ManipulationCompleted(sender, new System.Windows.Input.ManipulationCompletedEventArgs());
            }

        }




    }
}
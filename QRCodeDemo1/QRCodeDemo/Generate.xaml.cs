using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QRCodeDemo.Resources;
using System.Windows.Media.Imaging;
using ZXing;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone;
using Microsoft.Phone.UserData;
using Microsoft.Phone.Tasks;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using QRCodeDemo.WebService;
using System.Windows.Media;
using System.Windows.Controls.Primitives;


namespace QRCodeDemo
{
    public partial class Generate : PhoneApplicationPage
    {
        string mName, mPhone, mAdd, mMail;
        int kt = 0, mPopup = 0;
        bool ktbutton = true;
        Color foregroundcl;
        Color backgroundcl;
        PhoneNumberChooserTask phoneNumberChooserTask;
        AddressChooserTask addressTask;
        EmailAddressChooserTask emailAddressChooserTask;
        private string displayName = "", NAME = "";

        public Generate()
        {
            InitializeComponent();
            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

            addressTask = new AddressChooserTask();
            addressTask.Completed += new EventHandler<AddressResult>(addressTask_Completed);

            emailAddressChooserTask = new EmailAddressChooserTask();
            emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
            // BuildLocalizedApplicationBar();
        }
        public void writetext()
        {
            string name = TbName.Text, phone = TbPhone.Text, mail = TbMail.Text, add = TbAdd.Text;
            if (name == "" && phone == "" && mail == "" && add == "")
                MessageBox.Show("Empty");
            else
            {
                MyContact a = new MyContact();
                if (CbName.IsChecked == true)
                    a.name = TbName.Text;
                if (CbPhone.IsChecked == true)
                    a.phone = TbPhone.Text;
                if (CbAdd.IsChecked == true)
                    a.address = TbAdd.Text;
                if (CbMail.IsChecked == true)
                    a.email = TbMail.Text;
                a.birthday = new DateTime(1992, 9, 23, 0, 0, 0);
                if (CbName.IsChecked == false && CbPhone.IsChecked == false && CbAdd.IsChecked == false && CbMail.IsChecked == false)
                    MessageBox.Show("Check infor to generate !");

                string ContactString = JsonConvert.SerializeObject(a);
                IsolatedStorageFile IsolatedSaveText = IsolatedStorageFile.GetUserStoreForApplication();

                //create new file
                using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.Create, FileAccess.Write, IsolatedSaveText)))
                {

                }
                //Open existing file
                IsolatedStorageFileStream fileStream = IsolatedSaveText.OpenFile("myFile.txt", FileMode.Open, FileAccess.Write);
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    string Text1 = ContactString; ;
                    string Text2 = CbName.IsChecked + ":" + CbPhone.IsChecked + ":" + CbMail.IsChecked + ":" + CbAdd.IsChecked + ":" + CbShare.IsChecked;
                    writer.WriteLine(ContactString);
                    writer.WriteLine(Text2);
                    writer.Close();
                }
            }


        }
        public void readtext()
        {
            IsolatedStorageFile IsolatedReadFile = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fileStream = IsolatedReadFile.OpenFile("myFile.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                MyContact b = new MyContact();

                string ContactString = reader.ReadLine();
                b = JsonConvert.DeserializeObject<MyContact>(ContactString);

                //String[] s1 = st1.Split(':');
                mName = b.name;
                mPhone = b.phone;
                mMail = b.email;
                mAdd = b.address;
                string st2 = reader.ReadLine();
                string[] s2 = st2.Split(':');
                CbName.IsChecked = Boolean.Parse(s2[0].ToString());
                CbPhone.IsChecked = Boolean.Parse(s2[1].ToString());
                CbMail.IsChecked = Boolean.Parse(s2[2].ToString());
                CbAdd.IsChecked = Boolean.Parse(s2[3].ToString());
                CbShare.IsChecked = Boolean.Parse(s2[4].ToString());

            }
        }
        private void ReadFromIsolatedStorage(string fileName)
        {
            WriteableBitmap bitmap = new WriteableBitmap(200, 200);
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                    {
                        // Decode the JPEG stream.
                        bitmap = PictureDecoder.DecodeJpeg(fileStream);
                        img_qr.Source = bitmap;
                    }
                }
                else
                {
                    BitmapImage tn = new BitmapImage();
                    tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/SquareTile71x71.png", UriKind.Relative)).Stream);
                    img_qr.Source = tn;
                }

            }

        }
        private void ReadFromIsolatedStorage1(string fileName)
        {
            WriteableBitmap bitmap = new WriteableBitmap(200, 200);
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                    {
                        // Decode the JPEG stream.
                        bitmap = PictureDecoder.DecodeJpeg(fileStream);
                        Img_popup.Source = bitmap;

                    }
                }
                else
                {
                    BitmapImage tn = new BitmapImage();
                    tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/SquareTile71x71.png", UriKind.Relative)).Stream);
                    Img_popup.Source = tn;
                }

            }
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {

                if (NAME != e.DisplayName)
                {
                    TbPhone.Text = "";

                }
                displayName = e.PhoneNumber;
                TbName.Text = e.DisplayName;
                TbPhone.Text += e.PhoneNumber + "|";
                NAME = e.DisplayName;

            }
        }
        void addressTask_Completed(object sender, AddressResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                this.displayName = e.DisplayName;
                string a = e.Address.Replace("\r\n", "|");
                string[] b = a.Split('|');

                foreach (var s in b)
                {
                    if (s != "")
                        this.TbAdd.Text += s + "|";

                }
            }
        }
        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                TbMail.Text += e.Email + "|";



                //Code to send a new email message using the retrieved email address.
                //EmailComposeTask emailComposeTask = new EmailComposeTask();
                //emailComposeTask.To = e.Email;
                //emailComposeTask.Subject = e.DisplayName + ", here is an email from my app!";
                //emailComposeTask.Show();
            }
        }



        private void reset()
        {
            TbAdd.Text = "";
            TbMail.Text = "";
            TbPhone.Text = "";
            TbName.Text = "";
            CbAdd.IsChecked = true;
            CbName.IsChecked = true;
            CbPhone.IsChecked = true;
            CbMail.IsChecked = true;
            img_qr.Source = null;
        }



        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            foreach (var result in e.Results)
            {
                MessageBox.Show(result.DisplayName);

                TbAdd.Text = "Address:  " + result.DisplayName;

            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Color foregroundcl = HexColor(IsolatedData.appSettings.QrcodeColor);
            Color backgroundcl = HexColor(IsolatedData.appSettings.BackgroundQrCode);

            ApplicationBarIconButton btupdate = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (IsolatedData.isSignedIn)
            {
                btupdate.IsEnabled = true;
            }
            else
            {
                btupdate.IsEnabled = false;
            }
            if (kt == 0)
            {
                BtGetAddContact.Visibility = Visibility.Collapsed;
                BtGetMailContact.Visibility = Visibility.Collapsed;
                BtGetNameContact.Visibility = Visibility.Collapsed;
                readtext();
                if (mName != null)
                    TbName.Text = mName;
                if (mPhone != null)
                    TbPhone.Text = mPhone;
                if (mMail != null)
                    TbMail.Text = mMail;
                if (mAdd != null) TbAdd.Text = mAdd;
                ReadFromIsolatedStorage("/Shared/ShellContent/336x336.jpg");
                kt = 1;
            }
            //CbName.IsChecked = true;
            //CbAdd.IsChecked = true;
            //CbMail.IsChecked = true;
            //CbPhone.IsChecked = true;
            TbAdd.IsEnabled = true;
            TbName.IsEnabled = true;
            TbMail.IsEnabled = true;
            TbPhone.IsEnabled = true;


            //CbName.IsChecked = true;
            //CbAdd.IsChecked = true;
            //CbMail.IsChecked = true;
            //CbPhone.IsChecked = true;
            TbAdd.IsEnabled = true;
            TbName.IsEnabled = true;
            TbMail.IsEnabled = true;
            TbPhone.IsEnabled = true;

            base.OnNavigatedTo(e);
        }

        private void BtGenerate_Click(object sender, RoutedEventArgs e)
        {
            string name = TbName.Text, phone = TbPhone.Text, mail = TbMail.Text, add = TbAdd.Text;
            Color foregroundcl = HexColor(IsolatedData.appSettings.QrcodeColor);
            Color backgroundcl = HexColor(IsolatedData.appSettings.BackgroundQrCode);
            if (name == "" && phone == "" && mail == "" && add == "")
                MessageBox.Show("Empty");
            else
            {
                MyContact a = new MyContact();
                if (CbName.IsChecked == true)
                    a.name = TbName.Text;
                if (CbPhone.IsChecked == true)
                    a.phone = TbPhone.Text + "|||";
                if (CbAdd.IsChecked == true)
                    a.address = TbAdd.Text + "||";
                if (CbMail.IsChecked == true)
                    a.email = TbMail.Text + "|||";
                if (CbBirthDay.IsChecked == true)
                    a.birthday = (DateTime)Pickerdatetime.Value;
                if (CbWebsite.IsChecked == true)
                    a.website = TbWebsite.Text + "|||";
                if (CbName.IsChecked == false && CbPhone.IsChecked == false && CbAdd.IsChecked == false && CbMail.IsChecked == false && CbWebsite.IsChecked == false && CbBirthDay.IsChecked == false)
                    MessageBox.Show("Check infor to generate !");

                string ContactString = JsonConvert.SerializeObject(a);
                // MyContact b = new MyContact();
                //b = JsonConvert.DeserializeObject<MyContact>(ContactString);
                //MessageBox.Show(b.phone);
                img_qr.Source = GenerateQRCode(ContactString, 1, foregroundcl, backgroundcl);
                Img_popup.Source = GenerateQRCode(ContactString, 1, foregroundcl, backgroundcl);
            }

        }
        public static Color HexColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
        private static WriteableBitmap GenerateQRCode(string s, int margin, Color clforeground, Color clbackground)
        {
            BarcodeWriter _writer = new BarcodeWriter();
            string cl = IsolatedData.appSettings.QrcodeColor;

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {

                Foreground = clforeground,
                Background = clbackground
            };

            _writer.Format = BarcodeFormat.QR_CODE;

            _writer.Options.Height = 400;
            _writer.Options.Width = 400;
            _writer.Options.Margin = margin;

            var barcodeImage = _writer.Write(s); //tel: prefix for phone numbers

            return barcodeImage;
        }
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();



            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
        private void ApplicationBarIconButton_Click_reset(object sender, EventArgs e)
        {
            TbAdd.Text = "";
            TbMail.Text = "";
            TbName.Text = "";
            TbPhone.Text = "";
        }
        private void ApplicationBarIconButton_Click_update(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                string name = TbName.Text;
                string[] updatephone = (TbPhone.Text + "||").Split('|');
                string phone = updatephone[0] + "|" + updatephone[1] + ";" + updatephone[2] + "|";
                string[] upaddress = (TbAdd.Text + "|").Split('|');
                string address = upaddress[0] + "|" + upaddress[1] + "|";
                string[] upmail = (TbMail.Text + "||").Split('|');
                string mail = upmail[0] + "|" + upmail[1] + "|" + upmail[2] + "|";

                WebService.WebServiceHuscSoapClient sv = new WebService.WebServiceHuscSoapClient();
                WebService.MyContact a = new WebService.MyContact();
                if (CbName.IsChecked == true)
                    a.name = TbName.Text;
                if (CbPhone.IsChecked == true)
                    a.phone = phone;
                if (CbAdd.IsChecked == true)
                    a.address = address;
                if (CbMail.IsChecked == true)
                    a.email = mail;


                sv.UpdateCompleted += sv_UpdateCompleted;
                //
                sv.UpdateAsync(1, a, "", CbShare.IsChecked == true ? true : false);
            }
            else
                MessageBox.Show("No internet connection is available");
            { }


        }

        private void ApplicationBarIconButton_Click_save(object sender, EventArgs e)
        {
            Color foregroundcl = HexColor(IsolatedData.appSettings.QrcodeColor);
            Color backgroundcl = HexColor(IsolatedData.appSettings.BackgroundQrCode);

            writetext();
            MyContact a = new MyContact();
            if (CbName.IsChecked == true)
                a.name = TbName.Text;
            if (CbPhone.IsChecked == true)
                a.phone = TbPhone.Text + "|||";
            if (CbAdd.IsChecked == true)
                a.address = TbAdd.Text + "||";
            if (CbMail.IsChecked == true)
                a.email = TbMail.Text + "|||";
            if (CbBirthDay.IsChecked == true)
                a.birthday = (DateTime)Pickerdatetime.Value;
            if (CbWebsite.IsChecked == true)
                a.website = TbWebsite.Text + "|||";
            if (CbName.IsChecked == false && CbPhone.IsChecked == false && CbAdd.IsChecked == false && CbMail.IsChecked == false && CbBirthDay.IsChecked == false && CbWebsite.IsChecked == false)
                MessageBox.Show("Check infor to generate !");

            string ContactString = JsonConvert.SerializeObject(a);


            WriteableBitmap wb = GenerateQRCode(ContactString, 1, foregroundcl, backgroundcl);
            WriteableBitmap wb1 = GenerateQRCode(ContactString, 60, foregroundcl, backgroundcl);

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists("Shared\\ShellContent\\336x336.jpg") || myIsolatedStorage.FileExists("Shared\\ShellContent\\691x336.jpg") || myIsolatedStorage.FileExists("Shared\\ShellContent\\800x480.jpg"))
                {
                    myIsolatedStorage.DeleteFile("Shared\\ShellContent\\336x336.jpg");
                    myIsolatedStorage.DeleteFile("Shared\\ShellContent\\691x336.jpg");
                    myIsolatedStorage.DeleteFile("Shared\\ShellContent\\800x480.jpg");

                }
                IsolatedStorageFileStream fileStream1 = myIsolatedStorage.CreateFile("Shared\\ShellContent\\336x336.jpg");
                IsolatedStorageFileStream fileStream2 = myIsolatedStorage.CreateFile("Shared\\ShellContent\\691x336.jpg");
                IsolatedStorageFileStream fileStream3 = myIsolatedStorage.CreateFile("Shared\\ShellContent\\800x480.jpg");

                wb.SaveJpeg(fileStream1, 336, 336, 0, 100);
                wb.SaveJpeg(fileStream2, 691, 336, 0, 100);
                wb1.SaveJpeg(fileStream3, 800, 480, 0, 100);
                fileStream1.Close();
                fileStream2.Close();
                fileStream3.Close();

            }

            MessageBox.Show("Save successfuly !");


        }

        private void ApplicationBarIconButton_Click_cancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Setting.xaml", UriKind.Relative));

        }


        void sv_UpdateCompleted(object sender, WebService.UpdateCompletedEventArgs e)
        {

            if (e.Error == null)
                switch ((int)e.Result)
                {
                    case 1:
                        MessageBox.Show("Success");
                        break;
                    case 0:
                        MessageBox.Show("Fail");
                        break;
                    default:
                        break;
                }
            else
            {
                MessageBox.Show("Unexpected error");
            }
        }
        private void CbWebsite_Click(object sender, RoutedEventArgs e)
        {
            if (CbWebsite.IsChecked == true)
            {
                TbWebsite.IsEnabled = true;
            }
            else
                TbWebsite.IsEnabled = false;
        }
        private void CbName_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CbName_Click(object sender, RoutedEventArgs e)
        {
            if (CbName.IsChecked == true)
            {
                TbName.IsEnabled = true;
            }
            else
                TbName.IsEnabled = false;
        }

        private void CbPhone_Click(object sender, RoutedEventArgs e)
        {
            if (CbPhone.IsChecked == true)
            {
                TbPhone.IsEnabled = true;
            }
            else
                TbPhone.IsEnabled = false;
        }





        private void BtGetNameContact_Click(object sender, RoutedEventArgs e)
        {
            phoneNumberChooserTask.Show();
        }

        private void BtGetMailContact_Click(object sender, RoutedEventArgs e)
        {
            emailAddressChooserTask.Show();
        }

        private void BtGetAddContact_Click(object sender, RoutedEventArgs e)
        {
            addressTask.Show();
        }

        private void BtOtherQrCode_Click(object sender, RoutedEventArgs e)
        {
            if (ktbutton == true)
            {
                reset();
                ApplicationBarIconButton btupdate = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                ApplicationBarIconButton btsave = (ApplicationBarIconButton)ApplicationBar.Buttons[3];
                btupdate.IsEnabled = false;
                btsave.IsEnabled = false;
                BtGetAddContact.Visibility = Visibility.Visible;
                BtGetNameContact.Visibility = Visibility.Visible;
                BtGetMailContact.Visibility = Visibility.Visible;
                BtOtherQrCode.Content = "My Qr";
                ktbutton = false;

            }
            else
            {
                ApplicationBarIconButton btupdate = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

                if (IsolatedData.isSignedIn)
                {
                    btupdate.IsEnabled = true;
                }
                else
                {
                    btupdate.IsEnabled = false;
                }

                readtext();
                if (mName != null)
                    TbName.Text = mName;

                if (mPhone != null)
                    TbPhone.Text = mPhone;
                if (mMail != null)
                    TbMail.Text = mMail;
                if (mAdd != null) TbAdd.Text = mAdd;
                ReadFromIsolatedStorage("/Shared/ShellContent/336x336.jpg");
                ApplicationBarIconButton btsave = (ApplicationBarIconButton)ApplicationBar.Buttons[3];

                btsave.IsEnabled = true;
                BtOtherQrCode.Content = "New Qr";
                BtGetAddContact.Visibility = Visibility.Collapsed;
                BtGetNameContact.Visibility = Visibility.Collapsed;
                BtGetMailContact.Visibility = Visibility.Collapsed;
                ktbutton = true;
            }
        }


        private void CbMail_Click(object sender, RoutedEventArgs e)
        {
            if (CbMail.IsChecked == true)
            {
                TbMail.IsEnabled = true;
            }
            else
                TbMail.IsEnabled = false;
        }

        private void CbAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CbAdd.IsChecked == true)
            {
                TbAdd.IsEnabled = true;
            }
            else
                TbAdd.IsEnabled = false;
        }

        private void img_qr_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (mPopup == 0)
            {
                if (Img_popup.Source == null)
                    ReadFromIsolatedStorage1("/Shared/ShellContent/336x336.jpg");
                popup_image.IsOpen = true;
                mPopup = 1;
            }
            else
            {
                popup_image.IsOpen = false;
                mPopup = 0;
            }

        }

        private void BtOkPopup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Img_popup_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup_image.IsOpen = false;
            mPopup = 0;
        }





    }
}
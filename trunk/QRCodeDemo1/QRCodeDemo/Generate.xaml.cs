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

namespace QRCodeDemo
{
    public partial class Generate : PhoneApplicationPage
    {
        string mName, mPhone, mAdd, mMail;
        public Generate()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }
        public void writetext()
        {
            
            string name = TbName.Text, phone = TbPhone.Text, mail = TbMail.Text, add = TbAdd.Text;
            string ContactString = "{\"name\":\"" + name + "\",\"phone\":\"" + phone + "\"}";
            #region Save text
            IsolatedStorageFile IsolatedSaveText = IsolatedStorageFile.GetUserStoreForApplication();

            //create new file
            using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("myFile.txt", FileMode.Create, FileAccess.Write, IsolatedSaveText)))
            {

            }
            //Open existing file
            IsolatedStorageFileStream fileStream = IsolatedSaveText.OpenFile("myFile.txt", FileMode.Open, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                string Text1 = name + ":" + phone + ":" + mail + ":" + add;
                string Text2 =CbName.IsChecked + ":" + CbPhone.IsChecked + ":" + CbMail.IsChecked + ":" + CbAdd.IsChecked;
                writer.WriteLine(Text1);
                writer.WriteLine(Text2);
                writer.Close();
            }
            #endregion
        }
        public void readtext()
        {
            IsolatedStorageFile IsolatedReadFile = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fileStream = IsolatedReadFile.OpenFile("myFile.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {    
                string st1 = reader.ReadLine();
                String[] s1 = st1.Split(':');
                mName = s1[0];
                mPhone = s1[1];
                mMail = s1[2];
                mAdd = s1[3];
                string st2 = reader.ReadLine();
                string[] s2 = st2.Split(':');
                CbName.IsChecked = Boolean.Parse(s2[0].ToString());
                CbPhone.IsChecked = Boolean.Parse(s2[1].ToString());
                CbMail.IsChecked = Boolean.Parse(s2[2].ToString());
                CbAdd.IsChecked = Boolean.Parse(s2[3].ToString());

            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri stUri =new Uri("isostore:/Shared/ShellContent/336x336.jpg",UriKind.Absolute);
            readtext();
            TbName.Text=mName;
            TbPhone.Text=mPhone; TbMail.Text=mMail; TbAdd.Text=mAdd;
            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(stUri).Stream);
            img_qr.Source = tn;
            base.OnNavigatedTo(e);
        }
        private void BtGenerate_Click(object sender, RoutedEventArgs e)
        {
            string name =TbName.Text,phone = TbPhone.Text,mail = TbMail.Text, add = TbAdd.Text;
            string ContactString = "{\"name\":\"nam\",\"phone\":\"0101021212\"}";

            img_qr.Source = GenerateQRCode(ContactString, 1);
         

        }
        private static WriteableBitmap GenerateQRCode(string s, int margin)
        {
            BarcodeWriter _writer = new BarcodeWriter();

            _writer.Renderer = new ZXing.Rendering.WriteableBitmapRenderer()
            {
                Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 255) // blue
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

            //Generate
            //ApplicationBarIconButton appBarButton_Generate = new ApplicationBarIconButton(new Uri("/Assets/AppBar/generate.png", UriKind.Relative));
            //appBarButton_Generate.Text = AppResources.AppBarButtonText;
            //ApplicationBar.Buttons.Add(appBarButton_Generate);
            //Save
            //ApplicationBarIconButton appBarButton_Save = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            //appBarButton_Save.Text = "Save";
            //ApplicationBar.Buttons.Add(appBarButton_Save);
            //Get Contact
            //ApplicationBarIconButton appBarButton_GetContact = new ApplicationBarIconButton(new Uri("/Assets/AppBar/getcontact.png", UriKind.Relative));
            //appBarButton_GetContact.Text = "Get Contact";
            //ApplicationBar.Buttons.Add(appBarButton_GetContact);
            //Cancle
            //ApplicationBarIconButton appBarButton_Cancle = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancle.png", UriKind.Relative));
            //appBarButton_Cancle.Text = "Cancle";
            //ApplicationBar.Buttons.Add(appBarButton_Cancle);
            //Reset
            //ApplicationBarIconButton appBarButton_Reset = new ApplicationBarIconButton(new Uri("/Assets/AppBar/reset.png", UriKind.Relative));
            //appBarButton_Reset.Text = "Reset";
            //ApplicationBar.Buttons.Add(appBarButton_Reset);



            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
     
        
        private void ApplicationBarIconButton_Click_save(object sender, EventArgs e)
        {

            writetext();

            #region Save Image
            string name = TbName.Text, phone = TbPhone.Text, mail = TbMail.Text, add = TbAdd.Text;
            string ContactString = "{\"name\":\"" + name + "\",\"phone\":\"" + phone + "\"}";
            img_qr.Source = GenerateQRCode(ContactString, 1);
            WriteableBitmap wb = GenerateQRCode(ContactString, 1);
            WriteableBitmap wb1 = GenerateQRCode(ContactString, 35);
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
            #endregion 
        }
       
        private void ApplicationBarIconButton_Click_cancel(object sender, EventArgs e)
        {

        }

        private void ApplicationBarIconButton_Click_reset(object sender, EventArgs e)
        {
            TbAdd.Text = "";
            TbMail.Text = "";
            TbPhone.Text = "";
            TbName.Text = "";
            CbAdd.IsChecked = false;
            CbName.IsChecked = false;
            CbPhone.IsChecked = false;
            CbMail.IsChecked = false;
        }

        private void ApplicationBarIconButton_Click_getcontact(object sender, EventArgs e)
        {

        }
    
    }

}
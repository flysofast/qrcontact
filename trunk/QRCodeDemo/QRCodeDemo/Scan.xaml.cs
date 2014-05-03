using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Newtonsoft.Json;
using QRCodeDemo;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace OpticalReaderDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        private OpticalReaderLib.OpticalReaderTask _task = new OpticalReaderLib.OpticalReaderTask();
        private OpticalReaderLib.OpticalReaderResult _result = null;

        public MainPage()
        {
            InitializeComponent();

            _task.Completed += OpticalReaderTask_Completed;

        }

        private void OpticalReaderTask_Completed(object sender, OpticalReaderLib.OpticalReaderResult e)
        {
            _result = e;

            string s = "{\"name\":\"nam\",\"phone\":\"0101021212\"}";
            string s1 = FormatString(e.Text);
            ct = JsonConvert.DeserializeObject<Contact>(FormatString(e.Text));
        }

        string FormatString(string s)
        {
            return s.Replace("\\\"", "\"");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _task.Show();
            if (_result != null && _result.TaskResult == Microsoft.Phone.Tasks.TaskResult.OK)
            {
                ResultImage.Source = _result.Thumbnail;
                ResultTextBlock.Text = String.Format("{0} ({1} bytes)\n\n{2}",
                    _result.Format,
                    _result.Data != null ? _result.Data.Length : 0,
                    _result.Text);

            }



            _result = null;

        }

        private void saveContactTask_Completed(object sender, TaskEventArgs e)
        {
            switch (e.TaskResult)
            {
                //Logic for when the contact was saved successfully
                case TaskResult.OK:
                    MessageBox.Show("Contact saved.");
                    break;

                //Logic for when the task was cancelled by the user
                case TaskResult.Cancel:
                    MessageBox.Show("Save cancelled.");
                    break;

                //Logic for when the contact could not be saved
                case TaskResult.None:
                    MessageBox.Show("Contact could not be saved.");
                    break;
            }


        }
        Contact ct = new Contact();


        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            SaveContactTask saveContactTask = new SaveContactTask();
            saveContactTask.Completed += new EventHandler<SaveContactResult>(saveContactTask_Completed);




            saveContactTask.FirstName = ct.name;
            saveContactTask.MobilePhone = ct.phone;


            saveContactTask.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
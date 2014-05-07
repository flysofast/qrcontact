using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QRCodeDemo
{
    class WebServiceHelper
    {
        static WebService.WebServiceHuscSoapClient service = new WebService.WebServiceHuscSoapClient();
       
        public static Task<int> WhenRequestCompleted() //can make it an extension method if you want.
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            service.InsertNewUserCompleted += (object sender, WebService.InsertNewUserCompletedEventArgs e) => //change parameter list to fit the event's delegate
            {
                MessageBox.Show(e.Result.ToString());
                tcs.SetResult(-1);
            };
            service.InsertNewUserAsync("asd", "dasd", "asds");
            return tcs.Task;
        }

        public static Task<int> SignUp(string username,string password) //can make it an extension method if you want.
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            service.SignUpCompleted += (object sender, WebService.SignUpCompletedEventArgs e) => //change parameter list to fit the event's delegate
            {
                tcs.SetResult((int)e.Result);
            };
            service.SignUpAsync(username, password);
            return tcs.Task;
        }

       
    }
}

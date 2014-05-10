﻿using Microsoft.Phone.Shell;
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
       
       

        public static Task<int> SignUp(string username,string password) //can make it an extension method if you want.
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            service.SignUpCompleted += (object sender, WebService.SignUpCompletedEventArgs e) => //change parameter list to fit the event's delegate
            {
                if (e.Error != null) tcs.TrySetResult(-1);
                else
                tcs.TrySetResult((int)e.Result);
            };
            service.SignUpAsync(username, password);
            return tcs.Task;
        }

        public static Task<int> GetContactList(int id, string sdt) //can make it an extension method if you want.
        {
            
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();

            service.GetContactListCompleted += (object sender, WebService.GetContactListCompletedEventArgs e) => //change parameter list to fit the event's delegate
            {
                if (e.Error != null) tcs.TrySetResult(-1);
                else
                    tcs.TrySetResult((int)e.Result);
            };
            service.GetContactListAsync(id, sdt);
            return tcs.Task;
        }

         public static  Task<int> SignIn(string username, string password) //can make it an extension method if you want.
        {
          
            try
            {
                TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
                service.LoginCompleted += (object sender, WebService.LoginCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(-1);
                    else
                        tcs.TrySetResult((int)e.Result);
                
                   
                };
                service.LoginAsync(username, password);
                service.LoginCompleted -= (object sender, WebService.LoginCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(-1);
                    else
                        tcs.TrySetResult((int)e.Result);

                };
                return tcs.Task;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
           
        }

        
    }
}

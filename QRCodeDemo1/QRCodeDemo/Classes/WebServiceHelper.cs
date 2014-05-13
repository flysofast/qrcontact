using Microsoft.Phone.Shell;
using QRCodeDemo.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QRCodeDemo
{
    class WebServiceHelper
    {
        static WebService.WebServiceHuscSoapClient service = new WebService.WebServiceHuscSoapClient();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>đúng trả về 1, lỗi trả về 0</returns>
        public static Task<int> SignUp(string username, string password) //can make it an extension method if you want.
        {


            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                service.SignUpCompleted += (object sender, WebService.SignUpCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(-1);
                    else
                        tcs.TrySetResult((int)e.Result);
                };
                service.SignUpAsync(username, password);
            }
            else
            {
                MessageBox.Show("No internet connection is available!");
                tcs.TrySetResult(0);
            }
            return tcs.Task;
        }

       
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>trả về id người đăng nhập, lỗi trả về 0</returns>
        public static Task<int> SignIn(string username, string password) //can make it an extension method if you want.
        {


            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
           
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                service.LoginCompleted += (object sender, WebService.LoginCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(-1);
                    else
                        tcs.TrySetResult((int)e.Result);


                };

                service.LoginAsync(username, password);
            }
            else
            {
                MessageBox.Show("No internet connection is available!");
                tcs.TrySetResult(0);
            }
            return tcs.Task;

        }

        /// <summary>
        /// Tìm bạn trong danh bạ và kết bạn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sdt"></param>
        /// <returns>danh sách MyContact bạn bè</returns>
        public static Task<MyContact[]> GetToBeFriends(int id, string phones, bool share) //can make it an extension method if you want.
        {
            TaskCompletionSource<MyContact[]> tcs = new TaskCompletionSource<MyContact[]>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
               
                service.GetContactFriendsListCompleted += (object sender, WebService.GetContactFriendsListCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(null);
                    else
                        tcs.TrySetResult((MyContact[])e.Result);

                };
                service.GetContactFriendsListAsync(id,phones,share);

                return tcs.Task;
            }
            else
            {
                MessageBox.Show("No internet connection is available!");
                tcs.TrySetResult(null);
            }

            return tcs.Task;
        }

        public static Task<MyContact[]> UpdateFriendsInfo(int id) //can make it an extension method if you want.
        {
            TaskCompletionSource<MyContact[]> tcs = new TaskCompletionSource<MyContact[]>();
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                service.myFriendUpdateInfoCompleted += (object sender, WebService.myFriendUpdateInfoCompletedEventArgs e) => //change parameter list to fit the event's delegate
                {
                    if (e.Error != null) tcs.TrySetResult(null);
                    else
                        tcs.TrySetResult((MyContact[])e.Result);

                };
                service.myFriendUpdateInfoAsync(id);

                return tcs.Task;
            }
            else
            {
                MessageBox.Show("No internet connection is available!");
                tcs.TrySetResult(null);
            }

            return tcs.Task;
        }
    }



}

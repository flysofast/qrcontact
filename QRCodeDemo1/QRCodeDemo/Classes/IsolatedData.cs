using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeDemo
{

    class IsolatedData
    {
        static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        public static bool isSignedIn
        {
            get { return (bool)settings["isSignedIn"]; }

            set { settings["isSignedIn"] = value; settings.Save(); }
        }

        public static AppSetting appSettings
        {
            get { return (AppSetting)settings["appSettings"]; }

            set { settings["appSettings"] = value; settings.Save(); }
        }

        public static UserContactInfo userInfo
        {
            get { return (UserContactInfo)settings["userInfo"]; }

            set { settings["userInfo"] = value; settings.Save(); }
        }

        public static List<FriendsContactInfo> friendList
        {
            get { return (List<FriendsContactInfo>)settings["friendList"]; }

            set { settings["friendList"] = value; settings.Save(); }
        }

        public static int LaunchCount
        {
            get { return (int)settings["LaunchCount"]; }

        }

        public static bool NewRelease
        {
            get { return (bool)settings["NewRelease"]; }

            set { settings["NewRelease"] = value; settings.Save(); }
        }

        
    }
}

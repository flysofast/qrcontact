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
            get 
            { 
                return (bool)settings["isSignedIn"]; 
            }

            set
            {
                settings["isSignedIn"] = value;
            }
        }

    

    }
}

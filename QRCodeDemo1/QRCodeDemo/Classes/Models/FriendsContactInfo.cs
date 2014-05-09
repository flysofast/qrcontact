using QRCodeDemo.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeDemo
{
    [DataContract]
    class FriendsContactInfo
    {
         [DataMember]
        public string nickname { get; set; }
         [DataMember]
        public bool shareMyContactInfo { get; set; }
         [DataMember]
        MyContact contactInfo;

      public  FriendsContactInfo()
        {
            contactInfo = new MyContact();
            shareMyContactInfo = false;
        }
    }
}

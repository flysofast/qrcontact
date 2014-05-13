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
  public class FriendsContactInfo
    {
         [DataMember]
        public string nickname { get; set; }
         [DataMember]
        public bool shareMyContactInfo { get; set; }
         [DataMember]
         public MyContact contactInfo { get; set; }

      public  FriendsContactInfo()
        {
            contactInfo = new MyContact();
            shareMyContactInfo = false;
        }
    }
}

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
   public class UserInfo
    {
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }

        //Truong id con thieu, doi bo sung vao lop MyContact, bien contactData
        [DataMember]
        public MyContact contactData { set; get; }

        public UserInfo()
        {
            contactData = new MyContact();
            username = "";
            password = "";
            contactData.id = 0;
        }

    }
}

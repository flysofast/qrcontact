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
    class UserContactInfo
    {
         [DataMember]
        public string username { get; set; }
         [DataMember]
        public string password { get; set; }

        //Truong id con thieu, doi bo sung vao lop MyContact, bien contactData
         [DataMember]
        MyContact contactData;

       public UserContactInfo()
        {
            contactData = new MyContact();
        }

    }
}

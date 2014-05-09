using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeDemo
{
    [DataContract]
    class AppSetting
    {
        [DataMember]
        public string Language { get; set; }
         [DataMember]
        public bool Share { get; set; }
         [DataMember]
        public string BacgroundQrCode { get; set; }
         [DataMember]
        public string QrcodeColor { get; set; }
        

        public AppSetting()
        {

        }
    }
}

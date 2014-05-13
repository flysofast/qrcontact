using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QRCodeDemo
{
    [DataContract]
    class FriendContactList
    {

        private static FriendContactList singleTonObject;
        static bool seperatedNumbers = false;

        [DataMember]
        private List<FriendsContactInfo> _friendList;
        private FriendContactList(bool sepNumbers)
        {
            _friendList = new List<FriendsContactInfo>();
            _friendList = IsolatedData.friendList;
            if (sepNumbers)
            {
                foreach (var fr in _friendList)
                {
                    fr.contactInfo.phone = fr.contactInfo.phone.Replace('|', '\n');
                }
            }
        }

        public List<FriendsContactInfo> friendList
        {
            get
            {
                if (seperatedNumbers)
                    foreach (var fr in _friendList)
                    {
                        fr.contactInfo.phone = fr.contactInfo.phone.Replace('|', '\n');
                    }
                return _friendList;
            }
        }


        public static FriendContactList GetContacts(bool sepNumbers)
        {
            //private static object lockingObject = new object();

            if (singleTonObject == null || sepNumbers != seperatedNumbers)
            {
                singleTonObject = new FriendContactList(sepNumbers);
                seperatedNumbers = sepNumbers;

            }
            return singleTonObject;

        }
        public void AddContact(FriendsContactInfo ct, bool showMessageBoxWarning)
        {
            if (_friendList.Any(p => p.nickname == ct.nickname))
            {
                if (showMessageBoxWarning)
                    MessageBox.Show("This nickname has already exists!");
                return;
            }

            _friendList.Add(ct);
        }

        public void RemoveContact(string nickname)
        {
            string[] names = nickname.Split(';');
            foreach (var s in names)
            {
                // Goi ham xoa tren server
                _friendList.Remove(_friendList.Single(p => p.nickname == nickname));

            }

        }

        public void SaveFriendList()
        {
            IsolatedData.friendList = _friendList;
        }
    }
}

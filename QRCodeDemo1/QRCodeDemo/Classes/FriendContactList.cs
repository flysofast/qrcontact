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

        [DataMember]
        private List<FriendsContactInfo> _friendList;
        private  FriendContactList()
        {
            _friendList = new List<FriendsContactInfo>();
            _friendList = IsolatedData.friendList;
        }

        public List<FriendsContactInfo> friendList
        {
            get
            {
                return _friendList;
            }
        }
       

        public static FriendContactList GetContacts()
        {
            //private static object lockingObject = new object();

            if (singleTonObject == null)
            {
                singleTonObject = new FriendContactList();

            }
            return singleTonObject;

        }
        public void AddContact(FriendsContactInfo ct)
        {
            if (_friendList.Any(p => p.nickname == ct.nickname))
            {
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

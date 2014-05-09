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
         [DataMember]
        List<FriendsContactInfo> friendList;
       public FriendContactList()
        {
            friendList = new List<FriendsContactInfo>();
        }

        void Add(FriendsContactInfo ct)
        {
            if (friendList.Any(p => p.nickname == ct.nickname))
            {
                MessageBox.Show("This nickname has already exists!");
                return;
            }

            friendList.Add(ct);
        }

        void Remove(string nickname)
        {
            string[] names = nickname.Split(';');
            foreach (var s in names)
            {
                // Goi ham xoa tren server
                friendList.Remove(friendList.Single(p => p.nickname == nickname));

            }

        }
    }
}

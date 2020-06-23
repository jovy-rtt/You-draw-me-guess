using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class CC
    {
        public static List<MyUser> Users { get; set; }
        //public static Dictionary<string, MyUser> Users = new Dictionary<string, MyUser>();
        public static Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
        public static MyUser GetUser(string username)
        {
            MyUser user = null;
            foreach (var item in Users)
            {
                if (item.Name == username)
                {
                    user = item;
                    break;
                }
            }
            return user;
        }
    }
}

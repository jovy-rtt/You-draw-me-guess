using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class CheckinCC
    {
        public static List<CheckinUser> Users { get; set; }
        public static Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
        public static CheckinUser GetUser(string username)
        {
            CheckinUser user = null;
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

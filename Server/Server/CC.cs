using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class CC
    {
        public static List<User> Users { get; set; }
        static CC()
        {
            Users = new List<User>();
        }
        public static User GetUser(string userName)
        {
            User user = null;
            foreach (var v in Users)
            {
                if (v.UserName == userName)
                {
                    user = v;
                    break;
                }
            }
            return user;
        }
    }
}

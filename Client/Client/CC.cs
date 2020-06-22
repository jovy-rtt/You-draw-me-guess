using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //思路主要是想要用于在其他的界面操作时，可以很灵活的控制其他界面的情况
    public class CC
    {

        public static List<User> Users { get; set; }

        public static User GetUser(string ID)
        {
            User user = null;
            foreach (var item in Users)
            {
                if (item.id == ID)
                {
                    user = item;
                    break;
                }
            }
            return user;
        }
    }
}

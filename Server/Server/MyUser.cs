using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MyUser:User
    {
        public string UserName { get; set; }
        public bool ready { get; set; }
        public int inRoom { get; set; }
        public readonly IServiceCallback callback;
        public readonly ICheckinServerCallback Checkincallback;
        public MyUser(string username, IServiceCallback callback)
        {
            this.Name = username;
            this.callback = callback;
        }

        public MyUser(string username, ICheckinServerCallback Checkincallback)
        {
            this.Name = username;
            this.Checkincallback = Checkincallback;
        }

    }
}

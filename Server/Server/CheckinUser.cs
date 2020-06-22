using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
     public class CheckinUser:User
    {
        public string UserName { get; set; }
        public bool ready { get; set; }
        public int inRoom { get; set; }
        public readonly IServiceCallback callback;
        public readonly ICheckinServerCallback Checkincallback;

        public CheckinUser(string username, ICheckinServerCallback Checkincallback)
        {
            this.Name = username;
            this.Checkincallback = Checkincallback;
        }
    }


}

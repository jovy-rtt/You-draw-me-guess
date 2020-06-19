using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MyUser:User
    {
       
        public readonly IServiceCallback callback;

        public MyUser(string username, IServiceCallback callback)
        {
            this.Name = username;
            this.callback = callback;
        }

    }
}

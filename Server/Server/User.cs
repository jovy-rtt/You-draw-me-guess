using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class User
    {
        public string UserName { get; set; }
        public readonly IServiceCallback callback;
        public User(string userName, IServiceCallback callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //每一个客户端，都会对应这几个窗口，id就是客户端之间的识别码
    public class User
    {     
        public string id { get; set; }
        public LoginWindow LoginWindow { get; set; }
        public  ForgetPwWindow ForgetPwWindow { get; set; }
        public  MainWindow MainWindow { get; set; }
        public  RegisteredWindow RegisteredWindow { get; set; }
        public  RoomWindow RoomWindow { get; set; }

        public User(string id)
        {
            this.id = id;
        }
    }
}

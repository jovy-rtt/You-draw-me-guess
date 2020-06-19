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
        public static StartWindow StartWindow;

        public static LoginWindow LoginWindow;
        public static ForgetPwWindow ForgetPwWindow;
        public static MainWindow MainWindow;
        public static RegisteredWindow RegisteredWindow;
        public static RoomWindow RoomWindow;
    }
}

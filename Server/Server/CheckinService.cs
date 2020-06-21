using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“CheckinService”。
    public class CheckinService : ICheckinService
    {
        
        public void Checkin(string userName, int roomnum)
        {

            OperationContext context = OperationContext.Current;
            IServiceCallback callback = context.GetCallbackChannel<IServiceCallback>();
            MyUser newUser = new MyUser(userName, callback);
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                //user.callback.ShowCheckin(userName, roomnum);
            }
        }
    }
}

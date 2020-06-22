using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“CheckinServer”。
    public class CheckinServer : ICheckinServer
    {
       
        public CheckinServer()
        {
            if (CC.Users == null)
            {
                CC.Users = new List<MyUser>();

            }
        }

        public void Login(string userName)
        {
            // throw new NotImplementedException();
            OperationContext context = OperationContext.Current;
            IServiceCallback callback = context.GetCallbackChannel<IServiceCallback>();
            MyUser newUser = new MyUser(userName, callback);
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName);
            }
        }

        public void Checkin(string userName, int roomnumber)
        {
            OperationContext context = OperationContext.Current;
            ICheckinServerCallback callback = context.GetCallbackChannel<ICheckinServerCallback>();
            foreach (var item in CC.Users)
            {
                item.callback.ShowCheckin(userName, roomnumber);
            }
        }

        public void Talk(string userName, string message)
        {
            foreach (var item in CC.Users)
            {
                item.callback.ShowTalk(userName, message);
            }
        }

        public void Logout(string userName)
        {
            MyUser logoutUser = CC.GetUser(userName);
            foreach (var user in CC.Users)
            {
                //不需要发给退出用户
                if (user.UserName != logoutUser.UserName)
                {
                    user.callback.ShowLogout(userName);
                }
            }
            CC.Users.Remove(logoutUser);
            logoutUser = null; //将其设置为null后，WCF会自动关闭该客户端

        }
    }
}

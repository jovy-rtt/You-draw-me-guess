using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Automation.Peers;

namespace Server
{
    // 实现函数的时候，用三个/ 来定义一下函数说明，说明函数的大概功能、（参数，返回值，可选可不选）
    // 整体框架已建好，注意分割线，画板函数实现在#region 画板... 这里面，聊天室在# region 聊天室这里

    public class Service : IService
    {

        /// <summary>
        /// 测试用例
        /// </summary>
        public bool test()
        {
            return true;
        }


        /*-----------------------------------------------------  分割线   ---------------------------------------------------------------*/

        #region 画板的服务端函数实现
        /// <summary>
        /// 发送数字墨迹
        /// </summary>
        public void SendInk(int room, string ink)
        {
            foreach (var v in CC.Users)
            {
                v.callback.ShowInk(ink);
            }
        }

        #endregion



        /*-----------------------------------------------------  分割线   ---------------------------------------------------------------*/



        #region 聊天室的服务端函数实现

        public Service()
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

            User tmp = null;
            //数据库实例
            MyDbEntities myDbEntities = new MyDbEntities();
            //选中这一条数据
            var q = from p in myDbEntities.User
                    where p.Name == userName
                    select p;
            tmp = q.FirstOrDefault();
            newUser.Acount = tmp.Acount;
            newUser.Avart = tmp.Avart;
            newUser.Grade = tmp.Grade;
            newUser.Name = tmp.Name;
            newUser.Room = tmp.Room;
            newUser.Score = tmp.Score;
            newUser.Sign = tmp.Sign;

            CC.Users.Add(newUser);

            List<Userdata> userdatas = new List<Userdata>();
            foreach (var item in CC.Users)
            {
                Userdata t = new Userdata();
                t.Acount = item.Acount;
                t.Avart = item.Avart;
                t.Grade = item.Grade;
                t.Name = item.Name;
                t.Room = item.Room;
                t.Score = item.Score;
                t.Sign = item.Sign;
                userdatas.Add(t);
            }

            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName);
                user.callback.ShowInfo(userdatas);
            }
        }

        public void Talk(string userName, string message)
        {
            foreach (var item in CC.Users)
            {
                item.callback.ShowTalk(userName, message);
            }
        }

        /// <summary>用户退出</summary>
        public void Logout(string userName)
        {
            MyUser logoutUser = CC.GetUser(userName);
            CC.Users.Remove(logoutUser);

            List<Userdata> userdatas = new List<Userdata>();
            foreach (var item in CC.Users)
            {
                Userdata t = new Userdata();
                t.Acount = item.Acount;
                t.Avart = item.Avart;
                t.Grade = item.Grade;
                t.Name = item.Name;
                t.Room = item.Room;
                t.Score = item.Score;
                t.Sign = item.Sign;
                userdatas.Add(t);
            }
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogout(userName);
                user.callback.ShowInfo(userdatas);
            }
            logoutUser = null; //将其设置为null后，WCF会自动关闭该客户端

        }




        #endregion

        #region 游戏的服务端接口实现
        //进入房间
        public void EnterRoom(string userName, int roomId)
        {
            MyUser user = CC.GetUser(userName);
            user.inRoom = roomId;
            user.Score = 0;
            //初始化新房间
            if (CC.Rooms.ContainsKey(roomId) == false)
            {
                CC.Rooms.Add(roomId, new Room());
                CC.Rooms[roomId].users = new List<MyUser>();
                CC.Rooms[roomId].question = new questions();
            }
            //该用户添加到房间
            CC.Rooms[roomId].users.Add(user);

            //给该房间的所有用户发送最新用户消息
            foreach (var item in CC.Rooms[roomId].users)
            {
                string s = "";
                foreach (var v in CC.Rooms[roomId].users)
                {
                    s += v.Name + "," + v.Score.ToString() + ",";
                }
                item.callback.ShowRoom(s);
            }
        }
        public void StartGame(string userName, int roomId)
        {
            //当前用户已准备
            MyUser user = CC.GetUser(userName);
            user.ready = true;
            //判断当前房间内所有用户是否准备好
            foreach (var item in CC.Rooms[roomId].users)
            {
                if (!item.ready) return;
            }
            foreach (var item in CC.Rooms[roomId].users)
            {
                item.callback.ShowStart(CC.Rooms[roomId].users.First().Name, CC.Rooms[roomId].question.answer, CC.Rooms[roomId].question.tip);
            }
        }

        #endregion

    }
}

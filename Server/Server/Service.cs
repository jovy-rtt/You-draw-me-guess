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
        public void SendInk(int roomId, string ink)
        {
            foreach (var v in CC.Rooms[roomId].users)
            {
                v.callback.ShowInk(roomId,ink);
            }
        }

        #endregion



        /*-----------------------------------------------------  分割线   ---------------------------------------------------------------*/



        #region 聊天室的服务端函数实现

        //public Service()
        //{
        //    if (CC.Users == null)
        //    {
        //        CC.Users = new List<MyUser>();
        //    }
        //}

        public void Login(string userName)
        {
            // throw new NotImplementedException();
            OperationContext context = OperationContext.Current;
            IServiceCallback callback = context.GetCallbackChannel<IServiceCallback>();
            MyUser newUser = new MyUser(userName, callback);
            //newUser.inRoom = roomId;
            //初始化CC.rooms
            //if (CC.Rooms.ContainsKey(roomId)==false)
            //{
            //    CC.Rooms.Add(roomId, new Room());
            //    CC.Rooms[roomId].users = new List<MyUser>() ;
            //    CC.Rooms[roomId].question = new questions();
            //}
            //CC.Rooms[roomId].users.Add(newUser);
            CC.Users.Add(userName,newUser);
            //foreach (var user in CC.Rooms[roomId].users)
            //{
            newUser.callback.ShowLogin(userName);
            //}
        }

        public void Talk(int roomId,string userName, string message)
        {
            string ans = CC.Rooms[roomId].question.answer;
            if(message==ans)
            {
                foreach (var item in CC.Rooms[roomId].users)
                {
                    if(item.Name==userName)
                    {
                        item.addScore();
                        item.callback.ShowTalk("系统消息", "你猜中了");
                    }
                    else
                    {
                        item.callback.ShowTalk("系统消息", string.Format("{0}猜中了",item.Name));
                    }
                    item.callback.ShowWin(userName);
                }
                RollUserAndRestart(roomId);
            }
            else
            {
                foreach (var item in CC.Rooms[roomId].users)
                {
                    item.callback.ShowTalk(userName, message);
                }
            }
        }
        private void RollUserAndRestart(int roomId)
        {
            MyUser newuser = CC.Rooms[roomId].users.First();
            CC.Rooms[roomId].users.RemoveAt(0);
            CC.Rooms[roomId].users.Add(newuser);
            CC.Rooms[roomId].question.update();
            string s = "";
            foreach (var item in CC.Rooms[roomId].users)
            {
                foreach (var v in CC.Rooms[roomId].users)
                {
                    s += v.Name + "," + v.Score.ToString() + ",";
                }
            }
            foreach (var item in CC.Rooms[roomId].users)
            {
                item.callback.ShowNewTurn(s,CC.Rooms[roomId].users.First().Name, CC.Rooms[roomId].question.answer, CC.Rooms[roomId].question.tip);
            }
        }

        //public void Info(int roomId,string account)
        //{
        //    foreach (var item in CC.Rooms[roomId].users)
        //    {
        //        item.callback.ShowInfo(roomId,account);
        //    }
        //}



        /// <summary>用户退出</summary>
        public void Logout(int roomId, string userName)
        {
            MyUser logoutUser = CC.Users[userName];
            CC.Rooms[roomId].users.Remove(logoutUser);
            //CC.Users.Remove(logoutUser);
            foreach (var user in CC.Rooms[roomId].users)
            {
                //不需要发给退出用户
                //if (user.UserName != logoutUser.UserName)
                //{
                    user.callback.ShowLogout(userName);
                //}
            }
            logoutUser = null; //将其设置为null后，WCF会自动关闭该客户端

        }
        
        


        #endregion

        #region 游戏的服务端接口实现
        //进入房间
        public void EnterRoom(string userName, int roomId)
        {
            MyUser user = CC.Users[userName];
            user.inRoom = roomId;
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
                item.callback.ShowLogin(userName);
            }
        }
        public void StartGame(string userName, int roomId)
        {
            //当前用户已准备
            MyUser user = CC.Users[userName];
            user.ready = true;
            //判断当前房间内所有用户是否准备好
            foreach (var item in CC.Rooms[roomId].users)
            {
                if (!item.ready) return;
            }
            foreach (var item in CC.Rooms[roomId].users)
            {
                item.callback.ShowStart(CC.Rooms[roomId].users.First().Name,CC.Rooms[roomId].question.answer, CC.Rooms[roomId].question.tip);
            }
        }

        #endregion

    }
}

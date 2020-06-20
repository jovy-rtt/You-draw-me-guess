using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 服务端等整体框架已建好，服务接口和回调接口框架已建好，数据协定等用到时自建
    // 操作协定
    [ServiceContract(Namespace ="MyService",CallbackContract =typeof(IServiceCallback))]

        //服务接口
        public interface IService
    {
        /// <summary>
        /// test用例
        /// </summary>
        //[OperationContract]
        //void test();
        #region 远程登录服务接口
        //登录
        [OperationContract]
        bool Login(string id, string pw);

        //注册
        [OperationContract]
        bool Registered(string id, string pw, string sn, string name);

        //修改密码
        [OperationContract]
        bool ForgetPassword(string id,string ps);
        #endregion

        #region 画板的服务接口
        //发送数字墨迹
        [OperationContract(IsOneWay = true)]
        void SendInk(int room, string ink);
        #endregion

        #region 聊天室的服务接口
            //[OperationContract(IsOneWay = true)]
            //void Login(string userName);

            [OperationContract(IsOneWay = true)]
            void Logout(string userName);

            [OperationContract(IsOneWay = true)]
            void Talk(string userName, string message);
           
        #endregion
    }

    //回调接口
    public interface IServiceCallback
    {
        #region 画板的回调接口
        //回调显示墨迹 
        [OperationContract(IsOneWay = true)]
        void ShowInk(string ink);
        #endregion

        #region 聊天室的回调接口
                [OperationContract(IsOneWay = true)]
                void ShowLogin(string loginUserName);

                [OperationContract(IsOneWay = true)]
                void ShowLogout(string userName);

                [OperationContract(IsOneWay = true)]
                void ShowTalk(string userName, string message);

        #endregion
    }
}

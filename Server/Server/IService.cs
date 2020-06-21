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
    [ServiceContract(Namespace = "MyService", CallbackContract = typeof(IServiceCallback))]

    //服务接口
    public interface IService
    {

        [OperationContract]
        bool test();


        #region 画板的服务接口
        //发送数字墨迹
        [OperationContract(IsOneWay = true)]
        void SendInk(int room, string ink);

        #endregion

        #region 聊天室的服务接口
        [OperationContract(IsOneWay = true)]
        void Login(string userName);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        [OperationContract(IsOneWay = true)]
        void Talk(string userName, string message);

        [OperationContract(IsOneWay = true)]
        void Info(string account);

        #endregion

        #region 游戏的服务接口
        //进入房间
        [OperationContract(IsOneWay = true)]
        void EnterRoom(string userName, int roomId);
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

        [OperationContract(IsOneWay = true)]
        void ShowInfo(string account);

        #endregion

        #region 游戏的回调接口
        //回调进入房间
        [OperationContract(IsOneWay = true)]
        void ShowRoom(string userName);
        #endregion
    }

    [DataContract]
    public class Room
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public List<MyUser> users { get; set; }
        [DataMember]
        public Questions question { get; set; }
    }
}

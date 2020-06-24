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

        //[OperationContract(IsOneWay = true)]
        //void Info(string account);

        #endregion

        #region 游戏的服务接口
        //进入房间
        [OperationContract(IsOneWay = true)]
        void EnterRoom(string userName, int roomId);

        //开始游戏
        [OperationContract(IsOneWay = true)]
        void StartGame(string userName, int roomId);
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

        //为了刷新用户列表
        [OperationContract(IsOneWay = true)]
        void ShowInfo(List<Userdata> userdatas);

        #endregion

        #region 游戏的回调接口
        //回调进入房间
        [OperationContract(IsOneWay = true)]
        void ShowRoom();

        //回调开始游戏
        [OperationContract(IsOneWay = true)]
        void ShowStart(string userName1,string answer,string tip);
        //回调胜利
        [OperationContract(IsOneWay = true)]
        void ShowWin(string userName,string userName0);
        //回调开始新游戏
        [OperationContract(IsOneWay = true)]
        void ShowNewTurn(string roommeg, string userName1, string answer, string tip);
        #endregion
    }
    [DataContract]
    public class questions
    {
        [DataMember]
        public string answer { get; set; }
        [DataMember]
        public string tip { get; set; }
        private Random r=new Random();
        public questions()
        {
            update();
        }
        public void update()
        {
            int num = r.Next(1, 20 + 1);
            MyDbEntities myDbEntities = new MyDbEntities();
            var q = from t in myDbEntities.Questions
                    where t.Id == num
                    select t;
            if (q.Count() > 0)
            {
                var Q = q.First();
                answer = Q.Question;
                tip = Q.Tip;
            }
        }
    }

    [DataContract]
    public class Room
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public List<MyUser> users { get; set; }
        [DataMember]
        public questions question { get; set; }
        
    }

    [DataContract]
    public class Userdata
    {
        [DataMember]
        public string Acount { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Avart { get; set; }
        [DataMember]
        public int Grade { get; set; }
        [DataMember]
        public string Sign { get; set; }
        [DataMember]
        public Nullable<int> Score { get; set; }
        [DataMember]
        public Nullable<int> Room { get; set; }
    }
}

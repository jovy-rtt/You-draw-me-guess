using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    [ServiceContract(Namespace = "MyService", CallbackContract = typeof(ICheckinServerCallback))]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICheckinServer”。
   
    public interface ICheckinServer
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        [OperationContract(IsOneWay = true)]
        void Checkin(string userName, int roomnumber);

        [OperationContract(IsOneWay = true)]
        void Talk(string userName, string message);


    }

    public interface ICheckinServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string loginUserName);

        [OperationContract(IsOneWay = true)]
        void ShowLogout(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowCheckin(string userName, int roomnumber);

        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);
    }
}

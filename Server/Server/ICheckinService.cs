using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{

    [ServiceContract(Namespace = "MyService", CallbackContract = typeof(IServiceCallback))]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICheckinService”。
   
    public interface ICheckinService
    {
        

        [OperationContract(IsOneWay = true)]
        void Checkin(string userName, int roomnum);
    }

    public interface ICheckinServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ShowCheckin(string userName, int roomnum);
    }


}

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
        [OperationContract]
        void test();

        #region 画板的服务接口
        [OperationContract]
        void test0();
        #endregion

        #region 聊天室的服务接口
        [OperationContract]
        void test1();
        #endregion
    }

    //回调接口
    public interface IServiceCallback
    {
        #region 画板的回调接口
        [OperationContract]
        void test2();
        #endregion

        #region 聊天室的回调接口
        [OperationContract]
        void test3();
        #endregion
    }
}

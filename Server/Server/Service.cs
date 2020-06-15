using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 实现函数的时候，用三个/ 来定义一下函数说明，说明函数的大概功能、（参数，返回值，可选可不选）
    // 整体框架已建好，注意分割线，画板函数实现在#region 画板... 这里面，聊天室在# region 聊天室这里

    public class Service : IService
    {

        /// <summary>
        /// 测试用例
        /// </summary>
        public void test()
        {
            throw new NotImplementedException();
        }


        /*-----------------------------------------------------  分割线   ---------------------------------------------------------------*/
        
        #region 画板的服务端函数实现
        public void test0()
        {
            throw new NotImplementedException();
        }
        #endregion



        /*-----------------------------------------------------  分割线   ---------------------------------------------------------------*/



        #region 聊天室的服务端函数实现
        public void test1()
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}

using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
        #region 远程登录服务函数实现
        //远程登录
        public bool Login(string id, string pw)
        {
            //用户信息
            User us;
            //数据库实例
            MyDbEntities myDbEntities = new MyDbEntities();
            //选中这一条数据
            var q = from t in myDbEntities.User
                    where t.Acount == id
                    select t;
            if (q != null)
            {
                us = q.FirstOrDefault();
                if (us == null)
                    return false;
                if (us.Password == pw)
                    return true;
            }
            return false;
        }
        //远程注册
        public bool Registered(string id, string pw, byte[] phote, string sn, string name)
        {
            User us = new User();
            MyDbEntities myDbEntities = new MyDbEntities();
            us.Acount = id;
            us.Password = pw;
            us.Avart = phote;
            us.Sign = sn;
            us.Name = name;
            try
            {
                myDbEntities.User.Add(us);
                myDbEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //return false;
        }
        //修改密码
        public bool ForgetPassword(string id,string pw)
        {
            //用户信息
            User us;
            //数据库实例
            MyDbEntities myDbEntities = new MyDbEntities();
            //选中这一条数据
            var q = from t in myDbEntities.User
                    where t.Acount == id
                    select t;
            if (q != null)
            {
                us = q.FirstOrDefault();
                if (us == null)
                    return false;
                us.Password = pw;
                try
                {
                    myDbEntities.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
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

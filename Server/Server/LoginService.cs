using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“LoginService”。
    public class LoginService : ILoginService
    {
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
        public bool Registered(string id, string pw, string sn, string name)
        {
            User us = new User();
            MyDbEntities myDbEntities = new MyDbEntities();
            us.Acount = id;
            us.Password = pw;
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
        public bool ForgetPassword(string id, string pw)
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

        public User Userinfo(string id)
        {
            User us=null;
            //数据库实例
            MyDbEntities myDbEntities = new MyDbEntities();
            //选中这一条数据
            var q = from t in myDbEntities.User
                    where t.Acount == id
                    select t;
            us = q.FirstOrDefault();
            return us;
        }
        #endregion
    }
}

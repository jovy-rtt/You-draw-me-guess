using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client.ServiceReference;
using Client.LoginReference;

namespace Client
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        //全局变量
        private User item;//每一个id所属，item可以控制该id下的所有窗口
        private LoginServiceClient client;//服务端接口
        private LoginReference.User us;//该用户的所有信息
        public LoginWindow()
        {
            InitializeComponent();
            client = new LoginServiceClient();
        }


        //所有button事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == sign_in)//登录事件
            {
                try
                {
                    //登录检测，true则为登录成功
                    bool flag = client.Login(account.Text, passward.Password);
                    if (flag)
                    {
                        //登录成功首先获取到该用户的所有信息，然后为传参做准备
                        us = client.Userinfo(account.Text);
                        //生成该用户的关联窗体的关系
                        if (CC.Users == null)
                        {
                            CC.Users = new List<User>();
                        }
                        User newuser = new User(us.Acount);
                        CC.Users.Add(newuser);
                        item = CC.GetUser(us.Acount);
                        item.LoginWindow = this;
                        item.LoginWindow.Close();
                       // item.MainWindow.ShowLogin(us.Name);

                        //再显示登录后的界面，room
                        RoomWindow RW = new RoomWindow(us);
                        item.RoomWindow = RW;
                        item.RoomWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("未连接到服务器！");
                }
                
            }
            else if (e.Source == forgetPw)//忘记密码事件
            {
                this.Close();
                ForgetPwWindow FP = new ForgetPwWindow();
                FP.Show();
            }
            else if (e.Source == sign_for)//注册事件
            {
                this.Close();
                RegisteredWindow RW = new RegisteredWindow();
                RW.Show();
            }
        }
    }
}

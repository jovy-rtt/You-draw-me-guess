using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Client
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        //全局变量
        private string id = "";
        private User item;
        private ServiceClient client;
        public LoginWindow()
        {
            InitializeComponent();
            if (CC.Users == null)
            {
                CC.Users = new List<User>();
            }
            init();
        }

        //初始化
        private void init()
        {
            Random rm = new Random();
            for (int i = 0; i < 20; i++)
            {
                id+=rm.Next(0,10).ToString();
            }
            User newuser = new User(id);
            CC.Users.Add(newuser);
            item = CC.GetUser(id);
            item.LoginWindow = this;
        }

        //所有button事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == sign_in)//登录事件
            {
                try
                {
                    //bool flag = client.Login(account.Text, passward.Password);
                    
                    bool flag = true;
                    if (flag)
                    {
                        item.LoginWindow.Close();
                        //再显示登录后的界面，room
                        RoomWindow RW = new RoomWindow();
                        RW.id = id;
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
                item.LoginWindow.Hide();
                ForgetPwWindow FP = new ForgetPwWindow();
                item.ForgetPwWindow = FP;
                item.ForgetPwWindow.id = id;
                item.ForgetPwWindow.Show();
            }
            else if (e.Source == sign_for)//注册事件
            {
                item.LoginWindow.Hide();
                RegisteredWindow RW = new RegisteredWindow();
                item.RegisteredWindow = RW;
                item.RegisteredWindow.id = id;
                item.RegisteredWindow.Show();
            }
        }
    }
}

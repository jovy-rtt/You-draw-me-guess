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
    public partial class Login : Window
    {
        private ServiceClient client;
        public Login()
        {
            InitializeComponent();
        }

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
                        MessageBox.Show("登录成功！");
                        //再显示登录后的界面，room
                        StartNewWindow();
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
                //暂放
            }
            else if (e.Source == sign_for)//注册事件
            {
                //暂放
            }
        }

        //Closing事件
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //App.Current.Shutdown();
        }

        private void StartNewWindow()
        {   
            RoomWindow w = new RoomWindow();
            //w.Left = left;
            //w.Top = top;
            w.Owner = this;
            w.Closed += (sender, e) => this.Activate();
            this.Hide();
            w.Show();
        }
    }
}

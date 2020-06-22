using Client.CheckinReference;
using Client.LoginReference;
using Client.ServiceReference;
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

namespace Client
{
    /// <summary>
    /// RoomWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RoomWindow : Window, ICheckinServerCallback
    {
       // private ServiceClient client;//服务端调用
        private LoginServiceClient loginclient;
        private CheckinServerClient Checkinclient;
        private User item;//每一个id所属，item可以控制该id下的所有窗口
        public LoginReference.User us;//用户的所有信息


        public RoomWindow(LoginReference.User ustmp)
        {
            InitializeComponent();
            us = ustmp;
            item = CC.GetUser(us.Acount);
            Checkinclient = new CheckinServerClient(new InstanceContext(this));
            loginclient = new LoginServiceClient();
            if (us.Avart == null)
                us.Avart = "boy.png";
            this.photo.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + us.Avart));
            Checkinclient.Login(us.Name);
            this.username.Text = us.Name + "快选择一个房间开始游戏吧！";
        }

        //进入房间
        private void room_Click(object sender, RoutedEventArgs e)
        {
            //确定点击了几号房间
            Button bt = e.Source as Button;
            int idx = (int)((bt.Name)[4]) - 48;
            Checkinclient.Checkin(us.Name, idx);
            //MessageBox.Show("进入" + idx + "号房间");

            //设置大厅隐藏，打开游戏
            item.RoomWindow.Hide();
            MainWindow mw = new MainWindow(us);
            mw.roomId = idx;
            item.MainWindow = mw;
            item.MainWindow.Show();

            //回调进入房间
            //client.EnterRoom(username.Text, idx);
        }

        //用于绑定enter键
        private void SendBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //退出游戏
        private void exitBnt_Click(object sender, RoutedEventArgs e)
        {
            Checkinclient.Logout(us.Name);
            this.Close();

        }

        #region 聊天室的回调函数实现

        public void ShowLogin(string loginUserName)
        {
            this.PlayerInfo.Text += "[" + loginUserName + "]" + "进入游戏" + '\n';
        }

        /// <summary>其他用户退出</summary>
        public void ShowLogout(string userName)
        {
            this.PlayerInfo.Text += "[" + userName + "]" + "退出游戏" + '\n';
        }

        public void ShowCheckin(string userName, int roomnumber)
        {
            this.PlayerInfo.Text += "[" + userName + "]说：" + "进入了"+roomnumber+"号房间" + '\n';
        }

        public void ShowTalk(string userName, string message)
        {
            this.PlayerInfo.Text += "[" + userName + "]说：" + message + '\n';
        }

        private void SendBnt_Click(object sender, RoutedEventArgs e)
        {
            Checkinclient.Talk(us.Name, this.SendBox.Text);
            this.SendBox.Text = "";
        }

        #endregion


    }
}

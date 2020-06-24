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
        //private ServiceClient client;//服务端调用
        private LoginServiceClient loginclient;
        private CheckinServerClient Checkinclient;
        private User item;//每一个id所属，item可以控制该id下的所有窗口
        public LoginReference.User us;//用户的所有信息
        MediaPlayer player = new MediaPlayer();

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
            //音效
            
            player.Open(new Uri("bgm.mp3", UriKind.Relative));
            player.Play();
        }

        //进入房间
        private void room_Click(object sender, RoutedEventArgs e)
        {
            //确定点击了几号房间
            Button bt = e.Source as Button;
            int idx = (int)((bt.Name)[4]) - 48;
            Checkinclient.Checkin(us.Name, idx);

            //设置大厅隐藏，打开游戏
            item.RoomWindow.Hide();
            MainWindow mw = new MainWindow(us);
            mw.roomId = idx;
            mw.us = us;
            item.MainWindow = mw;
            item.MainWindow.Show();

            //回调进入房间
            item.MainWindow.EnterRoom(us.Name, idx);
            //client.EnterRoom(us.Name, idx);
        }

        //用于绑定enter键
        private void SendBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                Checkinclient.Talk(us.Name, this.SendBox.Text);
                this.SendBox.Text = "";
            }
        }

        private void SendBnt_Click(object sender, RoutedEventArgs e)
        {
            Checkinclient.Talk(us.Name, this.SendBox.Text);
            this.SendBox.Text = "";
        }

        //退出游戏
        private void exitBnt_Click(object sender, RoutedEventArgs e)
        {
            Checkinclient.Logout(us.Name);
            this.Close();

        }

        //显示玩家信息
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerInfo PI = new PlayerInfo(us);
            PI.ShowDialog();
        }


        #region 聊天室的回调函数实现

        public void ShowLogin(string loginUserName)
        {
            this.PlayerInfo.Text += "[" + loginUserName + "]" + "进入大厅" + '\n';
        }

        /// <summary>其他用户退出</summary>
        public void ShowLogout(string userName)
        {
            this.PlayerInfo.Text += "[" + userName + "]" + "退出大厅" + '\n';
        }

        public void ShowCheckin(string userName, int roomnumber)
        {
            this.PlayerInfo.Text += "[" + userName + "]" + "进入了"+roomnumber+"号房间" + '\n';
        }

        public void ShowTalk(string userName, string message)
        {
            this.PlayerInfo.Text += "[" + userName + "]说：" + message + '\n';
        }





        #endregion

       public int musiccount = 0;
        private void music_Click(object sender, RoutedEventArgs e)
        {
            musiccount++;
            if (musiccount % 2 == 1)
                player.Stop();
            else
                player.Play();
        }
    }
}

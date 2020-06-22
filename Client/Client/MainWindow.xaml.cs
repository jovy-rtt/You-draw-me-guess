using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.ServiceReference;
using Client.LoginReference;

//已添加服务引用，命名空间为：ServiceReference
//服务引用地址为：http://localhost:8733/Design_Time_Addresses/Service/  该地址为本地调试地址

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IServiceCallback
    {
        private ServiceClient client;
        private LoginServiceClient loginclient;
        public int roomId;//暂用
        public LoginReference.User us;//用户的所有信息
        private User item;//每一个id所属，item可以控制该id下的所有窗口
        //画板相关
        private DrawingAttributes inkDA;
        private Color currentColor;

        //传参方式的变化
        public MainWindow(LoginReference.User ustmp)
        {
            InitializeComponent();
            us = ustmp;
            item = CC.GetUser(us.Acount);
        }





        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 客户端内的方法
        //画板相关+聊天室登录信息显示
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化两个服务端接口
            client = new ServiceClient(new InstanceContext(this));
            loginclient = new LoginServiceClient();
            //显示登录
            client.Login(us.Name);
            client.Info(us.Acount); 
            this.textBoxUserName.Content = us.Name;

            //初始化墨迹和画板
            currentColor = Colors.Red;
            inkDA = new DrawingAttributes()
            {
                Color = currentColor,
                Height = 6,
                Width = 6,
                FitToCurve = false
            };
            inkcanvas.DefaultDrawingAttributes = inkDA;
            inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        //用户信息显示
        private void user1Btn1_Click(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                //this.U1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
                PlayerInfo pi = new PlayerInfo(us);
                pi.ShowDialog();
            }
        }
        private void user1Btn2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void user1Btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        //用于绑定enter建
        private void SendBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                client.Talk(us.Name, this.SendBox.Text);
                this.SendBox.Text = "";
            }
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            client.Talk(us.Name, this.SendBox.Text);
            this.SendBox.Text = "";
        }
        private void exitBnt_Click(object sender, RoutedEventArgs e)
        {
            client.Logout(us.Name);
            this.Close();
            item.RoomWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Logout(us.Name);
            item.RoomWindow.Show();
        }
        #endregion



        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 画板的回调函数实现
        /// <summary>
        /// 画板：将InkCanvas的墨迹转换为String
        /// </summary>
        private void ink_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StrokeCollection sc = inkcanvas.Strokes;
            string inkData = (new StrokeCollectionConverter()).ConvertToString(sc);

            client.SendInk(roomId, inkData);
        }
        public void ShowInk(string inkData)
        {
            //删除原有的Strokes
            inkcanvas.Strokes.Clear();

            //将String转换为InkCanvas的墨迹
            Type tp = typeof(StrokeCollection);
            StrokeCollection sc =
                (StrokeCollection)(new StrokeCollectionConverter()).ConvertFrom(inkData);

            //新Strokes添加到InkCanvas中
            inkcanvas.Strokes = sc;
        }
        /// <summary>
        /// 画板：初始化画笔和画板
        /// </summary>
        private void InitColor()
        {
            inkDA.Color = currentColor;
            inkcanvas.DefaultDrawingAttributes = inkDA;
        }
        /// <summary>
        /// 画板：画板界面按钮
        /// </summary>
        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            string name = (e.Source as Button).Name;
            switch (name)
            {
                case "red":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Red;
                    InitColor();
                    break;
                case "yellow":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Yellow;
                    InitColor();
                    break;
                case "blue":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Blue;
                    InitColor();
                    break;
                case "green":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Green;
                    InitColor();
                    break;
                case "pink":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Pink;
                    InitColor();
                    break;
                case "black":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    currentColor = Colors.Black;
                    InitColor();
                    break;
                case "delete":
                    inkcanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "clear":
                    inkcanvas.Strokes.Clear();
                    StrokeCollection sc = inkcanvas.Strokes;
                    string inkData = (new StrokeCollectionConverter()).ConvertToString(sc);
                    client.SendInk(roomId, inkData);
                    break;
            }
        }
        #endregion


        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 聊天室的回调函数实现

        public void ShowLogin(string loginUserName)
        {
            this.ConversationBox.Text += "[" + loginUserName + "]" + "进入房间" + '\n';
        }

        /// <summary>其他用户退出</summary>
        public void ShowLogout(string userName)
        {
            this.ConversationBox.Text += "[" + userName + "]" + "退出房间" + '\n';
        }

        public void ShowTalk(string userName, string message)
        {
            this.ConversationBox.Text += "[" + userName + "]说：" + message + '\n';
        }

        public void ShowInfo(string account)
        {
            //this.U1.Text += " 昵称：" + us.Name + '\n' + " 等级：" + us.Grade + '\n' + '\n';
            LoginReference.User[] usarr = new LoginReference.User[4];
            int cnt = 0;
            foreach (var item in CC.Users)
            {
                usarr[cnt++] = loginclient.Userinfo(item.id);
            }
            //得到了已登录的所有用户的信息
            if (usarr[0].Avart == null)
                usarr[0].Avart = "boy.png";
            this.photo1.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + usarr[0].Avart));
            this.U1.Text += " 昵称：" + usarr[0].Name + '\n' + " 等级：" + usarr[0].Grade + '\n' ;

            if (cnt == 1)
                return;

            if (usarr[1].Avart == null)
                usarr[1].Avart = "boy.png";
            this.photo2.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + usarr[1].Avart));
            this.U2.Text += " 昵称：" + usarr[1].Name + '\n' + " 等级：" + usarr[1].Grade + '\n' ;

            if (cnt == 2)
                return;

            if (usarr[2].Avart == null)
                usarr[2].Avart = "boy.png";
            this.photo3.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + usarr[2].Avart));
            this.U3.Text += " 昵称：" + usarr[2].Name + '\n' + " 等级：" + usarr[2].Grade + '\n' ;

            if (cnt == 3)
                return;

            if (usarr[3].Avart == null)
                usarr[3].Avart = "boy.png";
            this.photo4.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + usarr[3].Avart));
            this.U4.Text += " 昵称：" + usarr[3].Name + '\n' + " 等级：" + usarr[3].Grade + '\n' + '\n';

        }



        #endregion

        #region 游戏的回调函数实现
        public void EnterRoom(string userName,int rooomId)
        {
            client.EnterRoom(userName, roomId);
        }
        public void ShowRoom(string roommeg)
        {
            UserBox.Items.Clear();
            //显示各个选手得分
            string[] s = roommeg.Split(',');
            for (int i = 0; i+1 < s.Length; i += 2)
            {
                UserBox.Items.Add(s[i] + "---" + s[i + 1] + "分");
                if (us.Name == s[i]) ScoreLabel.Content = s[i + 1];
            }
            //初始画板都不可使用
            inkcanvas.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            readybtn.IsEnabled = false;
            readybtn.Content = "已准备";
            client.StartGame(us.Name, roomId);
        }
        public void ShowStart(string userName1, string answer, string tip)
        {
            inkcanvas.Strokes.Clear();
            //画图者
            if(us.Name==userName1)
            {
                inkcanvas.IsEnabled = true;
                sendbtn.IsEnabled = false;
                TipLabel.Content = "题目：" + answer;
                ConversationBox.Text += "系统提示：请开始绘画\n";
            }
            //猜图者
            else
            {
                inkcanvas.IsEnabled = false;
                sendbtn.IsEnabled = true;
                TipLabel.Content = "提示：" + tip;
                ConversationBox.Text += "系统提示：请开始抢答\n";
            }
        }



        #endregion


    }
}

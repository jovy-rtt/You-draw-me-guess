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
    public partial class MainWindow : Window,IServiceCallback
    {
        private ServiceClient client;
        private LoginServiceClient loginclient;
        public int room;//暂用
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
            if(e.Key==Key.Enter)
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

            client.SendInk(room, inkData);
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
                    client.SendInk(room, inkData);
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
            this.U1.Text += "  昵称：" + us.Name + '\n' + "  等级：" + us.Grade + '\n' + '\n';
        }



        #endregion

        #region 游戏的回调函数实现
        public void ShowRoom(string roommeg)
        {
            //UserBox.Items.Clear();
            //显示各个选手得分
            //string[] s = roommeg.Split(',');
            //for (int i = 0; i < s.Length; i += 2)
            //{
            //    UserBox.Items.Add(s[i] + "---" + s[i + 1] + "分");
            //    if (UserName == s[i]) ScoreLabel.Content = s[i + 1];
            //}
            //初始画板都不可使用
            //inkcanvas.IsEnabled = false;
        }




        #endregion

        
    }
}

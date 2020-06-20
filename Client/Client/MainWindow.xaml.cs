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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.ServiceReference;

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
        public int room;//暂用
        public string id { get; set; }//id所属

        private User item;//对象

        public MainWindow()
        { 
            InitializeComponent();
            client = new ServiceClient(new InstanceContext(this));
            //bool flag = client.test();
            //MessageBox.Show(flag.ToString());
        }

        

        //画板相关
        private DrawingAttributes inkDA;
        private Color currentColor;

        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 客户端内的方法
        //画板相关
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //创建客户端代理类
            InstanceContext context = new InstanceContext(this);
            client = new ServiceClient(context);
            client.Login("test");
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
                PlayerInfo pi = new PlayerInfo();
                pi.ShowDialog();
            }
        }
        private void user1Btn2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void user1Btn3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void send_Click(object sender, RoutedEventArgs e)
        {
            client.Talk(UserName, this.SendBox.Text);
        }
        private void exitBnt_Click(object sender, RoutedEventArgs e)
        {
            client.Logout(textBoxUserName.Text);
            this.Close();
        }
        #endregion



        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 画板的回调函数实现
        /// <summary>
        /// 画板：将InkCanvas的墨迹转换为String
        /// </summary>
        private void ink1_MouseUp(object sender, MouseButtonEventArgs e)
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
                    break;
            }
        }
        #endregion


        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 聊天室的回调函数实现
        public string UserName
        {
            get { return textBoxUserName.Text; }
            set { textBoxUserName.Text = value; }
        }

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
            AddColorMessage(userName, message);
        }
        private void AddColorMessage(string userName, string str)
        {
            this.ConversationBox.Text += "[" + userName + "]说：" + str + '\n';
        }

        #endregion


    }
}

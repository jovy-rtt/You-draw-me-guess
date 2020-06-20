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

namespace Client
{
    /// <summary>
    /// RoomWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RoomWindow : Window
    {
        //id所属
        public string id { get; set; }
        //对象
        private User item;
        //上面哪两个对于登录信息有用，勿删

        public RoomWindow()
        {
            InitializeComponent();
            item = CC.GetUser(id);
        }

        public string UserName
        {
            get { return username.Text; }
            set { username.Text = value +"快选择一个房间开始游戏吧！"; }
        }
        /// <summary>
        /// 进入房间的按钮事件
        /// </summary>
        private void room_Click(object sender, RoutedEventArgs e)
        {
            //确定点击了几号房间
            Button bt = e.Source as Button;
            int idx = (int)((bt.Name)[4]) - 48;
            MessageBox.Show("进入" + idx + "号房间");

            //设置大厅关闭，打开游戏
            this.Close();
            MainWindow mw = new MainWindow();
            mw.room = idx;
            mw.id = id;
            mw.Show();

            //更改本地user的房间号
            //this.user.inRoom = idx;

            ////回调进入房间
            //client.EnterRoom(user.name, idx);
        }
        //public void ShowRoom(Room room)
        //{
        //    ////更新用户列表

        //    ////显示积分

        //    //只有游戏开始后、某一个玩家可以使用画板
        //}
    }
}

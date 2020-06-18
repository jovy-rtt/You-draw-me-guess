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
        ServiceClient client;
        public MainWindow()
        { 
            InitializeComponent();
            client = new ServiceClient(new InstanceContext(this));
        }

        //画板相关
        private DrawingAttributes inkDA;
        private DrawingAttributes highlighterDA;
        private Color currentColor;

        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 客户端内的方法
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //创建客户端代理类
            InstanceContext context = new InstanceContext(this);
            client = new ServiceClient(context);

            //初始化墨迹和画板
            currentColor = Colors.Red;
            inkDA = new DrawingAttributes()
            {
                Color = currentColor,
                Height = 6,
                Width = 6,
                FitToCurve = false
            };
            highlighterDA = new DrawingAttributes()
            {
                Color = Colors.Orchid,
                IsHighlighter = true,
                IgnorePressure = false,
                StylusTip = StylusTip.Rectangle,
                Height = 30,
                Width = 10
            };
            inkcanvas.DefaultDrawingAttributes = inkDA;
            inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        #endregion



        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 画板的回调函数实现
        /// <summary>
        /// 5、画板
        /// </summary>
        private void ink1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //将InkCanvas的墨迹转换为String
            StrokeCollection sc = inkcanvas.Strokes;
            string inkData = (new StrokeCollectionConverter()).ConvertToString(sc);

            client.SendInk(user, inkData);
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
        private void InitColor()
        {//初始化画笔和画板
            inkDA.Color = currentColor;
            //rrbPen.IsChecked = true;
            inkcanvas.DefaultDrawingAttributes = inkDA;
        }
        private void RibbonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string name = (e.Source as RibbonRadioButton).Label;
            switch (name)
            {
                case "钢笔":
                    InitColor();
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "荧光笔":
                    inkcanvas.DefaultDrawingAttributes = highlighterDA;
                    break;
                case "红色":
                    currentColor = Colors.Red;
                    InitColor();
                    break;
                case "绿色":
                    currentColor = Colors.Green;
                    InitColor();
                    break;
                case "蓝色":
                    currentColor = Colors.Blue;
                    InitColor();
                    break;
                case "墨迹":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "手势":
                    inkcanvas.EditingMode = InkCanvasEditingMode.GestureOnly;
                    break;
                case "套索选择":
                    inkcanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "点擦除":
                    inkcanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "笔画擦除":
                    inkcanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }
        #endregion


        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 聊天室的回调函数实现
        public void test3()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

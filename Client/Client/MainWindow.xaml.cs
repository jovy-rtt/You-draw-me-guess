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

        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 客户端内的方法


        #endregion



        /*----------------------------------------------------- 分割线  ----------------------------------------------------------------*/
        #region 画板的回调函数实现
        public void test2()
        {
            throw new NotImplementedException();
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

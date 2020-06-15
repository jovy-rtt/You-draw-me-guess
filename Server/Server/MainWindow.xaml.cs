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

namespace Server
{
    public partial class MainWindow : Window
    {

        //该窗口是用于手动控制“你画我猜”应用程序的服务端，仅用于启动以及停止监听
        //by 朱孟祥

        private ServiceHost host;
        public MainWindow()
        {
            InitializeComponent();
        }

        //启动服务
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ChangeState(btnStart, false, btnStop, true);
            host = new ServiceHost(typeof(Service));
            host.Open();
            textBlock1.Text += "本机服务已启动，监听的Uri为：\n";
            foreach (var v in host.Description.Endpoints)
            {
                textBlock1.Text += v.ListenUri.ToString() + "\n";
            }
        }

        //关闭服务
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            host.Close();
            textBlock1.Text += "本机服务已关闭\n";
            ChangeState(btnStart, true, btnStop, false);
        }

        //改变按钮状态
        private static void ChangeState(Button btnStart, bool isStart, Button btnStop, bool isStop)
        {
            btnStart.IsEnabled = isStart;
            btnStop.IsEnabled = isStop;
        }

        //窗体关闭事件，防止窗体关闭但是服务未关闭
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (host != null)
            {
                if (host.State == CommunicationState.Opened)
                {
                    host.Close();
                }
            }
        }
    }
}

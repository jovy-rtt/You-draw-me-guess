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

        private ServiceHost host1;
        private ServiceHost host2;
        private ServiceHost host3;

        public MainWindow()
        {
            InitializeComponent();
        }

        //启动服务
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ChangeState(btnStart, false, btnStop, true);
            host1 = new ServiceHost(typeof(Service));
            host1.Open();
            textBlock1.Text += "本机服务已启动，监听的Uri为：\n";
            foreach (var v in host1.Description.Endpoints)
            {
                textBlock1.Text += v.ListenUri.ToString() + "\n";
            }

            host2 = new ServiceHost(typeof(LoginService));
            host2.Open();
            //textBlock1.Text += "本机服务已启动，监听的Uri为：\n";
            foreach (var v in host2.Description.Endpoints)
            {
                textBlock1.Text += v.ListenUri.ToString() + "\n";
            }

            host3 = new ServiceHost(typeof(CheckinServer));
            host3.Open();
            //textBlock1.Text += "本机服务已启动，监听的Uri为：\n";
            foreach (var v in host3.Description.Endpoints)
            {
                textBlock1.Text += v.ListenUri.ToString() + "\n";
            }


        }

        //关闭服务
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            host1.Close();
            host2.Close();
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
            if (host1 != null)
            {
                if (host1.State == CommunicationState.Opened)
                {
                    host1.Close();
                }
            }

            if (host2 != null)
            {
                if (host2.State == CommunicationState.Opened)
                {
                    host2.Close();
                }
            }

            if (host3 != null)
            {
                if (host3.State == CommunicationState.Opened)
                {
                    host3.Close();
                }
            }
        }
    }
}

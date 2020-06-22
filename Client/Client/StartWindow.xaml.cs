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
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }
        //启动四个客户端
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            StartNewWindow(0,400);
            StartNewWindow(0, 0);
            StartNewWindow(800,0);
            StartNewWindow(800, 400);
        }

        private void StartNewWindow(int left, int top)
        {
            LoginWindow w = new LoginWindow();
            w.Left = left;
            w.Top = top;
            //w.Owner = this;
            w.Closed += (sender, e) => this.Activate();
            w.Show();
        }

        //启动一个客户端
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            StartNewWindow(400,400);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}

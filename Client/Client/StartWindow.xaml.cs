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
            CC.StartWindow = this;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            StartNewWindow(580, 300);
            StartNewWindow(0, 0);
        }

        private void StartNewWindow(int left, int top)
        {
            LoginWindow w = new LoginWindow();
            w.Left = left;
            w.Top = top;
            w.Owner = this;
            w.Closed += (sender, e) => this.Activate();
            w.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow w = new LoginWindow();
            w.Owner = this;
            w.Closed += (sendObj, args) => this.Activate();
            w.Show();
        }
    }
}

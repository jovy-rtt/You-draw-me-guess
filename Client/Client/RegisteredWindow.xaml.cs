using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// RegisteredWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisteredWindow : Window
    {
        //id所属
        public string id { get; set; }
        //对象
        private User item;
        //验证码
        private string Verification;
        private ServiceClient client;
        public RegisteredWindow()
        {
            InitializeComponent();
            Verification = GetImage();
        }

        public string GetImage()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            ImageSource imageSource = ImageFormatConvertHelper.ChangeBitmapToImageSource(bitmap);
            img.Source = imageSource;
            //为了实现不区分大小写
            code = code.ToLower();
            return code;
        }

        //验证输入密码是否符合要求
        private void PassWord2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassWord2.Password != PassWord1.Password)
            {
                img2.Source = new BitmapImage(new Uri("pack://application:,,,/image/错.png"));
            }
            else
            {
                img2.Source = new BitmapImage(new Uri("pack://application:,,,/image/对.png"));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //bt1是提交事件,bt2是帮助事件，bt3是联系我们事件
            if (e.Source == bt1)
            {
                //判断是否为机器，验证码的真伪
                if (Code.Text.ToLower() != Verification)
                {
                    MessageBox.Show("验证码输入错误！请重新输入", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                    Verification = GetImage();
                    Code.Text = "";
                    return;
                }
               
                //判断密码是否符合要求
                if (PassWord1.Password != PassWord2.Password)
                {
                    MessageBox.Show("请输入确保两次输入的密码一致！", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                    Verification = GetImage();
                    Code.Text = "";
                    return;
                }
                if (PassWord1.Password.Length < 6 || PassWord1.Password.Length > 16)
                {
                    MessageBox.Show("密码长度必须不小于6位，不大于16位！", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                    Verification = GetImage();
                    Code.Text = "";
                    return;
                }
                
            }
            if (e.Source == bt2)
            {
                MessageBox.Show("暂不支持人工智能帮助，如有需要，请点击‘联系我们’，人工客服将为您服务。", "帮助", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            if (e.Source == bt3)
            {
                MessageBox.Show("如有需要帮助，请联系微信：root_5476", "联系我们");
            }
            //开始向服务端申请，尝试修改密码
            try
            {
                bool flag = client.Registered(Account.Text, PassWord2.Password, Sign.Text, AccountName.Text);
                if (flag)
                    MessageBox.Show("注册成功！");
                else
                    MessageBox.Show("注册失败，该账号可能已存在！");
            }
            catch (Exception)
            {
                MessageBox.Show("与远程服务器连接失败！", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            }
            
        }

        //关闭窗口事件
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            item = CC.GetUser(id);
            item.LoginWindow.Show();
        }


        //鼠标移入事件
        private void AMouseEnter(object sender, MouseEventArgs e)
        {
            if (e.Source == Account)
            {
                if (Account.Text == "  输入一个6~10位的账号")
                {
                    Account.Text = "";
                    Account.FontSize = 20;
                    Account.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                }
            }
            else
            {
                if (AccountName.Text == "  请输入真实姓名")
                {
                    AccountName.Text = "";
                    AccountName.FontSize = 20;
                    AccountName.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                }
            }
        }

        //鼠标移出事件
        private void AMouseLeave(object sender, MouseEventArgs e)
        {
            if (e.Source == Account)
            {
                if (Account.Text == "")
                {
                    Account.Text = "  输入一个6~10位的账号";
                    Account.FontSize = 16;
                    Account.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF868383"));
                }
            }
            else
            {
                if (AccountName.Text == "")
                {
                    AccountName.Text = "  请输入真实姓名";
                    AccountName.FontSize = 16;
                    AccountName.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF868383"));
                }
            }
        }
    }
}

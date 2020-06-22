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
using Client.LoginReference;

namespace Client
{
    /// <summary>
    /// PlayerInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PlayerInfo : Window
    {

        public PlayerInfo(LoginReference.User us)
        {
            InitializeComponent();
            this.account.Text = us.Acount;
            this.name.Text = us.Name;
            this.level.Text = us.Grade.ToString();
            this.sign.Text = us.Sign;
            if (us.Avart == null)
                us.Avart = "boy.png";
            this.photo.Source = new BitmapImage(new Uri("pack://application:,,,/image/"+us.Avart));
        }

    }
}

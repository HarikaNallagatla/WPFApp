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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for WiFiAccessCode.xaml
    /// </summary>
    public partial class WiFiAccessCode : Window
    {
        public WiFiAccessCode()
        {
            InitializeComponent();
            string randomnumber = string.Empty;
            Random random = new Random();
            randomnumber = (random.Next(100000, 999999)).ToString();
            txtWifiCode.Visibility = Visibility.Visible;
            txtWifiCode.Text = txtWifiCode.Text+"\n" + randomnumber;
        }
    }
}

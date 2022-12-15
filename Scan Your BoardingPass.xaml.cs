using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Scan_Your_BoardingPass.xaml
    /// </summary>
    public partial class Scan_Your_BoardingPass : Window
    {
        private Timer tmr;
        List<BitmapImage> lstbitmapImages = new List<BitmapImage>();
        static int imgcount = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public Scan_Your_BoardingPass()
        {
            InitializeComponent();
            imgdisplay.Source = new BitmapImage(new Uri(@"/Images/BoardingPass.jpg", UriKind.Relative));
           // imgdisplay.Source = new BitmapImage(new Uri(@"/Images/PassportScan.jpg", UriKind.Relative));
            string currentAssemblyPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));
            // string currentAssemblyParentPath = System.IO.Path.GetDirectoryName(currentAssemblyPath);
            List<string> lstimages = Directory.EnumerateFiles(System.IO.Path.Combine(currentAssemblyPath, System.IO.Path.Combine("Images", "Carousel Images")), "*").ToList();


            foreach (var img in lstimages)
            {
                lstbitmapImages.Add(new BitmapImage(new Uri(img)));
            }

        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtsuccessmsg.Visibility = Visibility.Hidden;
                btnClickMe.Visibility = Visibility.Hidden;
                txtscaninprogress.Visibility = Visibility.Visible;
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += timer_Tick;
                timer.Start();
                imgdisplay.Source = lstbitmapImages[imgcount];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
           
        }
        //private void tmr_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Application.Current.Dispatcher.Invoke(GetValue);
        //}
        //private void GetValue()
        //{
        //    if (tmr.Interval == 0.5 * 1000)
        //    {
        //        txtscaninprogress.Visibility = Visibility.Visible;
        //        tmr.Interval = 5 * 1000;
               
        //    }
        //    else
        //    {
        //        txtscaninprogress.Visibility = Visibility.Hidden;
        //        // tmr.Interval = 3 * 1000;
        //        txtsuccessmsg.Visibility = Visibility.Visible;
        //        btnNext.IsHitTestVisible = true;

        //        // btnhide_Click;
        //    }
        //}

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            WiFiAccessCode wiFiAccessCode = new WiFiAccessCode();
            wiFiAccessCode.Show();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (imgcount == lstbitmapImages.Count - 1)
            {
                imgcount = 0;
                timer.Stop();
                txtsuccessmsg.Visibility = Visibility.Visible;
                btnNext.IsHitTestVisible = true;
                txtscaninprogress.Visibility = Visibility.Hidden;
            }
            else
            {
                imgcount++;
                imgdisplay.Source = lstbitmapImages[imgcount];
            }

        }
    }
}

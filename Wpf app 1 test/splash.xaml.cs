using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf_app_1_test
{
    /// <summary>
    /// Interaction logic for splash.xaml
    /// </summary>
    public partial class splash : Window
    {
     
        public splash()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
       
        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            if (progress.Value < 100)
            {
                progress.Value += 16;
            }
            else
            {
                timer.Stop();
                Form3 f3 = new Form3();
                this.Hide();
                f3.ShowDialog();
            }

            // timer.Stop();
            // MainWindow m = new MainWindow();
            // this.Hide();
            // m.ShowDialog();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
           
            
            
        }
    }
}

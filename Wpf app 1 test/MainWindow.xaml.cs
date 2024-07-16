using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using DAL;

namespace Wpf_app_1_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string playernam;
        void openwnform(Form f)
        {
            Window g = this.FindName("Main") as Window;
            BlurBitmapEffect blurBitmapEffect = new BlurBitmapEffect();
            blurBitmapEffect.Radius = 20;
            g.BitmapEffect = blurBitmapEffect;
            f.ShowDialog();
            blurBitmapEffect.Radius = 0;
            g.BitmapEffect = blurBitmapEffect;
        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            addPlayer f = new addPlayer();
            openwnform(f);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window g = this.FindName("Main") as Window;
            BlurBitmapEffect blurBitmapEffect = new BlurBitmapEffect();
            blurBitmapEffect.Radius = 22;
            g.BitmapEffect = blurBitmapEffect;
            messagebox m = new messagebox();
           DialogResult dr= m.showMyDialog("وضعیت ماندن در برنامه","ایا قصد خروج از برنامه را دارید؟","q");
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Current.Shutdown();
            }
            blurBitmapEffect.Radius = 0;
            g.BitmapEffect = blurBitmapEffect;
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Form3 f = new Form3();
            openwnform(f);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            db db = new db();
            numberr.Content = db.players.Count();
            // labeluser.Content = 
            sms.Content = db.sms.Count();
            manage.Content = db.managers.Count();
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            addPlayer f = new addPlayer();
            openwnform(f);
        }

        private void Label_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            addManager m = new addManager();
            openwnform(m);
        }

        private void Label_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            choosebartar c1 = new choosebartar();
            openwnform(c1);
        }

        private void Label_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            choose1s c = new choose1s();
            openwnform(c);
        }

        private void Label_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            smscn s = new smscn();
            openwnform(s);
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void clockMain_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

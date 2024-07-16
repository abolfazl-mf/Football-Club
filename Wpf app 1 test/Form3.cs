using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using DAL;

namespace Wpf_app_1_test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            db db = new db();
            if (db.logins.Count() == 0)
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BLL.Blogin bl = new BLL.Blogin();
            if (txt1.Text.Trim().Length == 0)
            {
                label3.Text = "لطفا نام کاربری را وارد کنید";
            }
            else if (txt2.Text.Trim().Length == 0)
            {
                label3.Text = "لطفا رمز عبور را وارد کنید";
            }

            else if (bl.login(txt1.Text, txt2.Text) != 1)
            {
                label3.Text = "نام کاربری و یا کلمه عبور اشتباه است";
            }
            else
            {
            messagebox m1 = new messagebox();
            m1.showMyDialog("ورود موفق", "خوش امدید. برای ورود بر روی بله کلیک کنید", "s");
            MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Hide();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            messagebox m1 = new messagebox();
            DialogResult dr = m1.showMyDialog("وضعیت ماندن در برنامه", "ایا قصد خروج از برنامه را دارید؟", "q");
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            register r = new register();
            r.ShowDialog();
            Form3 f = new Form3();
            f.Hide();
        }
    }
}

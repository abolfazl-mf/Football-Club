using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using FoxLearn;
using FoxLearn.License;

namespace Wpf_app_1_test
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        messagebox m = new messagebox();
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            BLL.Blogin bl = new BLL.Blogin();
            if (textBoxX3.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا نام و نام خانوادگی را وارد کنید", "e");
            }
            else if (textBoxX4.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا نام کاربری را وارد کنید", "e");
            }
            else if (textBoxX5.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا رمز عبور را وارد کنید", "e");
            }
            else if (textBoxX6.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا تکرار رمز عبور را وارد کنید", "e");
            }
            else if (textBoxX5.Text != textBoxX6.Text)
            {
               
                m.showMyDialog("خطا", "رمز عبور و تکرار رمز همسان نیستند", "e");
            }

            else
            {
                bl.Register(new BE.login() { name = textBoxX3.Text, username = textBoxX4.Text, password = textBoxX5.Text });
                m.showMyDialog("عملیات موفق", "اطلاعات ادمین ایجاد شد", "s");
                Form3 f1 = new Form3();
                f1.Show();
                 ((Form3)Application.OpenForms["Form3"]).label5.Visible = false;
                this.Close();

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            KeyManager km = new KeyManager(textBoxX1.Text);
            string productKey = textBoxX2.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }

                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    messagebox m = new messagebox();
                    m.showMyDialog("عملیات موفق", "فعال سازی برنامه با موفقیت انجام شد", "s");
                    groupBox1.Enabled = true;
                }
            }
            else
                m.showMyDialog("خطا", "کد لایسنس نامعتبر است", "e");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = ComputerInfo.GetComputerId();
        }
    }
}

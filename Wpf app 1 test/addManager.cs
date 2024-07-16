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
    public partial class addManager : Form
    {
        public addManager()
        {
            InitializeComponent();
        }
        public void clearall()
        {

            foreach (var item in Controls)
            {
                if (item is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    (item as DevComponents.DotNetBar.Controls.TextBoxX).Clear();
                }
            }


        }
        bool flag = true;
        int id;
        messagebox m = new messagebox();
        manager p = new manager();
        blmanager bl = new blmanager();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا نام مربی را وارد کنید", "e");
                textBoxX1.Select();
            }
            else if (textBoxX2.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا شماره تماس را وارد کنید", "e");
                textBoxX2.Select();
            }
            else if (textBoxX3.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا سن مربی را وارد کنید", "e");
                textBoxX3.Select();
            }
            else if (textBoxX2.Text.Length != 11)
            {
                m.showMyDialog("خطا", "تعداد ارقام شماره تماس باید 11 رقمی باشد", "e");
                textBoxX2.Select();
            }
            else
            {
                if (flag == true)
                {
                    p.manageName = textBoxX1.Text;
                    p.age = Convert.ToInt16(textBoxX3.Text);
                    p.homManyYears = Convert.ToInt16(comboBoxEx1.Text);
                    p.managePhonn = textBoxX2.Text;
                    m.showMyDialog("پیغام", bl.register(p), "s");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bl.readall();
                    textBoxX1.Clear();
                    textBoxX2.Clear();
                    textBoxX3.Clear();
                    textBoxX1.Focus();
                }
                else
                {
                    p.manageName = textBoxX1.Text;
                    p.age = Convert.ToInt16(textBoxX3.Text);
                    p.homManyYears = Convert.ToInt16(comboBoxEx1.Text);
                    p.managePhonn = textBoxX2.Text;
                    m.showMyDialog("پیغام", bl.update(id,p), "s");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bl.readall();
                    label6.Text = "ثبت اطلاعات";
                    flag = true;
                    textBoxX1.Clear();
                    textBoxX2.Clear();
                    textBoxX3.Clear();
                    textBoxX1.Focus();
                }
            }
        }

        private void addManager_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'footballDataSet4.managers' table. You can move, or remove it, as needed.
            this.managersTableAdapter.Fill(this.footballDataSet4.managers);
           // comboBoxEx1.Text = "5";
            db db = new db();
            int b = db.managers.Count();
            label8.Text = "تعداد مربیان تا این لحظه " + ' ' + b.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.readall();
        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.search(textBoxX8.Text);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {

                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.Focus();

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
                catch (Exception)
                {

                }
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.showMyDialog("سوال", "میخواهید این ستون را ویرایش کنید؟", "qfead") == DialogResult.Yes)
            {
                flag = false;
                manager cr = new manager();
                BLL.blmanager bl = new BLL.blmanager();
                cr = bl.searchbyid(id);
                textBoxX1.Text = cr.manageName;
                textBoxX2.Text = cr.managePhonn;
                textBoxX3.Text = cr.age.ToString();
                comboBoxEx1.Text = cr.homManyYears.ToString();
                label6.Text = "ویرایش اطلاعات";
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.showMyDialog("سوال", "میخواهید این ستون را حذف کنید؟", "qfead") == DialogResult.Yes)
            {
                BLL.blmanager bl = new BLL.blmanager();
                bl.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.readall();
                m.showMyDialog("سوال", "حذف اطلاعات با موفقیت انجام شد", "s");
                clearall();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Close();
        }
    }
}

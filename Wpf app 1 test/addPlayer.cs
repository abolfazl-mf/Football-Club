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
using DAL;

namespace Wpf_app_1_test
{
    public partial class addPlayer : Form
    {
        public addPlayer()
        {
            InitializeComponent();
        }
        bool flag = true;
        int id;
            BLL.blplayer bl = new BLL.blplayer();
            player p = new player();
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
        messagebox m = new messagebox();

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'footballDataSet.players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.footballDataSet.players);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.readall();
            db db = new db();
            int b = db.players.Count();
            label8.Text = "تعداد بازیکنان لیگ یکی تا این لحظه " + ' ' + b.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          //  db db = new db();
          //  testwpf t = new testwpf();
          ////  t.num = numericUpDown1.Text;
          //  db.testwpfs.Add(t);
          //  db.SaveChanges();
          //  messagebox m = new messagebox();
          //  m.showMyDialog("عمیلیات موفق", ".اطلاعات با موفقیت و بدون مشکلی ثبت گردید", "s");
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text,textBox2.Text);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //int a, b;
            //a = Int32.Parse(textBox1.Text);
            //b = Int32.Parse(textBox2.Text);
            //label1.Text = (a + b).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int a, b;
            //a = Int32.Parse(textBox1.Text);
            //b = Int32.Parse(textBox2.Text);
            //label1.Text = (a * b).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            //int a, b;
            //a = Int32.Parse(textBox1.Text);
            //b = Int32.Parse(textBox2.Text);
            //label1.Text = (a - b).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int a, b;
            //a = Int32.Parse(textBox1.Text);
            //b = Int32.Parse(textBox2.Text);
            //label1.Text = (a / b).ToString();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا نام بازیکن را وارد کنید", "e");
                textBoxX1.Select();
            }
            else if (textBoxX2.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا شماره تماس را وارد کنید", "e");
                textBoxX2.Select();
            }
            else if (textBoxX3.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا سن بازیکن را وارد کنید", "e");
                textBoxX3.Select();
            }
            else if (textBoxX4.Text.Trim().Length == 0)
            {
                m.showMyDialog("خطا", "لطفا نام پدر را وارد کنید", "e");
                textBoxX4.Select();
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
                    p.playerName = textBoxX1.Text;
                    p.phoneNumber = textBoxX2.Text;
                    p.age = Convert.ToInt16(textBoxX3.Text);
                    p.fatherName = textBoxX4.Text;
                    m.showMyDialog("پیغام", bl.register(p), "s");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bl.readall();
                    textBoxX1.Clear();
                    textBoxX2.Clear();
                    textBoxX3.Clear();
                    textBoxX4.Clear();
                    textBoxX1.Focus();
                }
                else
                {
                    p.playerName = textBoxX1.Text;
                    p.phoneNumber = textBoxX2.Text;
                    p.age = Convert.ToInt16(textBoxX3.Text);
                    p.fatherName = textBoxX4.Text;
                    m.showMyDialog("پیفام", bl.update(id,p), "s");
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = bl.readall();
                    label6.Text = "ثبت اطلاعات";
                    flag = true;
                    textBoxX1.Clear();
                    textBoxX2.Clear();
                    textBoxX3.Clear();
                    textBoxX4.Clear();
                    textBoxX1.Focus();
                }
            }

           
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBoxX8.Text.Trim().Length == 0)
            {

            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.search(textBoxX8.Text);
            }
        }

        private void gunaContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.showMyDialog("سوال", "میخواهید این ستون را ویرایش کنید؟", "qfead") == DialogResult.Yes)
            {
                flag = false;
                player cr = new player();
                BLL.blplayer bl = new BLL.blplayer();
                cr = bl.searchbyid(id);
                textBoxX1.Text = cr.playerName;
                textBoxX2.Text = cr.phoneNumber;
                textBoxX3.Text = cr.age.ToString();
                textBoxX4.Text = cr.fatherName;
                label6.Text = "ویرایش اطلاعات";
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.showMyDialog("سوال","میخواهید این ستون را حذف کنید؟","qfead") == DialogResult.Yes)
            {
                BLL.blplayer bl = new BLL.blplayer();
                bl.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.readall();
                m.showMyDialog("سوال","حذف اطلاعات با موفقیت انجام شد","s");
                clearall();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                gunaContextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
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

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBoxX8_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.search(textBoxX8.Text);
        }
    }
}

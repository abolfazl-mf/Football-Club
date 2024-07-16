using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Data.SqlClient;
using System.IO;
using BE;
using System.Windows;

namespace Wpf_app_1_test
{
    public partial class choose1s : Form
    {
        public choose1s()
        {
            InitializeComponent();
        }
        blplayer blplayer = new blplayer();
        player p = new player();

        int id;
            choose1 c = new choose1();
            blchoose1 bl = new blchoose1();
        
        messagebox m = new messagebox();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            string text = "";
            
            foreach (var item in listBox1.SelectedItems)
            {
                
                text = item.ToString(); // /n to print each item on new line or you omit /n to print text on same line
            
            }
            c.name = text;
           
            
            m.showMyDialog("", bl.register(c), "s");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.readall();


            //List<string> data = new List<string>(checkedListBox1.CheckedItems.Cast<string>());
            //data = data.Distinct().ToList<string>();
            //listBox1.Items.Clear();
            //listBox1.Items.AddRange(data.ToArray());


            //foreach (string s in checkedListBox1.CheckedItems)
            //{
            //    string b = listBox1.FindString(s).ToString();
            //    listBox1.Items.Add(s);

            //}
            //while (listBox1.SelectedItems.Count > 0)
            //{
            //    listBox1.Items.Remove(listBox1.SelectedItems[0]);
            //}
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Close();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // int selected = checkedListBox1.SelectedIndex;
            // if (selected != -1)
            // {
            //     listBox1.Items.Add(checkedListBox1.Items[selected].ToString());

            //}


           
        }

        

       

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void choose1_Load(object sender, EventArgs e)
        {
          
           
            //AutoCompleteStringCollection name =new AutoCompleteStringCollection();
            //foreach(var item in blplayer.search(textBoxX1.Text))
            //{
            //    name.Add(item.ToString());
            //}
            //textBoxX1.AutoCompleteCustomSource = name;

              // TODO: This line of code loads data into the 'footballDataSet2.choose1' table. You can move, or remove it, as needed.
            this.choose1TableAdapter.Fill(this.footballDataSet2.choose1);
            db db = new db();
            int b = db.choose1.Count();
            label8.Text = "تعداد بازیکنان لیگ یکی تا این لحظه " + ' ' + b.ToString();
            //label9.Text = b.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.readall();

            

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=football;Integrated Security=True");
            string query = "SELECT (playerName + '  ' + phoneNumber) as playerphone FROM [players] ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
            if (db.players.Count() == 0)
            {
            checkedListBox2.Items.Add("بازیکنی وجود ندارد");
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                  checkedListBox2.Items.Add(dt.Rows[i]["playerphone"]);
                }
            }
        }

        private void checkedListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<string> data = new List<string>(checkedListBox2.CheckedItems.Cast<string>());
            data = data.Distinct().ToList<string>();
            listBox1.Items.Clear();
            db db = new db();
            if (db.players.Count() != 0)
            {
            listBox1.Items.AddRange(data.ToArray());
            }
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void حدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m.showMyDialog("سوال", "میخواهید این ستون را حذف کنید؟", "qfead") == DialogResult.Yes)
            {
                BLL.blchoose1 bl = new BLL.blchoose1();
                bl.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.readall();
                m.showMyDialog("فملیات موفق", "حذف اطلاعات با موفقیت انجام شد", "s");
                

            }
        }
    }
}

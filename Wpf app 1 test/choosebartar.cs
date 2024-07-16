using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class choosebartar : Form
    {
        public choosebartar()
        {
            InitializeComponent();
        }
        int id;
        bartar c = new bartar();
        messagebox m = new messagebox();
        blbartar bl = new blbartar();
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
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Close();
        }

        private void choosebartar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'footballDataSet3.bartars' table. You can move, or remove it, as needed.
            this.bartarsTableAdapter.Fill(this.footballDataSet3.bartars);
            // TODO: This line of code loads data into the 'footballDataSet2.choose1' table. You can move, or remove it, as needed.
            // this.choose1TableAdapter.Fill(this.footballDataSet2.choose1);
            db db = new db();
            int b = db.bartars.Count();
            label8.Text = "تعداد بازیکنان لیگ برتری تا این لحظه " + ' ' + b.ToString();
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

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void حدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            


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

        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dataGridView1_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
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

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (m.showMyDialog("سوال", "میخواهید این ستون را حذف کنید؟", "qfead") == DialogResult.Yes)
            {
                BLL.blbartar bl = new BLL.blbartar();
                bl.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bl.readall();
                m.showMyDialog("عملیات موفق", "حذف اطلاعات با موفقیت انجام شد", "s");


            }
        }
    }
}

using SmsIrRestful;
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
    public partial class smscn : Form
    {
        public smscn()
        {
            InitializeComponent();
        }
        sms s = new sms();
        BLL.blsms bl = new BLL.blsms();
        List<string>
            numbers = new List<string>();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Close();  
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var token = new Token().GetToken("9ccc4acc96772b9547c57519", "FootballSms");

            var messageSendObject = new MessageSendObject()
            {
                Messages = new List<string>
                    { richTextBoxEx1.Text }.ToArray(),
                MobileNumbers = new List<string>
                    { textBoxX1.Text }.ToArray(),
                LineNumber = "30002645824631",
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };

            MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject.IsSuccessful)
            {
                messagebox m = new messagebox();
                s.name = richTextBoxEx2.Text;
                m.showMyDialog("عملیات موفق", bl.register(s), "s");
            }
            else
            {
                messagebox m = new messagebox();
                m.showMyDialog("عملیات ناموفق",messageSendResponseObject.Message, "e");
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            numbers.Add(textBoxX2.Text);
            listBox1.DataSource = null;
            listBox1.DataSource = numbers;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var token = new Token().GetToken("9ccc4acc96772b9547c57519", "FootballSms");

            var messageSendObject = new MessageSendObject()
            {
                Messages = new List<string>{ richTextBoxEx2.Text }.ToArray(),
                MobileNumbers =numbers.ToArray(),
                LineNumber = "30002645824631",
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };
            MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject.IsSuccessful)
            {
                messagebox m = new messagebox();
                s.name = richTextBoxEx2.Text;
                m.showMyDialog("عملیات موفق",bl.register(s), "s");
            }
            else
            {
                messagebox m = new messagebox();
                m.showMyDialog("عملیات ناموفق", messageSendResponseObject.Message, "e");
            }
        }

        private void sms_Load(object sender, EventArgs e)
        {
           // textBox1.Text = dataGridView1["clname", dataGridView1.CurrentRow.Index].Value.ToString();
            
           // listBox1.Items.Add(dataGridView1.Rows(1).Cells(1))
            // TODO: This line of code loads data into the 'footballDataSet1.players' table. You can move, or remove it, as needed.
            BLL.blplayer bl = new BLL.blplayer();
            this.playersTableAdapter.Fill(this.footballDataSet1.players);
            db db = new db();
            int b = db.sms.Count();
            label8.Text = "تعداد پیامک های ارسالی تا این لحظه " + ' ' + b.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.readall();

        }

        private void textBoxX2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxX2_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)

            {
               // listBox1.Items.Add(dataGridView1["playerNameDataGridViewTextBoxColumn",].Value.ToString());
                if (numbers.Contains(textBoxX2.Text))
                {
                    messagebox m = new messagebox();
                    m.showMyDialog("خطا", "این شماره را قبلا در لیست وارد کرده اید", "e");

                }
                else if(textBoxX2.TextLength != 11)
                {
                    messagebox m = new messagebox();
                    m.showMyDialog("خطا","شماره همراه باید 11 رقمی باشد","e");
                }
                else
                {
                    numbers.Add(textBoxX2.Text);
                    listBox1.DataSource = null;
                    listBox1.DataSource = numbers;
                    textBoxX2.Clear();
                }
                

            }
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            BLL.blplayer bl = new BLL.blplayer();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bl.search(textBoxX3.Text);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
          
           // textBoxX2.Text = dataGridView1["phoneNumber", dataGridView1.CurrentRow.Index].Value.ToString();
           // txtTel.Text = dataGridView1["tel", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void smscn_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void smscn_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(numbers.Contains(dataGridView1.CurrentRow.Cells[2].Value))
            {
                messagebox m = new messagebox();
                m.showMyDialog("خطا", "این شماره را قبلا در لیست وارد کرده اید", "e");
                // listBox1.Items.Add(dataGridView1.CurrentRow.Cells[2].Value.ToString());

            }
            else
            {
                numbers.Add(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                listBox1.DataSource = null;
                listBox1.DataSource = numbers;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var token = new Token().GetToken("9ccc4acc96772b9547c57519", "FootballSms");

            var messageSendObject = new MessageSendObject()
            {
                Messages = new List<string>
                    { richTextBoxEx1.Text }.ToArray(),
                MobileNumbers = new List<string>
                    { textBoxX1.Text }.ToArray(),
                LineNumber = "30002645824631",
                SendDateTime = null,
                CanContinueInCaseOfError = true
            };

            MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(token, messageSendObject);

            if (messageSendResponseObject.IsSuccessful)
            {
                messagebox m = new messagebox();
                s.name = richTextBoxEx2.Text;
                m.showMyDialog("عملیات موفق", bl.register(s), "s");
            }
            else
            {
                messagebox m = new messagebox();
                m.showMyDialog("عملیات ناموفق", messageSendResponseObject.Message, "e");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wpf_app_1_test
{
    public partial class messageboxform : Form
    {
        public messageboxform()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2Button1.Text == "خیر برگرد")
            {
                this.DialogResult = DialogResult.No;
            }
            else 
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

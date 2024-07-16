using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wpf_app_1_test
{
  public class messagebox
    {
        public System.Drawing.Point Location { get; set; }
        public DialogResult showMyDialog(string title, string dec, string type)
        {

            messageboxform m = new messageboxform();
            m.label1.Text = title;
            m.label2.Text = dec;
           



            if (type == "e")
            {
                m.guna2Button1.Location = new System.Drawing.Point(247, 188);
                m.guna2Button2.Visible = false;
                m.guna2Button1.Text = "باشه";
            }
            else if (type == "q")
            {
                m.guna2Button1.Text = "خیر برگرد";
            }
            else if (type == "qfead")//question for edit and delete = qfead
            {
                m.guna2Button2.Text = "بله";
            }
            else
            {
                m.guna2Button1.Text = "بله";
                m.guna2Button1.Location=new System.Drawing.Point(247, 188);
                m.guna2Button2.Visible = false;
            }
            m.ShowDialog();
            return m.DialogResult;
        }
    }
}

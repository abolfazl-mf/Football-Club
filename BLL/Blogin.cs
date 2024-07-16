using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Blogin
    {
        dlogin dl = new dlogin();
        public byte login(string pusername, string ppassword)
        {
            return dl.login(pusername, ppassword);
        }
        public void Register(login ul)
        {
            dl.Register(ul);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class dlogin
    {
        db db = new db();
        public byte login(string pusername, string ppassword)
        {
            if (db.logins.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.logins.Any(i => i.username == pusername && i.password == ppassword))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        public void Register(login ul)
        {
            db.logins.Add(ul);
            db.SaveChanges();
        }
    }
}

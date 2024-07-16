using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
  public  class dlsms
    {
        db db1 = new db();
        public string register(sms p)
        {
                    db1.sms.Add(p);
                    db1.SaveChanges();
                    return "ارسال پیامک با موفقیت انجام شد";
        }
    }
}

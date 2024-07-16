using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
   public class blsms
    {
        DAL.dlsms dl = new DAL.dlsms();
        public string register(sms p)
        {
            
            return dl.register(p);
        }
    }
}

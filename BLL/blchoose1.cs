using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class blchoose1
    {
        dlchoose1 dl = new dlchoose1();
        public string register(choose1 p)
        {
            return dl.register(p);
        }

        public bool exist(choose1 p)
        {
            return dl.exist(p);
        }

        public List<choose1> readall()
        {
            return dl.readall();
        }
        public string delete(int id)
        {
            return dl.delete(id);
        }
    }
}

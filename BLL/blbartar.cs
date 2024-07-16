using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
   public class blbartar
    {
        DAL.dlbartar dl = new DAL.dlbartar();
        public string register(bartar p)
        {
            return dl.register(p);
        }

        public bool exist(bartar p)
        {
            return dl.exist(p);
        }

        public List<bartar> readall()
        {
            return dl.readall();
        }
        public string delete(int id)
        {
            return dl.delete(id);
        }
    }
}

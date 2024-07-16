
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class blplayer
    {
        dlplayer dl = new dlplayer();
        public string register(player p)
        {
            return dl.register(p);
        }
       
        public bool exist(player p)
        {
            return dl.exist(p);
        }

        public List<player> search(string pphone_number)
        {
            return dl.search(pphone_number);
        }
      

        public player searchbyid(int id)
        {
            return dl.searchbyid(id);
        }
        public List<player> readall()
        {
            return dl.readall();
        }
        public string update(int id, player p)
        {
            return dl.update(id, p);
        }
        public string delete(int id)
        {
            return dl.delete(id);
        }
        
    }
}

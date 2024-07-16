using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class blmanager
    {
            dlmanager dl = new dlmanager();
            public string register(manager p)
            {
                return dl.register(p);
            }

            public bool exist(manager p)
            {
                return dl.exist(p);
            }

            public List<manager> search(string pphone_number)
            {
                return dl.search(pphone_number);
            }


            public manager searchbyid(int id)
            {
                return dl.searchbyid(id);
            }
            public List<manager> readall()
            {
                return dl.readall();
            }
            public string update(int id, manager p)
            {
                return dl.update(id, p);
            }
            public string delete(int id)
            {
                return dl.delete(id);
            }
           
        }
    }


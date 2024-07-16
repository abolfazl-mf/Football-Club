using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class dlbartar
    {
        db db1 = new db();
        
        public string register(bartar p)
        {
            if (!exist(p))
            {
                db1.bartars.Add(p);
                db1.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد";
            }
            else
            {
                return "اطلاعات وارد شده تکراری است";

            }
        }

        public bool exist(bartar p)
        {
            var q = db1.bartars.Where(i => i.name == p.name);
            {
                if (q.Count() == 1)


                {
                    return true;


                }
                return false;
            }
        }

        public List<bartar> readall()
        {
            return db1.bartars.ToList();
        }

        public string delete(int id)
        {
            var q = db1.bartars.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                bartar cr = new bartar();
                db1.bartars.Remove(q.Single());
                db1.SaveChanges();
                return "حذف اطلاعات با موفقیت انجام شد";
            }
            return "حذف اطلاعات با موفقیت انجام شد.";
        }
    }
}


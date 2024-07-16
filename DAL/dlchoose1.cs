
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
   public class dlchoose1
    {
        db db1 = new db();
        public string register(choose1 p)
        {
            if (!exist(p))
            {
                    db1.choose1.Add(p);
                    db1.SaveChanges();
                     return "ثبت اطلاعات با موفقیت انجام شد";
            }
            else
            {
            return "اطلاعات وارد شده تکراری است";

            }
        }

        public bool exist(choose1 p)
        {
            var q = db1.choose1.Where(i => i.name == p.name);
            {
                if (q.Count() == 1)


                {
                    return true;


                }
                return false;
            }
        }

        public List<choose1> readall()
        {
            return db1.choose1.ToList();
        }

        public string delete(int id)
        {
            var q = db1.choose1.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                choose1 cr = new choose1();
                db1.choose1.Remove(q.Single());
                db1.SaveChanges();
                return "حذف اطلاعات با موفقیت انجام شد";
            }
            return "حذف اطلاعات با موفقیت انجام شد.";
        }
    }
}

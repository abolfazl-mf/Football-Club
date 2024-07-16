using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class dlplayer
    {
        db db1 = new db();
        public string register(player p)
        {
            if (!exist(p))
            {
                if (p.age >= 18)
                {
                    db1.players.Add(p);
                    db1.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "سن وارد شده کمتر از 18 سال است";
                }
            }
            return "اطلاعات وارد شده تکراری است";
        }

        public bool exist(player p)
        {
            var q = db1.players.Where(i => i.phoneNumber == p.phoneNumber);
            {
                if (q.Count() == 1)


                {
                    return true;


                }
                return false;
            }
        }

        public List<player> readall()
        {
            return db1.players.ToList();
        }
        public List<player> search(string pphone_number)
        {
            return (from i in db1.players where i.phoneNumber.Contains(pphone_number) || i.playerName.Contains(pphone_number) select i).ToList();
        }
        public player searchbyid(int id)
        {
            return db1.players.Where(i => i.id == id).Single();
        }
        public string update(int id, player p)
        {

                if (p.age>=18)
                {
                    var q = db1.players.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.playerName = p.playerName;
                        q.phoneNumber = p.phoneNumber;
                        q.age = p.age;
                        q.fatherName = p.fatherName;
                        db1.SaveChanges();
                        return "ویرایش اطلاعات با موفقیت انجام شد";

                    }
                }
                return "سن وارد شده کمتر از 18 سال است";
      
                 
        }
        //public bool EditExist(player cr, int id)
        //{
        //    player cr1 = new player();
        //    var q = db1.players.Where(i => i.id == id);
        //    cr1 = q.Single();
        //    if (cr1.id != cr.id)
        //    {
        //        var q2 = db1.players.Where(i => i.id == cr.id);
        //        if (q2.Count() == 1)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (db1.players.Where(x => x.id == cr.id).Count() > 1)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public string delete(int id)
        {
            var q = db1.players.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                player cr = new player();
                db1.players.Remove(q.Single());
                db1.SaveChanges();
                return "حذف اطلاعات با موفقیت انجام شد";
            }
            return "حذف اطلاعات با موفقیت انجام شد.";
        }
    }
}

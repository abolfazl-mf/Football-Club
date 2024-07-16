using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class dlmanager
    {
        db db1 = new db();
        public string register(manager p)
        {
            if (!exist(p))
            {

                if (p.homManyYears < 5)
                {
                    return "سابقه مربگیری کمتر از 5 سال است";
                }
                else if (p.age<20) 
                {
                    return "سن وارد شده کمتر از 20 سال است";
                }
                else
                {
                    db1.managers.Add(p);
                    db1.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
            }
            return "اطلاعات وارد شده تکراری است";
        }

        public bool exist(manager p)
        {
            var q = db1.managers.Where(i => i.managePhonn == p.managePhonn);
            {
                if (q.Count() == 1)


                {
                    return true;


                }
                return false;
            }
        }

        public List<manager> readall()
        {
            return db1.managers.ToList();
        }
        public List<manager> search(string pphone_number)
        {
            return (from i in db1.managers where i.managePhonn == pphone_number || i.manageName.Contains(pphone_number) select i).ToList();
        }


        public manager searchbyid(int id)
        {
            return db1.managers.Where(i => i.id == id).Single();
        }  
        public string update(int id, manager p)
        {
            if (p.age>20)
            {
                if (p.homManyYears > 5)
                {
                    var q = db1.managers.Where(i => i.id == id).FirstOrDefault();
                    if (q != null)
                    {
                        q.manageName = p.manageName;
                        q.managePhonn = p.managePhonn;
                        q.age = p.age;
                        q.homManyYears = p.homManyYears;
                        db1.SaveChanges();
                        return "ویرایش اطلاعات با موفقیت انجام شد";
                    }
                    

                   
                }
                
                else
                {
                    return "سابقه مربگیری کمتر از 5 سال است";

                }

            }
            return "سن وارد شده کمتر از 20 سال است";
        }
        public string delete(int id)
        {
            var q = db1.managers.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                manager cr = new manager();
                db1.managers.Remove(q.Single());
                db1.SaveChanges();
                return "حذف اطلاعات با موفقیت انجام شد";
            }
            return "حذف اطلاعات با موفقیت انجام شد.";
        }
        //public bool EditExist(manager cr, int id)
        //{
        //    manager cr1 = new manager();
        //    var q = db1.managers.Where(i => i.id == id);
        //    cr1 = q.Single();
        //    if (cr1.managePhonn != cr.managePhonn)
        //    {
        //        var q2 = db1.managers.Where(i => i.managePhonn == cr.managePhonn);
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
        //        if (db1.managers.Where(x => x.managePhonn == cr.managePhonn).Count() > 1)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}

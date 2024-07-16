using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
        public class db : DbContext
        {
            public db() : base("b") { }
            public DbSet<login> logins { get; set; }
            public DbSet<player> players { get; set; }
            public DbSet<choose1> choose1 { get; set; }
            public DbSet<sms> sms { get; set; }
            public DbSet<bartar> bartars { get; set; }
            public DbSet<manager> managers { get; set; }
        }
    
}

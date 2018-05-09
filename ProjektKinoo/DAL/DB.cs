using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjektKinoo.Models;

namespace ProjektKinoo.DAL
{
    public class DB : DbContext
    {
        public DB():base("mydb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DB>());
        }
        public DbSet<Uzytkownicy> UserDB { get; set; }
        public DbSet<Filmy> FilmDB { get; set; }
    }
}
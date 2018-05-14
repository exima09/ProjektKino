using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKinoo.Models;
using ProjektKinoo.DAL;
using System.Data.Entity.Migrations;

namespace ProjektKinoo.BusinessLayer
{
    public class UzytkownicyBL
    {
        public List<Uzytkownicy> GetUsers()
        {
            DB mDB = new DB();
            return mDB.UserDB.ToList();
        }

        public void AddUser(Uzytkownicy u)
        {
            DB mDB = new DB();
            mDB.UserDB.Add(u);
            mDB.SaveChanges();
        }

        public Uzytkownicy GetSingleUser(int id)
        {
            DB mDB = new DB();
            Uzytkownicy user = mDB.UserDB.Single(model => model.UserId == id);
            return user;
        }
        public Uzytkownicy GetUserEmail(string em)
        {
            DB mDB = new DB();
            Uzytkownicy user = mDB.UserDB.Single(model => model.Email == em);
            return user;
        }
        public void EditUser(Uzytkownicy u)
        {
            DB mDB = new DB();
            mDB.UserDB.AddOrUpdate(u);
            mDB.SaveChanges();
        }
        public void Delete(int id)
        {
            DB mDB = new DB();
            Uzytkownicy u = mDB.UserDB.Single(model => model.UserId == id);
            mDB.UserDB.Remove(u);
            mDB.SaveChanges();
        }
        public int PobierzRole(string em)
        {
            Uzytkownicy User = GetUserEmail(em);
            if(User.Admin==1)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKinoo.Models;
using ProjektKinoo.DAL;
using System.Data.Entity.Migrations;

namespace ProjektKinoo.BusinessLayer
{
    public class FilmyBL
    {
        public List<Filmy> PobierzFilmy()
        {
            DB mDB = new DB();
            return mDB.FilmDB.ToList();
        }

        public void DodajFilm(Filmy u)
        {
            DB mDB = new DB();
            mDB.FilmDB.Add(u);
            mDB.SaveChanges();
        }

        public Filmy PobierzJedenFilms(int id)
        {
            DB mDB = new DB();
            Filmy film = mDB.FilmDB.Single(model => model.IdFilmu == id);
            return film;
        }
        public void EdytujFilm(Filmy u)
        {
            DB mDB = new DB();
            mDB.FilmDB.AddOrUpdate(u);
            mDB.SaveChanges();
        }
        public void Usun(int id)
        {
            DB mDB = new DB();
            Filmy u = mDB.FilmDB.Single(model => model.IdFilmu == id);
            mDB.FilmDB.Remove(u);
            mDB.SaveChanges();
        }
        public int SprawdzDostep(string em)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            if(UserBL.PobierzRole(em)==1)
            {
                return 1;
            }
            return 0;
        }
    }
}
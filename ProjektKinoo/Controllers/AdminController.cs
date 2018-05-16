using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.BusinessLayer;
using ProjektKinoo.ViewModels.User;
using ProjektKinoo.ViewModels.Admin;
using ProjektKinoo.Models;

namespace ProjektKinoo.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            return View();
        }
        [Authorize]
        public ActionResult EdytujUzytkownika(int id)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            EdytujUzytkownikaVM Edit = new EdytujUzytkownikaVM
            {
                User = UserBL.GetSingleUser(id)
            };
            return View(Edit);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EdytujUzytkownika(EdytujUzytkownikaVM vm)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            UserBL.EditUser(vm.User);
            return RedirectToAction("ListaUzytkownikow", "Admin", null);
        }
        [Authorize]
        public ActionResult ListaUzytkownikow()
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            ListaUzytkownikowVM vm = new ListaUzytkownikowVM
            {
                Lista = UserBL.GetUsers()
            };
            return View(vm);
        }
        [Authorize]
        public ActionResult Usun(int id)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            UserBL.Delete(id);
            return RedirectToAction("ListaUzytkownikow", "Admin");
        }
        [Authorize]
        public ActionResult WyswietlUzytkownika(int id)
        {
            UzytkownicyBL userBL = new UzytkownicyBL();
            Uzytkownicy user = userBL.GetSingleUser(id);
            WyswietlVM vm = new WyswietlVM
            {
                User = user
            };
            return View(vm);
        }
        [Authorize]
        public ActionResult ListaAdministratora()
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            NadajAdministratoraVM vm = new NadajAdministratoraVM
            {
                Lista = UserBL.GetUsers()
            };
            return View(vm);
        }
        [Authorize]
        public ActionResult NadajAdministratora(int id)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            Uzytkownicy User = UserBL.GetSingleUser(id);
            if (User.UserId != 1)
            {
                if (User.Admin == 0)
                {
                    User.Admin = 1;
                }
                else
                {
                    User.Admin = 0;
                }
                UserBL.EditUser(User);
            }
            return RedirectToAction("ListaAdministratora", "Admin", null);
        }
    }
}
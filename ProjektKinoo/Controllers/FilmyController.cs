using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.ViewModels.Filmy;
using ProjektKinoo.BusinessLayer;

namespace ProjektKinoo.Controllers
{
    public class FilmyController : Controller
    {
        // GET: Filmy
        [Authorize]
        public ActionResult ListaFilmow()
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            ListaFilmowVM ListaVM = new ListaFilmowVM
            {
                Lista = FilmyBL.PobierzFilmy()
            };
            return View(ListaVM);
        }

        [Authorize]
        public ActionResult DodajFilm()
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            DodajFilmVM DodajFilm = new DodajFilmVM();
            return View(DodajFilm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DodajFilm(DodajFilmVM vm)
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            if (ModelState.IsValid)
            {
                FilmyBL FilmBL = new FilmyBL();
                try
                {
                    FilmBL.DodajFilm(vm.Film);
                }
                catch
                {
                    ModelState.AddModelError("CredentialError", "Błąd podczas dodawania filmu do bazy!");
                    return View();
                }

            }
            else
                return View();
            return RedirectToAction("ListaFilmow", "Filmy", null);
        }
        [Authorize]
        public ActionResult UsunFilm(int id)
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            FilmyBL.Usun(id);
            return RedirectToAction("ListaFilmow", "Filmy", null);
        }
        [Authorize]
        public ActionResult EdytujFilm(int id)
        {
            FilmyBL FilmyBL = new FilmyBL();
            if (FilmyBL.SprawdzDostep((string)Session["Email"]) == 0) return RedirectToAction("BrakDostepu", "Home", null);
            EdytujFilmVM vm = new EdytujFilmVM
            {
                Film = FilmyBL.PobierzJedenFilms(id)
            };
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EdytujFilm(EdytujFilmVM vm)
        {
            FilmyBL FilmyBL = new FilmyBL();
            FilmyBL.EdytujFilm(vm.Film);
            return RedirectToAction("ListaFilmow", "Filmy", null);
        }
        public ActionResult Repertuar()
        {
            FilmyBL FilmyBL = new FilmyBL();
            RepertuarVM vm = new RepertuarVM
            {
                Lista = FilmyBL.PobierzFilmy()
            };
            return View(vm);
        }
    }
}
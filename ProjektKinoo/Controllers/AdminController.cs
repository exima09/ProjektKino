using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.BusinessLayer;

namespace ProjektKinoo.Controllers
{
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
    }
}
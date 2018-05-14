using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektKinoo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KinoDlaSzkoly()
        {
            return View();
        }

        public ActionResult KinoNaTemat()
        {
            return View();
        }
        public ActionResult NocnyMaraton()
        {
            return View();
        }
        public ActionResult Cennik()
        {
            return View();
        }
        public ActionResult BrakDostepu()
        {
            return View();
        }
    }
}
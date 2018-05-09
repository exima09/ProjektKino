using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.ViewModels.User;
using ProjektKinoo.BusinessLayer;

namespace ProjektKinoo.Controllers
{
    public class UzytkownicyController : Controller
    {
        // GET: Uzytkownicy
        public ActionResult EdytujUzytkownika()
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            EdytujUzytkownikaVM Edit = new EdytujUzytkownikaVM
            {
                User = UserBL.GetUserEmail((string)Session["Email"])
            };
            return View(Edit);
        }
        [HttpPost]
        public ActionResult EdytujUzytkownika(EdytujUzytkownikaVM vm)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            UserBL.EditUser(vm.User);
            return RedirectToAction("Index","Home",null);
        }
    }
}
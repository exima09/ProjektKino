using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.Models;
using ProjektKinoo.ViewModels.User;
using ProjektKinoo.BusinessLayer;
using SshNet.Security.Cryptography;

namespace ProjektKinoo.Controllers
{
    public class UzytkownicyController : Controller
    {
        // GET: Uzytkownicy
        [Authorize]
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
        [Authorize]
        public ActionResult ZmienHaslo()
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            ZmienHasloVM vm = new ZmienHasloVM
            {
                User = UserBL.GetUserEmail((string)Session["Email"])
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult ZmienHaslo(ZmienHasloVM vm)
        {
            UzytkownicyBL UserBL = new UzytkownicyBL();
            byte[] dataHistory = System.Text.Encoding.Default.GetBytes(vm.User.PasswordHash);
            SHA512 shaMH = new SHA512();
            vm.User.PasswordHash = Convert.ToBase64String(shaMH.ComputeHash(dataHistory));
            Uzytkownicy User = UserBL.GetUserEmail((string)Session["Email"]);

            if (User.PasswordHash == vm.User.PasswordHash && ModelState.IsValid)
            {
                byte[] data = System.Text.Encoding.Default.GetBytes(vm.NewPass);
                SHA512 shaM = new SHA512();
                User.PasswordHash = Convert.ToBase64String(shaM.ComputeHash(data));
                UserBL.EditUser(User);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("errorPass", "Stare Hasło jest nieprawidłowe!");
            return View(vm);
        }
    }
}
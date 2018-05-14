using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektKinoo.Models;
using ProjektKinoo.BusinessLayer;
using System.Web.Security;
using ProjektKinoo.ViewModels.Logowanie;
using System.Net.Security;
using SshNet.Security.Cryptography;

namespace ProjektKinoo.Controllers
{
    public class LogowanieController : Controller
    {
        // GET: Logowanie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rejestracja()
        {
            RejestracjaVM vm = new RejestracjaVM();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Rejestracja(RejestracjaVM vm)
        {
            if (ModelState.IsValid)
            {
                byte[] data = System.Text.Encoding.Default.GetBytes(vm.User.PasswordHash);
                SHA512 shaM = new SHA512();
                vm.User.PasswordHash = Convert.ToBase64String(shaM.ComputeHash(data));
                UzytkownicyBL UserBL = new UzytkownicyBL();
                try
                {
                    UserBL.GetUserEmail(vm.User.Email);
                    ModelState.AddModelError("CredentialError", "Podany email jest zajęty!");
                    return View();
                }
                catch
                {
                    UserBL.AddUser(vm.User);
                }
                
            }
            else
                return View();
            return RedirectToAction("Index", "Home", null);
        }
        public ActionResult Logowanie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logowanie(LogowanieVM vm, string ReturnUrl)
        {
            AppBL appBL = new AppBL();
            byte[] data = System.Text.Encoding.Default.GetBytes(vm.Pass);
            SHA512 shaM = new SHA512();
            vm.Pass = Convert.ToBase64String(shaM.ComputeHash(data));
            if (appBL.IsValidUser(vm.Email, vm.Pass) == true)
            {
                FormsAuthentication.SetAuthCookie(vm.Email, false);
                Response.Cookies["Email"].Value = vm.Email;
                Response.Cookies["Email"].Expires = DateTime.Now.AddDays(1);
                Session["Email"] = vm.Email;
                SHA512.Create(vm.Pass);
                if (ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home", null);
            }
            ModelState.AddModelError("CredentialError", "Niepoprawna nazwa użytkownika lub hasło");
            return View();
        }
        public ActionResult Wyloguj()
        {
            Response.Cookies["Email"].Value = "";
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
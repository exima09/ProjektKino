using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKinoo.Models;

namespace ProjektKinoo.BusinessLayer
{
    public class AppBL
    {
        public bool IsValidUser(string Email, string Pass)
        {
            UzytkownicyBL userBL = new UzytkownicyBL();
            Uzytkownicy user;
            try
            {
                user = userBL.GetUsers().Single(a => a.Email == Email);
                if (user.PasswordHash == Pass)
                {
                    return true;
                }
            }
            catch { return false; }
            return false;
        }
    }
}
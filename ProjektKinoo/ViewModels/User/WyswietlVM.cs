using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjektKinoo.ViewModels.User
{
    public class WyswietlVM
    {
        public Models.Uzytkownicy User { get; set; }
        public string SprawdzAdmin(Models.Uzytkownicy u)
        {
            if (u.Admin == 1)
            {
                return "Administrator";
            }
            else
            {
                return "Użytkownik";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKinoo.Models;

namespace ProjektKinoo.ViewModels.Admin
{
    public class NadajAdministratoraVM
    {
        public List<Uzytkownicy> Lista { get; set; }
        public string SprawdzAdmin(Uzytkownicy u)
        {
            if(u.UserId==1 && u.Admin==1) { return "Główny Administrator"; }
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
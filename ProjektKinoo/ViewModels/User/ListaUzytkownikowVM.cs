using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektKinoo.Models;

namespace ProjektKinoo.ViewModels.User
{
    public class ListaUzytkownikowVM
    {
        public List<Uzytkownicy> Lista { get; set; }
        public string SprawdzAdmin(Uzytkownicy u)
        {
            if(u.Admin==1)
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
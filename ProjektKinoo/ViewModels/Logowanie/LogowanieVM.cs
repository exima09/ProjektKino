using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektKinoo.ViewModels.Logowanie
{
    public class LogowanieVM
    {
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        public string Pass { get; set; }
    }
}
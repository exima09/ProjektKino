using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektKinoo.ViewModels.User
{
    public class ZmienHasloVM
    {
        public Models.Uzytkownicy User { get; set; }
        [Required]
        [Display(Name = "Nowe Hasło")]
        public string NewPass { get; set; }
    }
}
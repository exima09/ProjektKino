using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektKinoo.Models
{
    public class Rezerwacje
    {
        [Key]
        [Display(Name = "Nr rezerwacji")]
        public int IdRezerwacji { get; set; }
        public int IdFilmu { get; set; }
        public int UserId { get; set; }
        public DateTime DataRezerwacji { get; set; }
    }
}
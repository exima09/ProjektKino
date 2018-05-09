using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektKinoo.Models
{
    public class Filmy
    {
        [Key]
        public int IdFilmu { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public double Cena { get; set; }
        [Required]
        [Display(Name = "Godzina Seansu")]
        [Range(0,24,ErrorMessage ="Somsiad pacz na zegar!")]
        public int GodzinaSeansu { get; set; }
        [Required]
        [Display(Name = "Długość Filmu")]
        public int DlugoscSeansu { get; set; }
    }
}
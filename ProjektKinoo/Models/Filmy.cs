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
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double Cena { get; set; }
        [Display(Name = "Godzina Seansu")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string GodzinaSeansu { get; set; }
        [Display(Name = "Długość Filmu")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string DlugoscSeansu { get; set; }
    }
}
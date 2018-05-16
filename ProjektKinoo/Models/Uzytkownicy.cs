using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjektKinoo.Models
{
    public class Uzytkownicy
    {
        [Key]
        [Display(Name ="Nr Użytkownika")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        public string PasswordHash { get; set; }
        [Display(Name = "Uprawnienia")]
        public int Admin { get; set; }
    }   
}
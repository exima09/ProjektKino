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
        public int UserId { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }   
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SbdsSVol2.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name="Fornavn")]
        public string Fname { get; set; }
        [Display(Name = "Etternavn")]
        public string  Lname { get; set; }
        [Display(Name = "Brukernavn")]
        public string  Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        
        [Display(Name = "Alder")]
        public int Age{ get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Adr { get; set; }

        [Required]
        [Display(Name = "Passord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Bekreft Passord")]
        public string ConfirmPassword { get; set; }



       
    }
}
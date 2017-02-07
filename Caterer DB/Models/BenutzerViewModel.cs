﻿

using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Caterer_DB.Models
{

    public class RegisterBenutzerViewModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

       
        [Required]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} Zeichen lang sein.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Passwort { get; set; }

        [Required]
        [DisplayName(@"Passwort Wiederholung")]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string PasswortVerification { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

       

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

       
    }




    public class CreateBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }

    public class EditBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }

    public class DetailsBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }

    public class DeleteBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }

    public class AnmeldenBenutzerViewModel
    {
        public string Anrede { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }


        public List<BenutzerGruppe> BenutzerGruppen { get; set; }

        public LoginModel AnmeldenModel { get; set; }

        public string Infobox { get; set; }

        public List<string> FehlerListe { get; set; }
    }
}


using DataAccess.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{

    public class RegisterBenutzerViewModel
    {
        [Required]
        [DisplayName(@"E-Mail")]
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


        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Organisationsformen { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Lieferumkreise { get; set; }

        public string Anrede { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        [Required]
        public string Firmenname { get; set; }

        [Required]
        public string Organisationsform { get; set; }

        [Required]
        [DisplayName(@"Funktion des Ansprechpartners")]
        public string FunktionAnsprechpartner { get; set; }

        [Required]
        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [Required]
        [DisplayName(@"Fax")]
        public string Fax { get; set; }

        [Required]
        public string Straße { get; set; }

        [Required]
        public string Postleitzahl { get; set; }

        [Required]
        public string Ort { get; set; }

        [Required]
        public string Internetadresse { get; set; }

        [Required]
        public string Lieferumkreis { get; set; }


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


    public class MyDataBenutzerViewModel
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

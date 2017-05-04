using Caterer_DB.Services;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class IndexBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Telefon { get; set; }

        [DisplayName(@"Administrator")]
        public bool IstAdmin { get; set; }
    }

    public class ForgottenPasswordRequestViewModel
    {
        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }
    }

    public class ForgottenPasswordCreateNewPasswordViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [MyRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Das Passwort entspricht nicht den Richtlinien.")]
        public string Passwort { get; set; }

        [MyRequired]
        [DisplayName(@"Passwort Wiederholung")]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string PasswortVerification { get; set; }
    }

    public class RegisterBenutzerViewModel
    {
        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [MyRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Das Passwort entspricht nicht den Richtlinien.")]
        public string Passwort { get; set; }

        [MyRequired]
        [DisplayName(@"Passwort Wiederholung")]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string PasswortVerification { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Organisationsformen { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Lieferumkreise { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [MyRequired]
        public string Firmenname { get; set; }

        [MyRequired]
        public string Organisationsform { get; set; }

        [MyRequired]
        [DisplayName(@"Funktion des Ansprechpartners")]
        public string FunktionAnsprechpartner { get; set; }

        [MyRequired]
        [DisplayName(@"Telefon")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

        [DisplayName(@"Fax")]
        public string Fax { get; set; }

        [MyRequired]
        [DisplayName(@"Straße und Hausnummer")]
        public string Straße { get; set; }

        [MyRequired]
        [RegularExpression("^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$", ErrorMessage = "Bitte PLZ Format beachten 01000 - 99999")]
        public string Postleitzahl { get; set; }

        [MyRequired]
        public string Ort { get; set; }

        public string Internetadresse { get; set; }

        [MyRequired]
        public int Lieferumkreis { get; set; }

        [MyRequired]
        [MustBeTrue(ErrorMessage = "Sie müssen die AGBs akzeptieren")]
        public bool AGBs { get; set; }

        [MyRequired]
        [MustBeTrue(ErrorMessage = "Datenschutzbestimmungen müssen zugestimmt werden")]
        public bool Datenschutz { get; set; }

        public bool WeitergabeVonDaten { get; set; }

        [DisplayName(@"Bemerkungen")]
        public string Sonstiges { get; set; }
    }

    public class CreateMitarbeiterViewModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [Key]
        public int BenutzerId { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon (optional)")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [DisplayName(@"Administrationsberechtigungen")]
        public string IstAdmin { get; set; }
    }

    public class EditBenutzerViewModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [Key]
        [MyRequired]
        public int BenutzerId { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon (optional)")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }

        [DisplayName(@"Administrationsberechtigungen")]
        public string IstAdmin { get; set; }
    }

    public class MeineDatenBenutzerViewModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> JaNein { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [Key]
        [MyRequired]
        public int BenutzerId { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon (optional)")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

    }

    public class MyDataBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Organisationsformen { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Lieferumkreise { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [MyRequired]
        public string Firmenname { get; set; }

        [MyRequired]
        public string Organisationsform { get; set; }

        [MyRequired]
        [DisplayName(@"Funktion des Ansprechpartners")]
        public string FunktionAnsprechpartner { get; set; }

        [MyRequired]
        [DisplayName(@"Telefon")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

        [DisplayName(@"Fax")]
        public string Fax { get; set; }

        [MyRequired]
        [DisplayName(@"Straße und Hausnummer")]
        public string Straße { get; set; }

        [MyRequired]
        [RegularExpression("^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$", ErrorMessage = "Bitte PLZ Format beachten 01000 - 99999")]
        public string Postleitzahl { get; set; }

        [MyRequired]
        public string Ort { get; set; }

        public string Internetadresse { get; set; }

        [MyRequired]
        public int Lieferumkreis { get; set; }

        public DateTime PasswortZeitstempel { get; set; }

        public DateTime LetzteÄnderung { get; set; }

        public bool IstEmailVerifiziert { get; set; }

        public bool WeitergabeVonDaten { get; set; }

        [DisplayName(@"Bemerkungen")]
        public string Sonstiges { get; set; }

        public List<FragenNachThemengebiet> Fragen { get; set; }

        public string _AntwortIDs { get; set; }
    }

    public class DetailsBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [DisplayName(@"Administrator")]
        public bool IstAdmin { get; set; }
    }

    public class DeleteBenutzerViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        public string Straße { get; set; }


        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }

    public class AnmeldenBenutzerViewModel
    {
        [MyRequired]
        public string Anrede { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public int OffeneFragen { get; set; }

        public List<BenutzerGruppe> BenutzerGruppen { get; set; }

        public LoginModel AnmeldenModel { get; set; }

        public string Infobox { get; set; }

        public List<string> FehlerListe { get; set; }
    }

    public class IndexCatererViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Firmenname { get; set; }

        public string Telefon { get; set; }

        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        public bool selected { get; set; }
    }

    public class VergleichCatererViewModel
    {

        public List<List<Frage>> Fragen { get; set; }
        public List<DetailsCatererViewModel> caterer { get; set; }

    }

    public class FullFilterCatererViewModel
    {
        [Key]
        public int FilterId { get; set; }

        public string Name { get; set; }

        [MyRequired]
        [RegularExpression("^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$", ErrorMessage = "Bitte PLZ Format beachten 01000 - 99999")]
        public string PLZ { get; set; }

        public int Umkreis { get; set; }

        public ListViewModel<IndexCatererViewModel> ResultListCaterer { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Fragen { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Lieferumkreise { get; set; }

        public List<FrageAntwortModel> FrageAntwortModel { get; set; }

    }

    public class FrageAntwortModel
    {
        [Key]
        public int FrageAntwortId { get; set; }
        public int FrageId { get; set; }
        public int AntwortId { get; set; }

    }



    public class CreateCatererViewModel
    {
        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Anreden { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Organisationsformen { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Lieferumkreise { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [MyRequired]
        public string Firmenname { get; set; }

        [MyRequired]
        public string Organisationsform { get; set; }

        [MyRequired]
        [DisplayName(@"Funktion des Ansprechpartners")]
        public string FunktionAnsprechpartner { get; set; }

        [MyRequired]
        [DisplayName(@"Telefon")]
        [RegularExpression("(?:\\+\\d+)?\\s*(?:\\(\\d+\\)\\s*(?:[/–-]\\s*)?)?\\d+(?:\\s*(?:[\\s/–-]\\s*)?\\d+)*", ErrorMessage = "Bitte Telefon Format beachten")]
        public string Telefon { get; set; }

        [DisplayName(@"Fax")]
        public string Fax { get; set; }

        [MyRequired]
        [DisplayName(@"Straße und Hausnummer")]
        public string Straße { get; set; }

        [MyRequired]
        [RegularExpression("^([0]{1}[1-9]{1}|[1-9]{1}[0-9]{1})[0-9]{3}$", ErrorMessage = "Bitte PLZ Format beachten 01000 - 99999")]
        public string Postleitzahl { get; set; }

        [MyRequired]
        public string Ort { get; set; }

        public string Internetadresse { get; set; }

        [MyRequired]
        public int Lieferumkreis { get; set; }

        [DisplayName(@"Bemerkungen")]
        public string Sonstiges { get; set; }
    }

    public class DetailsCatererViewModel
    {
        [Key]
        public int BenutzerId { get; set; }

        [MyRequired]
        [DisplayName(@"E-Mail")]
        [EmailAddress(ErrorMessage = "Das Feld E-Mail enthält keine gültige E-Mail-Adresse.")]
        public string Mail { get; set; }

        [MyRequired]
        public string Anrede { get; set; }

        [MyRequired]
        public string Vorname { get; set; }

        [MyRequired]
        public string Nachname { get; set; }

        [MyRequired]
        public string Firmenname { get; set; }

        [MyRequired]
        public string Organisationsform { get; set; }

        [MyRequired]
        [DisplayName(@"Funktion")]
        public string FunktionAnsprechpartner { get; set; }

        [MyRequired]
        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        [DisplayName(@"Fax")]
        public string Fax { get; set; }

        [MyRequired]
        [DisplayName(@"Straße")]
        public string Straße { get; set; }

        [MyRequired]
        public string Postleitzahl { get; set; }

        [MyRequired]
        public string Ort { get; set; }

        public string Internetadresse { get; set; }

        [MyRequired]
        public int Lieferumkreis { get; set; }

        public DateTime PasswortZeitstempel { get; set; }

        public DateTime LetzteÄnderung { get; set; }

        public bool IstEmailVerifiziert { get; set; }

        public bool WeitergabeVonDaten { get; set; }

        [DisplayName(@"Bemerkungen")]
        public string Sonstiges { get; set; }

        public List<FragenNachThemengebiet> Fragen { get; set; }


    }
}
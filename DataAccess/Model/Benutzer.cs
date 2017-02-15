using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Benutzer
    {
        [Key]
        public int BenutzerId { get; set; }

        //Firmendaten
        public string Firmenname { get; set; }

        public string Internetadresse { get; set; }

        public string Lieferumkreis { get; set; }

        public string Organisationsform { get; set; }

        public string Telefon { get; set; }

        public string Fax { get; set; }

        public string Straße { get; set; }

        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        //Ansprechpartner
        public string Anrede { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string FunktionAnsprechpartner { get; set; }

        public string Mail { get; set; }

        //Login

        public string Passwort { get; set; }

        public string EMailVerificationCode { get; set; }

        public string PasswordVerificationCode { get; set; }

        public DateTime PasswortZeitstempel { get; set; }

        public bool IstEmailVerifiziert { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }

        public bool WeitergabeVonDaten { get; set; }
    }
}
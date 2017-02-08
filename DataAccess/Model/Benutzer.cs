using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Benutzer
    {
        [Key]
        public int BenutzerId { get; set; }

        public string Anrede { get; set; }

   
        public string Vorname { get; set; }

   
        public string Nachname { get; set; }

        [DisplayName(@"Telefon")]
        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public string Passwort { get; set; }

        public string EMailVerificationCode { get; set; }

        public bool IstEmailVerifiziert { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }
    }
}
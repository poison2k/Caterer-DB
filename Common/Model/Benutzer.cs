using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Common.Model
{
    public class Benutzer
    {
        [Key]
        public int BenutzerId { get; set; }

        //Firmendaten
        public string Firmenname { get; set; }

        public string Internetadresse { get; set; }

        public int Lieferumkreis { get; set; }

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

        public DateTime LetzteÄnderung { get; set; }

        public bool IstEmailVerifiziert { get; set; }

        public virtual List<BenutzerGruppe> BenutzerGruppen { get; set; }

        public bool WeitergabeVonDaten { get; set; }

        public string Sonstiges { get; set; }

        public string Bemerkung { get; set; }

        //Fragebogen
        public string _AntwortIDs { get; set; }

        //GeoInfoDaten
        public DbGeography Koordinaten { get; set; }

        [NotMapped]
        public virtual List<int> AntwortIDs
        {
            get
            {
                if (_AntwortIDs != "" && _AntwortIDs != null)
                {
                    var test = _AntwortIDs.Split(',');
                    var ids = new List<int>();
                    foreach (string id in test)
                    {
                        ids.Add(Convert.ToInt32(id));
                    }
                    return ids;
                }
                else
                {
                }
                return new List<int>();
            }
            set
            {
                var ids = value;
                _AntwortIDs = "";
                for (int i = 0; i < ids.Count; i++)
                {
                    if (i != ids.Count - 1)
                    {
                        _AntwortIDs = _AntwortIDs + ids[i] + ",";
                    }
                    else
                    {
                        _AntwortIDs = _AntwortIDs + ids[i];
                    }
                }
            }
        }
    }
}
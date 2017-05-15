using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Model;

namespace DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private ICatererContext Db { get; set; }

        public LoginRepository(ICatererContext db)
        {
            Db = db;
        }

        public bool IstNutzerInDatenbankVorhanden(string email)
        {
            return Db.Benutzer.Any(nutzer => nutzer.Mail == email);
        }

        public Benutzer LadeNutzerMitEmail(string email)
        {
            return Db.Benutzer.Include(s => s.BenutzerGruppen).SingleOrDefault(nutzer => nutzer.Mail.ToLower() == email.ToLower());
        }

        public List<BenutzerGruppe> GruppenFürBenutzer(int benutzerId)
        {
            return Db.Benutzer.Include(s => s.BenutzerGruppen).Single(s => s.BenutzerId == benutzerId).BenutzerGruppen;
        }

        public RechteGruppe RechteVerwaltungsGruppeFürNutzergruppe(BenutzerGruppe benutzerGruppe)
        {
            return Db.BenutzerGruppe.Include(s => s.RechteGruppe).Single(s => s.NutzerGruppeID == benutzerGruppe.NutzerGruppeID).RechteGruppe;
        }

        public List<Recht> RechteFürGruppe(RechteGruppe rechteGruppe)
        {
            return Db.RechteGruppe.Include(s => s.Rechte).Single(s => s.RechteVerwaltungsGruppeId == rechteGruppe.RechteVerwaltungsGruppeId).Rechte;
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Speichern(Benutzer benutzer)
        {
            Db.Benutzer.Add(benutzer);
            Save();
        }
    }
}
using DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Common.Model;

namespace DataAccess.Repositories
{
    public class BenutzerGruppeRepository : IBenutzerGruppeRepository
    {
        protected ICatererContext Db { get; }

        public BenutzerGruppeRepository(ICatererContext db)
        {
            Db = db;
        }

        public void AddGroup(BenutzerGruppe benutzerGruppe)
        {
            Db.BenutzerGruppe.Add(benutzerGruppe);
            Db.SaveChanges();
        }

        public void EditGroup(BenutzerGruppe benutzerGruppe)
        {
            Db.SetModified(benutzerGruppe);
            Db.SaveChanges();
        }

        public void RemoveGroup(BenutzerGruppe benutzerGruppe)
        {
            Db.Set<BenutzerGruppe>().Remove(benutzerGruppe);
            Db.SaveChanges();
        }

        public List<BenutzerGruppe> SearchGroup()
        {
            return Db.BenutzerGruppe.ToList();
        }

        public List<BenutzerGruppe> SearchGroupByBenutzer(Benutzer benutzer)
        {
            return Db.BenutzerGruppe.Where(x => x.Benutzer.Contains(benutzer)).ToList();
        }

        public BenutzerGruppe SearchGroupByBezeichnung(string bezeichnung)
        {
            return Db.BenutzerGruppe.Where(x => x.Bezeichnung == bezeichnung).SingleOrDefault();
        }

        public BenutzerGruppe SearchGroupById(int id)
        {
            return Db.BenutzerGruppe.Where(x => x.NutzerGruppeID == id).SingleOrDefault();
        }

        public List<BenutzerGruppe> SearchGroupByRechteGruppe(RechteGruppe rechteGruppe)
        {
            return Db.BenutzerGruppe.Where(x => x.RechteGruppe == rechteGruppe).ToList();
        }
    }
}
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class BenutzerGruppeRepository : IBenutzerGruppeRepository
    {
        protected ICatererContext Db { get; }

        public BenutzerGruppeRepository(ICatererContext db)
        {
            Db = db;
        }

        public void AddGroup(editBenutzerGruppeViewModel benutzerGruppe)
        {
            Db.BenutzerGruppe.Add(benutzerGruppe);
            Db.SaveChanges();
        }

        public void EditGroup(editBenutzerGruppeViewModel benutzerGruppe)
        {
            Db.SetModified(benutzerGruppe);
            Db.SaveChanges();
        }

        public void RemoveGroup(editBenutzerGruppeViewModel benutzerGruppe)
        {
            Db.Set<editBenutzerGruppeViewModel>().Remove(benutzerGruppe);
            Db.SaveChanges();
        }

        public List<editBenutzerGruppeViewModel> SearchGroup()
        {
            return Db.BenutzerGruppe.ToList();
        }
        
        public List<editBenutzerGruppeViewModel> SearchGroupByBenutzer(Benutzer benutzer)
        {
            return Db.BenutzerGruppe.Where(x => x.Benutzer.Contains(benutzer)).ToList();
        }

        public editBenutzerGruppeViewModel SearchGroupByBezeichnung(string bezeichnung)
        {
            return Db.BenutzerGruppe.Where(x => x.Bezeichnung == bezeichnung).SingleOrDefault();
        }

        public editBenutzerGruppeViewModel SearchGroupById(int id)
        {
            return Db.BenutzerGruppe.Where(x => x.NutzerGruppeID == id).SingleOrDefault();
        }

        public List<editBenutzerGruppeViewModel> SearchGroupByRechteGruppe(RechteGruppe rechteGruppe)
        {
            return Db.BenutzerGruppe.Where(x => x.RechteGruppe == rechteGruppe).ToList();
        }
    }
}

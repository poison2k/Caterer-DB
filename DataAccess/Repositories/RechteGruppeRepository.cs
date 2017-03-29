using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class RechteGruppeRepository : IRechteGruppeRepository
    {
        protected ICatererContext Db { get; }

        public RechteGruppeRepository(ICatererContext db)
        {
            Db = db;
        }

        public void AddRightGroup(RechteGruppe rechteGruppe)
        {
            Db.RechteGruppe.Add(rechteGruppe);
            Db.SaveChanges();
        }

        public void EditRightGroup(RechteGruppe rechteGruppe)
        {
            Db.SetModified(rechteGruppe);
            Db.SaveChanges();
        }

        public void RemoveRightGroup(RechteGruppe rechteGruppe)
        {
            Db.Set<RechteGruppe>().Remove(rechteGruppe);
            Db.SaveChanges();
        }

        public List<RechteGruppe> SearchRightGroup()
        {
            return Db.RechteGruppe.ToList();
        }

        public RechteGruppe SearchRightGroupByBezeichnung(string bezeichnung)
        {
            return Db.RechteGruppe.Where(x => x.Bezeichnung == bezeichnung).SingleOrDefault();
        }

        public RechteGruppe SearchRightGroupById(int id)
        {
            return Db.RechteGruppe.Where(x => x.RechteVerwaltungsGruppeId == id).SingleOrDefault();
        }

        public List<RechteGruppe> SearchRightGroupByRecht(Recht recht)
        {
            return Db.RechteGruppe.Where(x => x.Rechte.Contains(recht)).ToList();
        }
    }
}
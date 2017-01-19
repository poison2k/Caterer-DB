using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICatererContext : IObjectContextAdapter
    {
        DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        DbSet<Recht> Recht { get; set; }
        DbSet<RechteGruppe> RechteGruppe { get; set; }
        DbSet<Benutzer> Benutzer { get; set; }

        void DisableAllDynamicFilters();

        void DisableDynamicFilter(string name);

        void EnableDynamicFilter(string name);
        void EnableAllDynamicFilters();
    }
}

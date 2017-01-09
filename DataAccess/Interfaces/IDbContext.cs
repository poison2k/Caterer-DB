using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDbContext  : IObjectContextAdapter
    {
        //DbSet<Benutzer> Benutzer { get; set; }

        //DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }

        //DbSet<Recht> Recht { get; set; }

        //DbSet<RechteGruppe> RechteGruppe { get; set; }

        //void DisableAllDynamicFilters();

        //void DisableDynamicFilter(string name);

        //void EnableDynamicFilter(string name);

        //void EnableAllDynamicFilters();
    }
}

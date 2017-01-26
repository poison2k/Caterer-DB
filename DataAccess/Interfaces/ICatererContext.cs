using DataAccess.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Interfaces
{
    public interface ICatererContext : IObjectContextAdapter
    {

        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        DbSet<Recht> Recht { get; set; }
        DbSet<RechteGruppe> RechteGruppe { get; set; }
        DbSet<Benutzer> Benutzer { get; set; }
       
    }
}

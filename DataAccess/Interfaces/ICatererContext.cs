using Common.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICatererContext : IObjectContextAdapter
    {
        DbEntityEntry Entry(object entity);

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet Set(Type entityType);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void DisableAllDynamicFilters();

        void DisableDynamicFilter(string name);

        void EnableDynamicFilter(string name);

        void EnableAllDynamicFilters();

        int SaveChanges();

        DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        DbSet<Recht> Recht { get; set; }
        DbSet<RechteGruppe> RechteGruppe { get; set; }
        DbSet<Benutzer> Benutzer { get; set; }
        DbSet<Kategorie> Kategorie { get; set; }
        DbSet<Frage> Frage { get; set; }
        DbSet<Antwort> Antwort { get; set; }
        DbSet<Fragebogen> Fragebogen { get; set; }
        DbSet<Config> Config { get; set; }

        void SetModified(object objekt);
    }
}
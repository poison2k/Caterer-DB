﻿using DataAccess.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Interfaces
{
    public interface ICatererContext : IObjectContextAdapter {

        int SaveChanges();

        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        DbSet<Recht> Recht { get; set; }
        DbSet<RechteGruppe> RechteGruppe { get; set; }
        DbSet<Benutzer> Benutzer { get; set; }
        DbSet<Sparte> Sparte { get; set; }
        DbSet<Frage> Frage { get; set; }
        DbSet<Antwort> Antwort { get; set; }
        DbSet<Fragebogen> Fragebogen { get; set; }

        void SetModified(object objekt);

    }
}

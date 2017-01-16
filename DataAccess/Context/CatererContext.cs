using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Interfaces;
using System.Data.Entity;
using System.Configuration;
using EntityFramework.DynamicFilters;

namespace DataAccess.Context
    {
    public class CatererContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public CatererContext() : base("CatererConnectionString") { }
        public virtual DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        public virtual DbSet<Recht> Recht { get; set; }
        public virtual DbSet<RechteGruppe> RechteGruppe { get; set; }
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public static CatererContext Create()
        {
            return new CatererContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private static string ConnectionStringErmitteln()
        {
            return ConfigurationManager.ConnectionStrings[1].Name;
        }

        public void DisableAllDynamicFilters()
        {
            this.DisableAllFilters();
        }

        public void EnableAllDynamicFilters()
        {
            this.EnableAllFilters();
        }

        public void DisableDynamicFilter(string name)
        {
            this.DisableFilter(name);
        }

        public void EnableDynamicFilter(string name)
        {
            this.EnableFilter(name);
        }
    }
}





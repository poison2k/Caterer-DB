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
    public class CatererContext : IdentityDbContext<ApplicationUser>, ICatererContext
    {


        

        public CatererContext() : base("CatererConnectionString") { }
        public virtual DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        public virtual DbSet<Recht> Recht { get; set; }
        public virtual DbSet<RechteGruppe> RechteGruppe { get; set; }
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public virtual DbSet<Sparte> Sparte { get; set; }
        public virtual DbSet<Frage> Frage { get; set; }
        public virtual DbSet<Antwort> Antwort { get; set; }
        public virtual DbSet<Fragebogen> Fragebogen { get; set; }
        //public virtual DbSet<IdentityUser> user { get; set; }
        //public virtual DbSet<ApplicationUser> role { get; set; }
        //public virtual DbSet<IdentityRole> userrole { get; set; }
        //public virtual DbSet<IdentityUserClaim> userclaim { get; set; }
        //public virtual DbSet<IdentityUserLogin> userlogin { get; set; }



        public static CatererContext Create()
        {
            return new CatererContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("user");
            modelBuilder.Entity<ApplicationUser>().ToTable("user");

            modelBuilder.Entity<IdentityRole>().ToTable("role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("userrole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogin");
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





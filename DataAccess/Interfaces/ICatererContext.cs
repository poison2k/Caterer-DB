using DataAccess.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        //DbSet<BenutzerGruppe> BenutzerGruppe { get; set; }
        //DbSet<Recht> Recht { get; set; }
        //DbSet<RechteGruppe> RechteGruppe { get; set; }
        //DbSet<Benutzer> Benutzer { get; set; }
        //DbSet<IdentityUser> user { get; set; }
        //DbSet<ApplicationUser> role { get; set; }
        //DbSet<IdentityRole> userrole { get; set; }
        //DbSet<IdentityUserClaim> userclaim { get; set; }
        //DbSet<IdentityUserLogin> userlogin { get; set; }
    }
}

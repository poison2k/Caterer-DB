using Caterer_DB.App_Start;
using Caterer_DB.App_Start.ContextInitializer;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Caterer_DB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
#if DEBUG
            Database.SetInitializer(new ContextInitializerCreateAlwaysMitBeispieldaten());

#else

            Database.SetInitializer(new ContextInitializerCreateAlwaysWithStartData());
#endif
            //CatererContext db = new CatererContext();
            //db.Database.Initialize(true);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

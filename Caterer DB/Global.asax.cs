using Caterer_DB.App_Start;
using Caterer_DB.App_Start.ContextInitializer;
using Caterer_DB.Models;
using Caterer_DB.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;


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



            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            AreaRegistration.RegisterAllAreas();

            //Die Webapi config muss auf jeden fall vor der RouteConfig kommen,
            //da sie sonst überschrieben wird und die webapi routen nicht gefunden werden

          


        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null)
                {
                    var serializeModel = JsonConvert.DeserializeObject<CookieSerializeModel>(authTicket.UserData);
                    if (serializeModel != null)
                    {
                        var db = new CatererContext();

                        var newUser = new UserModel(authTicket.Name, serializeModel.BenutzerId, new LoginService(new LoginRepository(db)));
                        newUser.BenutzerId = serializeModel.BenutzerId;
                        newUser.Vorname = serializeModel.Vorname;
                        newUser.Nachname = serializeModel.Nachname;
                        newUser.Email = serializeModel.Email;
                        
                        newUser.NutzergruppenIds = serializeModel.NutzergruppenIds;

                        HttpContext.Current.User = newUser;
                    }
                }



            }
        }
    }
}


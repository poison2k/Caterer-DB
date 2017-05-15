using Caterer_DB.App_Start.ContextInitializer;
using Caterer_DB.Models;
using DataAccess.Context;
using DataAccess.Repositories;
using log4net.Config;
using Newtonsoft.Json;
using SqlServerTypes;
using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
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
            //Workariund um GeoDaten in SQL Server nutzen zu können
            SqlProviderServices.SqlServerTypesAssemblyName = "Microsoft.SqlServer.Types, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91";
#if DEBUG
            Database.SetInitializer(new ContextInitializerCreateAlwaysMitBeispieldaten());

#else

            Database.SetInitializer(new ContextInitializerCreateIfNotExistsWithStartData());
#endif

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            AreaRegistration.RegisterAllAreas();
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
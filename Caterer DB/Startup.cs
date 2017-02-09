using Microsoft.Owin;
using Owin;



[assembly: OwinStartupAttribute(typeof(Caterer_DB.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]

namespace Caterer_DB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.MapSignalR();
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caterer_DB.Startup))]
namespace Caterer_DB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

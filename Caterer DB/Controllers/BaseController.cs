using Caterer_DB.Interfaces;
using Caterer_DB.Models;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace Caterer_DB.Controllers
{
#if DEBUG

#else
     [RequireHttps]
#endif
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class BaseController : Controller
    {
        [Dependency]
        public IFindCurrentUserService FindCurrentUserService { get; set; }

        protected new UserModel User
        {
            get { return FindCurrentUserService.CurrentUser(); }
        }
    }
}
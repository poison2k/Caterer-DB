using System.Web.Mvc;

namespace Caterer_DB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        #if DEBUG

        #else
            filters.Add(new RequireHttpsAttribute());
        #endif

        }
    }
}
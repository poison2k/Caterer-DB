using System.Web;
using Caterer_DB.Interfaces;
using Caterer_DB.Models;

namespace Caterer_DB
{
    public class FindCurrentUserService : IFindCurrentUserService
    {
        public UserModel CurrentUser()
        {
            return HttpContext.Current.User as UserModel;
        }
    }
}
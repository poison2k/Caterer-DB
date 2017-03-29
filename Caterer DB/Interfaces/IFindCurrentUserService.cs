using Caterer_DB.Models;

namespace Caterer_DB.Interfaces
{
    public interface IFindCurrentUserService
    {
        UserModel CurrentUser();
    }
}
using Caterer_DB.Models;
using Caterer_DB.ViewModel;

namespace Caterer_DB.Interfaces
{
    public interface IFindCurrentUserService
    {
        UserModel CurrentUser();
    }
}
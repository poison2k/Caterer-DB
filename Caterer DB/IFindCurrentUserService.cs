using Caterer_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caterer_DB.Interfaces
{
    public interface IFindCurrentUserService
    {
        UserModel CurrentUser();
    }
}

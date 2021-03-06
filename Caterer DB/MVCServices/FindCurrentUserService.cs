﻿using System.Web;
using Caterer_DB.Interfaces;
using Caterer_DB.ViewModel;

namespace Caterer_DB.MVCServices
{
    public class FindCurrentUserService : IFindCurrentUserService
    {
        public UserModel CurrentUser()
        {
            return HttpContext.Current.User as UserModel;
        }
    }
}
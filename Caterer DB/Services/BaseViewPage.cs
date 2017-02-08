using Caterer_DB.Models;
using System.Web.Mvc;

namespace Caterer_DB.Services
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new UserModel User
        {
            get { return base.User as UserModel; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new UserModel User
        {
            get { return base.User as UserModel; }
        }
    }
}
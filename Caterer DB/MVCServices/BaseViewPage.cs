using System.Web.Mvc;
using Caterer_DB.Models;

namespace Caterer_DB.MVCServices
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
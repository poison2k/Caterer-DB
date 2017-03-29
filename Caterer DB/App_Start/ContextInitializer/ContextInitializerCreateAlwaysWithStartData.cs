using DataAccess.Context;
using System.Data.Entity;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ContextInitializerCreateAlwaysWithStartData : DropCreateDatabaseAlways<CatererContext>
    {
        protected override void Seed(CatererContext context)
        {
            StartData.CreateStartData(context);
            context.SaveChanges();
        }
    }
}
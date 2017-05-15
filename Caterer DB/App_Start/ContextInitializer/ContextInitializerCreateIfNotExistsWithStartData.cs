using System.Data.Entity;
using DataAccess.Context;

namespace Caterer_DB.ContextInitializer
{
    public class ContextInitializerCreateIfNotExistsWithStartData : CreateDatabaseIfNotExists<CatererContext>
    {
        protected override void Seed(CatererContext context)
        {
            StartData.CreateStartData(context);
            context.SaveChanges();
        }
    }
}
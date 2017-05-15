using System.Data.Entity;
using DataAccess.Context;

namespace Caterer_DB.ContextInitializer
{
    public class ContextInitializerCreateAlwaysMitBeispieldaten : DropCreateDatabaseAlways<CatererContext>
    {
        protected override void Seed(CatererContext context)
        {
            ExampleData.CreateExampleData(context);
            context.SaveChanges();
        }
    }
}
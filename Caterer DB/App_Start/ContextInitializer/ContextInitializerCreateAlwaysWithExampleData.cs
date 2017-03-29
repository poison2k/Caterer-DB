using DataAccess.Context;
using System.Data.Entity;

namespace Caterer_DB.App_Start.ContextInitializer
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
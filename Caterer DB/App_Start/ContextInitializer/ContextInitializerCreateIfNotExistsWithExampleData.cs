using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ContextInitializerCreateAlwaysWithExampleData : CreateDatabaseIfNotExists<CatererContext>
    {
        protected override void Seed(CatererContext context)
        {
            ExampleData.CreateExampleData(context);
            context.SaveChanges();
        }
    }
}
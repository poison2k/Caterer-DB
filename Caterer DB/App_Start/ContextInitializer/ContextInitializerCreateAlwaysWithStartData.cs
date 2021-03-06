﻿using System.Data.Entity;
using DataAccess.Context;

namespace Caterer_DB.ContextInitializer
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
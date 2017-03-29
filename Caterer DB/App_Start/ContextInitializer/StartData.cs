using DataAccess.Interfaces;
using System;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class StartData
    {
        public static void CreateStartData(ICatererContext db)
        {
            CreateUserData(db);
        }

        private static void CreateUserData(ICatererContext db)
        {
            throw new NotImplementedException();
        }
    }
}
using Caterer_DB;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.App_Start.ContextInitializer
{
    public class ExampleData
    {



        public static void CreateExampleData(CatererContext db)
        {
            CreateUserData(db);
        }

        private static void CreateUserData(CatererContext db)
        {

            ApplicationUser caterer = db.Users.Add(new ApplicationUser {
                
                UserName = "caterer@test.de",
                Email = "caterer@test.de",
                PasswordHash = "ANhg2qq6hnMpsu9b1IYyv9KwbviJ+JHdFqlJsCc2/GkhyJFZQ8vDewv+l8C2MC2/8A==",
                SecurityStamp = "67b2359a-4bb7-4818-844f-e5893d6ba80f"
            });

            db.SaveChanges();
                     
            
        }
    }
}
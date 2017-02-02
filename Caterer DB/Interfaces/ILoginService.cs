using Caterer_DB.Services;
using DataAccess.Interfaces;
using System.Collections.Generic;


namespace Caterer_DB.Interfaces
{
    public interface ILoginService
    {
       
            LoginSuccessLevel AnmeldePrüfung(string kurzname, string passwort);

            void Abmelden();

            ILoginRepository LoginRepository { get; }

            
            List<string> ladeRechte(int benutzerId);
            List<int> ladeNutzergruppenIds(int benutzerId);
        
    }
}

using DataAccess.Interfaces;
using System.Collections.Generic;
using Caterer_DB.MVCServices;

namespace Caterer_DB.Interfaces
{
    public interface ILoginService
    {
        LoginSuccessLevel AnmeldePrüfung(string kurzname, string passwort);

        void Abmelden();

        ILoginRepository LoginRepository { get; }

        List<string> LadeRechte(int benutzerId);

        List<string> LadeRollen(int benutzerId);

        List<int> LadeNutzergruppenIds(int benutzerId);
    }
}
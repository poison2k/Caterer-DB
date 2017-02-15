using DataAccess.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IBenutzerService
    {
        Benutzer SearchUserById(int id);

        Benutzer SearchUserByEmail(string email);

        List<Benutzer> FindAllBenutzers();

        void AddBenutzer(Benutzer benutzer);
        void RegisterBenutzer(Benutzer benutzer);


        void EditBenutzer(Benutzer benutzer);
        void RemoveBenutzer(int id);
        void ForgottenPasswordEmailForBenutzer(string Mail);

        bool CheckEmailForRegistration(string mail);
        bool VerifyRegistration(string id, string verify);
        bool VerifyPasswordChange(string id, string verify);
        void EditBenutzerPassword(Benutzer benutzer);
    }
}
using DataAccess.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IBenutzerService
    {
        Benutzer SearchUserById(int id);
        Benutzer SearchUserByIdNoTracking(int id);
        

        Benutzer SearchUserByEmail(string email);

        List<Benutzer> FindAllBenutzers();
        List<Benutzer> FindAllMitarbeiterWithPaging(int aktuelleSeite, int seitenGroesse);

        void AddBenutzer(Benutzer benutzer);
        void AddMitarbeiter(Benutzer benutzer, string mitarbeiterGruppe);

        void RegisterBenutzer(Benutzer benutzer);


        void EditBenutzer(Benutzer benutzer);
        void RemoveBenutzer(int id);
        void ForgottenPasswordEmailForBenutzer(string Mail);

        bool CheckEmailForRegistration(string mail);
        bool VerifyRegistration(string id, string verify);
        bool VerifyPasswordChange(string id, string verify);
        void EditBenutzerPassword(Benutzer benutzer);
        int GetMitarbeiterCount();

    }
}
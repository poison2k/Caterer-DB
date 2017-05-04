using DataAccess.Model;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace DataAccess.Interfaces
{
    public interface IBenutzerRepository
    {
        List<Benutzer> FindeCatererNachUmkreis(DbGeography geoDaten, int umkreis);
        
        void AddUser(Benutzer benutzer);

        void EditUser(Benutzer benutzer);

        void RemoveUser(Benutzer benutzer);

        Benutzer SearchUserById(int id);

        Benutzer SearchUserByIdNoTracking(int id);

        Benutzer SearchUserByEMail(string eMail);

        Benutzer SearchUserByEmailVerify(string verify);

        List<Benutzer> SearchUser();

        List<Benutzer> SearchUserByCity(string city);

        List<Benutzer> SearchUserByPostcode(string postcode);

        List<Benutzer> SearchUserBySurname(string surname);

        List<Benutzer> SearchAllCatererWithPaging(int aktuelleSeite, int seitenGroesse);

        List<Benutzer> SearchAllUserByUserGroupWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, List<string> BenutzerGruppen, string orderBy = "" , int umkreis = -1, DbGeography geoDaten = null, string name = "");

        List<Benutzer> SearchUser(List<int> ids);
        int GetMitarbeiterCount();

        int GetCatererCount();

        int GetAdminCount();
    }
}
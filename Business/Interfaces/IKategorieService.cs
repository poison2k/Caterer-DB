using DataAccess.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IKategorieService
    {
        Kategorie SearchKategorieById(int id);

        List<Kategorie> FindAlleKategorien();

        void AddKategorie(Kategorie kategorie);

        void EditKategorie(Kategorie kategorie);

        void RemoveKategorie(int id);

        Kategorie SearchKategorieByName(string kategorie);
    }
}
using System.Collections.Generic;
using Common.Model;

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
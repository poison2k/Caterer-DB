using System.Collections.Generic;
using Common.Model;

namespace DataAccess.Interfaces
{
    public interface IKategorieRepository
    {
        void AddKategorie(Kategorie kategorie);

        void EditKategorie(Kategorie kategorie);

        void RemoveKategorie(Kategorie kategorie);

        List<Kategorie> SearchKategorie();

        Kategorie SearchKategorieIdById(int id);

        Kategorie SearchKategorieByName(string name);
    }
}
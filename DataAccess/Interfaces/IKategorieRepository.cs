using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

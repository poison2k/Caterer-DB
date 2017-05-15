using System.Collections.Generic;
using Common.Model;

namespace DataAccess.Interfaces
{
    public interface IFrageRepository
    {
        void AddFrage(Frage frage);

        void EditFrage(Frage frage);

        void RemoveFrage(Frage frage);

        List<Frage> SearchFrage();

        Frage SearchFrageById(int id);

        List<Frage> SearchFrageByKategorie(Kategorie kategorie);

        List<List<Frage>> GetAllFragenSortetByKategorienInDifferntLists(List<Kategorie> kategorien);

        List<Frage> GetFragenOfKategorieByKategorieId(int kategorieId);

        List<Frage> SearchAllFrageNeuWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, string orderBy);

        List<Frage> SearchAllFrageVeröffentlichtWithPagingOrderByCategory(int aktuelleSeite, int seitenGroesse, string orderBy);

        int GetFrageNeuCount();

        int GetFrageVeröffentlichtCount();

        Frage SearchFrageByAntwortId(int antwortID);
    }
}
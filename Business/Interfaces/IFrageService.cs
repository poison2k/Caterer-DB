using DataAccess.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IFrageService
    {
        Frage SearchFrageById(int id);

        List<Frage> FindAlleFragen();

        List<Frage> FindFragenNachKategorieByKategorieId(int kategorieId);

        List<List<Frage>> FindAlleFragenNachKategorieninEigenenListen();

        void AddFrage(Frage frage);

        void EditFrage(Frage frage);

        void RemoveFrage(int id);

        List<Frage> FindAllFrageWithPagingNeu(int aktuelleSeite, int seitenGrösse, string sortierrung);

        List<Frage> FindAllFrageWithPagingVeröffentlicht(int aktuelleSeite, int seitenGrösse, string sortierrung);

        int GetFrageVeröffentlichtCount();

        int GetFrageNeuCount();
    }
}
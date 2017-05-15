using System.Collections.Generic;
using Common.Model;

namespace DataAccess.Interfaces
{
    public interface IAntwortRepository
    {
        void AddAntwort(Antwort antwort);

        void EditAntwort(Antwort antwort);

        void RemoveAntwort(Antwort antwort);

        List<Antwort> SearchAntwort();

        Antwort SearchAntwortById(int id);

        List<Antwort> SearchAntwortByFrage(Frage frage);
    }
}
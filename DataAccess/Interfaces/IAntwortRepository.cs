using DataAccess.Model;
using System.Collections.Generic;

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
using System.Collections.Generic;
using Common.Model;


namespace Business.Interfaces
{
    public interface IAntwortService
    {
        Antwort SearchAntwortById(int id);

        List<Antwort> FindAlleAntworten();

        void AddAntwort(Antwort antwort);

        void EditAntwort(Antwort antwort);

        void RemoveAntwort(int id);
    }
}
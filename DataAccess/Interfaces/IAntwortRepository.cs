using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAntwortRepository
    {
        Antwort SearchAntwortById(int id);
        List<Antwort> SearchAntwortByFrage(Frage frage);
    }
}

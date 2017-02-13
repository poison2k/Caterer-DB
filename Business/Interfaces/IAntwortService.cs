using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

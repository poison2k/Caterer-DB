using Common.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IFragebogenRepository
    {
        Fragebogen SearchFragenbogenById(int id);

        List<Fragebogen> SearchFragebogenByBenutzer(Benutzer benutzer);

        List<Fragebogen> SearchFragebogenByAntwort(Antwort antwort);
    }
}
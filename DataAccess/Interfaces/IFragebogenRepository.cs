using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IFragebogenRepository
    {
        Fragebogen SearchFragenbogenById(int id);
        List<Fragebogen> SearchFragebogenByFrage(Frage frage);
        List<Fragebogen> SearchFragebogenByBenutzer(Benutzer benutzer);
       
    }
}

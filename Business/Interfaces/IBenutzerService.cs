using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBenutzerService
    {

        Benutzer SearchUserById(int id);
        List<Benutzer> FindAllBenutzers();
        void AddBenutzer(Benutzer benutzer);
        void EditBenutzer(Benutzer benutzer);
        void RemoveBenutzer(int id);

    }
}

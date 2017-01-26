using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBenutzerRepository
    {
        Benutzer SearchUserById(int id);
        Benutzer SearchUserByEMail(string eMail);
        List<Benutzer> SearchUserByCity(string city);
        List<Benutzer> SearchUserByPostcode(string postcode);
        List<Benutzer> SearchUserBySurname(string surname);
        
    }
}

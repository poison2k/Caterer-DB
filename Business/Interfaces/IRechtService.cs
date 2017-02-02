using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRechtService
    {
        Recht SearchRightById(int id);
        List<Recht> FindAllRights();
        void AddRecht(Recht recht);
        void EditRecht(Recht recht);
        void RemoveRecht(int id);
    }
}

using DataAccess.Model;
using System.Collections.Generic;

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
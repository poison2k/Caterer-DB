using System.Collections.Generic;
using Common.Model;

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
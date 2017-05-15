using Business.Interfaces;
using Common.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class RechtService : IRechtService
    {
        public IRechtRepository RechtRepository { get; set; }

        public RechtService(IRechtRepository rechtRepository)
        {
            RechtRepository = rechtRepository;
        }

        public void AddRecht(Recht recht)
        {
            RechtRepository.AddRight(recht);
        }

        public void EditRecht(Recht recht)
        {
            RechtRepository.EditRight(recht);
        }

        public List<Recht> FindAllRights()
        {
            return RechtRepository.SearchRight();
        }

        public void RemoveRecht(int id)
        {
            RechtRepository.RemoveRight(RechtRepository.SearchRightById(id));
        }

        public Recht SearchRightById(int id)
        {
            return RechtRepository.SearchRightById(id);
        }
    }
}
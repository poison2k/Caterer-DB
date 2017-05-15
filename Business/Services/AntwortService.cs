using Business.Interfaces;
using Common.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class AntwortService : IAntwortService
    {
        public IAntwortRepository AntwortRepository { get; set; }

        public AntwortService(IAntwortRepository antwortRepository)
        {
            AntwortRepository = antwortRepository;
        }

        public void AddAntwort(Antwort antwort)
        {
            AntwortRepository.AddAntwort(antwort);
        }

        public void EditAntwort(Antwort antwort)
        {
            AntwortRepository.EditAntwort(antwort);
        }

        public List<Antwort> FindAlleAntworten()
        {
            return AntwortRepository.SearchAntwort();
        }

        public void RemoveAntwort(int id)
        {
            AntwortRepository.RemoveAntwort(AntwortRepository.SearchAntwortById(id));
        }

        public Antwort SearchAntwortById(int id)
        {
            return AntwortRepository.SearchAntwortById(id);
        }
    }
}
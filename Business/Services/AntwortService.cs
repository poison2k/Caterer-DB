using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

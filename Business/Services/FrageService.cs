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
    public class FrageService : IFrageService
    {

        public IFrageRepository FrageRepository { get; set; }

        public IKategorieRepository KategorienRepository { get; set; }

        public FrageService(IFrageRepository frageRepository, IKategorieRepository kategorienRepository)
        {
            FrageRepository = frageRepository;
            KategorienRepository = kategorienRepository;
        }

        public void AddFrage(Frage frage)
        {
            FrageRepository.AddFrage(frage);
        }

        public void EditFrage(Frage frage)
        {
            FrageRepository.EditFrage(frage);
        }

        public List<Frage> FindAlleFragen()
        {
            return FrageRepository.SearchFrage();
        }

        public List<List<Frage>> FindAlleFragenNachKategorieninEigenenListen()
        {
            return FrageRepository.GetAllFragenSortetByKategorienInDifferntLists(KategorienRepository.SearchKategorie());
        }

        public void RemoveFrage(int id)
        {
            FrageRepository.RemoveFrage(FrageRepository.SearchFrageById(id));
        }

        public Frage SearchFrageById(int id)
        {
            return FrageRepository.SearchFrageById(id);
        }
    }
}

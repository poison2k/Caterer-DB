using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;

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

        public List<Frage> FindFragenNachKategorieByKategorieId(int kategorieId)
        {
            return FrageRepository.GetFragenOfKategorieByKategorieId(kategorieId);
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

        public List<Frage> FindAllFrageWithPagingNeu(int aktuelleSeite, int seitenGrösse, string sortierrung)
        {
            return FrageRepository.SearchAllFrageNeuWithPagingOrderByCategory(aktuelleSeite, seitenGrösse, sortierrung);
        }

        public List<Frage> FindAllFrageWithPagingVeröffentlicht(int aktuelleSeite, int seitenGrösse, string sortierrung)
        {
            return FrageRepository.SearchAllFrageVeröffentlichtWithPagingOrderByCategory(aktuelleSeite, seitenGrösse, sortierrung);
        }

        public int GetFrageVeröffentlichtCount()
        {
            return FrageRepository.GetFrageVeröffentlichtCount();
        }

        public int GetFrageNeuCount()
        {
            return FrageRepository.GetFrageNeuCount();
        }
    }
}

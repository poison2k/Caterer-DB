using Business.Interfaces;
using DataAccess.Interfaces;
using System.Collections.Generic;
using Common.Model;

namespace Business.Services
{
    public class KategorieService : IKategorieService
    {
        public IKategorieRepository KategorieRepository { get; set; }

        public KategorieService(IKategorieRepository kategorieRepository)
        {
            KategorieRepository = kategorieRepository;
        }

        public void AddKategorie(Kategorie kategorie)
        {
            KategorieRepository.AddKategorie(kategorie);
        }

        public void EditKategorie(Kategorie kategorie)
        {
            KategorieRepository.EditKategorie(kategorie);
        }

        public List<Kategorie> FindAlleKategorien()
        {
            return KategorieRepository.SearchKategorie();
        }

        public void RemoveKategorie(int id)
        {
            KategorieRepository.RemoveKategorie(KategorieRepository.SearchKategorieIdById(id));
        }

        public Kategorie SearchKategorieById(int id)
        {
            return KategorieRepository.SearchKategorieIdById(id);
        }

        public Kategorie SearchKategorieByName(string name)
        {
            return KategorieRepository.SearchKategorieByName(name);
        }
    }
}
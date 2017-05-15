using Business.Interfaces;
using Common.Interfaces;
using DataAccess.Interfaces;
using System.Collections.Generic;
using Common.Model;

namespace Business.Services
{
    public class FrageService : IFrageService
    {
        public IFrageRepository FrageRepository { get; set; }

        public IKategorieRepository KategorienRepository { get; set; }

        public IMailService MailService { get; set; }

        public IBenutzerService BenutzerService { get; set; }

        public IConfigService ConfigService { get; set; }

        public FrageService(IFrageRepository frageRepository, IKategorieRepository kategorienRepository, IMailService mailService, IBenutzerService benutzerService, IConfigService configService)
        {
            FrageRepository = frageRepository;
            KategorienRepository = kategorienRepository;
            MailService = mailService;
            BenutzerService = benutzerService;
            ConfigService = configService;
        }

        public void AddFrage(Frage frage)
        {
            FrageRepository.AddFrage(frage);
        }

        public void EditFrage(Frage frage)
        {
            if (frage.IstVeröffentlicht)
            {
                foreach (var benutzer in BenutzerService.FindAllBenutzers())
                {
                    foreach (var gruppe in benutzer.BenutzerGruppen)
                    {
                        if (gruppe.Bezeichnung == "Caterer")
                        {
                            MailService.SendReleasedQuestionCatererMail(ConfigService.GetConfig(), benutzer.Mail);
                        }
                    }
                }
            }
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
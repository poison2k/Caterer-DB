using Business.Interfaces;
using DataAccess.Interfaces;
using System.Collections.Generic;
using Common.Model;


namespace Business.Services
{
    public class BenutzerGruppeService : IBenutzerGruppeService
    {
        public IBenutzerGruppeRepository BenutzerGruppeRepository { get; set; }

        public BenutzerGruppeService(IBenutzerGruppeRepository benutzerGruppeRepository)
        {
            BenutzerGruppeRepository = benutzerGruppeRepository;
        }

        public void AddBenutzerGruppe(BenutzerGruppe benutzerGruppe)
        {
            BenutzerGruppeRepository.AddGroup(benutzerGruppe);
        }

        public void EditBenutzerGruppe(BenutzerGruppe benutzerGruppe)
        {
            BenutzerGruppeRepository.EditGroup(benutzerGruppe);
        }

        public List<BenutzerGruppe> FindAllGroups()
        {
            return BenutzerGruppeRepository.SearchGroup();
        }

        public void RemoveBenutzerGruppe(int id)
        {
            BenutzerGruppeRepository.RemoveGroup(BenutzerGruppeRepository.SearchGroupById(id));
        }

        public BenutzerGruppe SearchGroupById(int id)
        {
            return BenutzerGruppeRepository.SearchGroupById(id);
        }

        public BenutzerGruppe SearchGroupByBezeichnung(string bezeichnung)
        {
            return BenutzerGruppeRepository.SearchGroupByBezeichnung(bezeichnung);
        }
    }
}
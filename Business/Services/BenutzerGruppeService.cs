using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class BenutzerGruppeService : IBenutzerGruppeService
    {
        public IBenutzerGruppeRepository BenutzerGruppeRepository { get; set; }

        public BenutzerGruppeService(IBenutzerGruppeRepository benutzerGruppeRepository)
        {
            BenutzerGruppeRepository = benutzerGruppeRepository;

        }

        public void AddBenutzerGruppe(editBenutzerGruppeViewModel benutzerGruppe)
        {
            BenutzerGruppeRepository.AddGroup(benutzerGruppe);
        }

        public void EditBenutzerGruppe(editBenutzerGruppeViewModel benutzerGruppe)
        {
            BenutzerGruppeRepository.EditGroup(benutzerGruppe);
        }

        public List<editBenutzerGruppeViewModel> FindAllGroups()
        {
            return BenutzerGruppeRepository.SearchGroup();
        }

        public void RemoveBenutzerGruppe(int id)
        {
            BenutzerGruppeRepository.RemoveGroup(BenutzerGruppeRepository.SearchGroupById(id));
        }

        public editBenutzerGruppeViewModel SearchGroupById(int id)
        {
            return BenutzerGruppeRepository.SearchGroupById(id);
        }
    }
}

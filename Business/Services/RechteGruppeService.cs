using Business.Interfaces;
using Common.Model;
using DataAccess.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class RechteGruppeService : IRechteGruppeService
    {
        public IRechteGruppeRepository RechteGruppeRepository { get; set; }

        public RechteGruppeService(IRechteGruppeRepository rechteGruppeRepository)
        {
            RechteGruppeRepository = rechteGruppeRepository;
        }

        public void AddRechteGruppe(RechteGruppe rechteGruppe)
        {
            RechteGruppeRepository.AddRightGroup(rechteGruppe);
        }

        public void EditRechteGruppe(RechteGruppe rechteGruppe)
        {
            RechteGruppeRepository.EditRightGroup(rechteGruppe);
        }

        public List<RechteGruppe> FindAllRightGroups()
        {
            return RechteGruppeRepository.SearchRightGroup();
        }

        public void RemoveRechteGruppe(int id)
        {
            RechteGruppeRepository.RemoveRightGroup(RechteGruppeRepository.SearchRightGroupById(id));
        }

        public RechteGruppe SearchRightGroupById(int id)
        {
            return RechteGruppeRepository.SearchRightGroupById(id);
        }
    }
}
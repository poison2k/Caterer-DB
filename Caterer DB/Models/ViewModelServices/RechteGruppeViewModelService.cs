using Caterer_DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Model;
using AutoMapper;

namespace Caterer_DB.Models.ViewModelServices
{
    public class RechteGruppeViewModelService : IRechteGruppeViewModelService
    {
        private IMapper Mapper { get; set; }
        
        public RechteGruppeViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<RechteGruppe, CreateRechteGruppeViewModel>().ReverseMap();
                cfg.CreateMap<RechteGruppe, EditRechteGruppeViewModel>().ReverseMap();
                cfg.CreateMap<RechteGruppe, DeleteRechteGruppeViewModel>().ReverseMap();
                cfg.CreateMap<RechteGruppe, DetailsRechteGruppeViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public RechteGruppe Map_CreateRechteGruppeViewModel_RechteGruppe(CreateRechteGruppeViewModel createRechteGruppeViewModel)
        {
            return Mapper.Map<RechteGruppe>(createRechteGruppeViewModel);
        }

        public RechteGruppe Map_EditRechteGruppeViewModel_RechteGruppe(EditRechteGruppeViewModel editRechteGruppeViewModel)
        {
            return Mapper.Map<RechteGruppe>(editRechteGruppeViewModel);
        }

        public EditRechteGruppeViewModel Map_RechteGruppe_EditRechteGruppeViewModel(RechteGruppe rechteGruppe)
        {
            return Mapper.Map<EditRechteGruppeViewModel>(rechteGruppe);
        }

        public DetailsRechteGruppeViewModel Map_RechteGruppe_DetailsRechteGruppeViewModel(RechteGruppe rechteGruppe)
        {
            return Mapper.Map<DetailsRechteGruppeViewModel>(rechteGruppe);
        }

        public RechteGruppe Map_DeleteRechteGruppeViewModel_RechteGruppe(DeleteRechteGruppeViewModel deleteRechteGruppeViewModel)
        {
            return Mapper.Map<RechteGruppe>(deleteRechteGruppeViewModel);
        }

        public DeleteRechteGruppeViewModel Map_RechteGruppe_DeleteRechteGruppeViewModel(RechteGruppe rechteGruppe)
        {
            return Mapper.Map<DeleteRechteGruppeViewModel>(rechteGruppe);
        }
    }
}
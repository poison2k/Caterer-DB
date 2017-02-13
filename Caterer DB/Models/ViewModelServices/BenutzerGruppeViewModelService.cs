using AutoMapper;
using Caterer_DB.Models.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerGruppeViewModelService : IBenutzerGruppeViewModelService
    {

        private IMapper Mapper { get; set; }


        public BenutzerGruppeViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<editBenutzerGruppeViewModel, CreateBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<editBenutzerGruppeViewModel, EditBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<editBenutzerGruppeViewModel, DeleteBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<editBenutzerGruppeViewModel, DetailsBenutzerGruppeViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public editBenutzerGruppeViewModel Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(CreateBenutzerGruppeViewModel createBenutzerGruppeViewModel)
        {
            return Mapper.Map<editBenutzerGruppeViewModel>(createBenutzerGruppeViewModel);
        }

        public editBenutzerGruppeViewModel Map_EditBenutzerGruppeViewModel_BenutzerGruppe(EditBenutzerGruppeViewModel editBenutzerGruppeViewModel)
        {
            return Mapper.Map<editBenutzerGruppeViewModel>(editBenutzerGruppeViewModel);

        }

        public editBenutzerGruppeViewModel Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe(DeleteBenutzerGruppeViewModel deleteBenutzerGruppeViewModel)
        {
            return Mapper.Map<editBenutzerGruppeViewModel>(deleteBenutzerGruppeViewModel);
        }

        public EditBenutzerGruppeViewModel Map_BenutzerGruppe_EditBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe)
        {
            return Mapper.Map<EditBenutzerGruppeViewModel>(benutzerGruppe);
        }

        public DetailsBenutzerGruppeViewModel Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe)
        {
            return Mapper.Map<DetailsBenutzerGruppeViewModel>(benutzerGruppe);
        }



        public DeleteBenutzerGruppeViewModel Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(editBenutzerGruppeViewModel benutzerGruppe)
        {
            return Mapper.Map<DeleteBenutzerGruppeViewModel>(benutzerGruppe);
        }
    }
}
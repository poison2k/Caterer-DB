using AutoMapper;
using Caterer_DB.Models.Interfaces;
using Caterer_DB.ViewModel;
using Common.Model;

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
                cfg.CreateMap<BenutzerGruppe, CreateBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<BenutzerGruppe, EditBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<BenutzerGruppe, DeleteBenutzerGruppeViewModel>().ReverseMap();
                cfg.CreateMap<BenutzerGruppe, DetailsBenutzerGruppeViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public BenutzerGruppe Map_CreateBenutzerGruppeViewModel_BenutzerGruppe(CreateBenutzerGruppeViewModel createBenutzerGruppeViewModel)
        {
            return Mapper.Map<BenutzerGruppe>(createBenutzerGruppeViewModel);
        }

        public BenutzerGruppe Map_EditBenutzerGruppeViewModel_BenutzerGruppe(EditBenutzerGruppeViewModel editBenutzerGruppeViewModel)
        {
            return Mapper.Map<BenutzerGruppe>(editBenutzerGruppeViewModel);
        }

        public BenutzerGruppe Map_DeleteBenutzerGruppeViewModel_BenutzerGruppe(DeleteBenutzerGruppeViewModel deleteBenutzerGruppeViewModel)
        {
            return Mapper.Map<BenutzerGruppe>(deleteBenutzerGruppeViewModel);
        }

        public EditBenutzerGruppeViewModel Map_BenutzerGruppe_EditBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe)
        {
            return Mapper.Map<EditBenutzerGruppeViewModel>(benutzerGruppe);
        }

        public DetailsBenutzerGruppeViewModel Map_BenutzerGruppe_DetailsBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe)
        {
            return Mapper.Map<DetailsBenutzerGruppeViewModel>(benutzerGruppe);
        }

        public DeleteBenutzerGruppeViewModel Map_BenutzerGruppe_DeleteBenutzerGruppeViewModel(BenutzerGruppe benutzerGruppe)
        {
            return Mapper.Map<DeleteBenutzerGruppeViewModel>(benutzerGruppe);
        }
    }
}
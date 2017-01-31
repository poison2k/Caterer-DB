using AutoMapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerViewModelService
    {



        private IMapper Mapper { get; set; }


        public BenutzerViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Benutzer, CreateBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, CreateBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, EditBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DeleteBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DetailsBenutzerViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public Benutzer Map_CreateBenutzerViewModel_Benutzer(CreateBenutzerViewModel createBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(createBenutzerViewModel);
        }

        public Benutzer Map_EditBenutzerViewModel_Benutzer(EditBenutzerViewModel editBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(editBenutzerViewModel);
        }

        public EditBenutzerViewModel Map_Benutzer_EditBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<EditBenutzerViewModel>(benutzer);
        }

        public DetailsBenutzerViewModel Map_Benutzer_DetailsBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<DetailsBenutzerViewModel>(benutzer);
        }

        public Benutzer Map_DeleteBenutzerViewModel_Benutzer(DeleteBenutzerViewModel deleteBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(deleteBenutzerViewModel);
        }

        public DeleteBenutzerViewModel Map_Benutzer_DeleteBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<DeleteBenutzerViewModel>(benutzer);
        }

    }
}
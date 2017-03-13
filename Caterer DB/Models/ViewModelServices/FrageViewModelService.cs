using AutoMapper;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models.ViewModelServices
{
    public class FrageViewModelService : IFrageViewModelService
    {
        private IMapper Mapper { get; set; }


        public FrageViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Frage, CreateFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, EditFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, DeleteFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, DetailsFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, BearbeiteFrageViewModel>().ReverseMap();

            });

            Mapper = config.CreateMapper();

        }

        public Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel)
        {
            return Mapper.Map<Frage>(createFrageViewModel);
        }

        public Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel)
        {
            return Mapper.Map<Frage>(editFrageViewModel);
        }

        public Frage Map_BearbeiteFrageViewModel_Frage(BearbeiteFrageViewModel bearbeiteFrageViewModel)
        {
            return Mapper.Map<Frage>(bearbeiteFrageViewModel);
        }

        public EditFrageViewModel Map_Frage_EditFrageViewModel(Frage Frage)
        {
            return Mapper.Map<EditFrageViewModel>(Frage);
        }

        public DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage Frage)
        {
            return Mapper.Map<DetailsFrageViewModel>(Frage);
        }

        public Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel)
        {
            return Mapper.Map<Frage>(deleteFrageViewModel);
        }

        public DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage Frage)
        {
            return Mapper.Map<DeleteFrageViewModel>(Frage);
        }

        public BearbeiteFrageViewModel Map_Frage_BearbeiteFrageViewModel(Frage Frage)
        {
            return Mapper.Map<BearbeiteFrageViewModel>(Frage);
        }

    }
}
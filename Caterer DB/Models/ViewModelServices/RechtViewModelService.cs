using Caterer_DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Model;
using AutoMapper;

namespace Caterer_DB.Models.ViewModelServices
{
    public class RechtViewModelService : IRechtViewModelService
    {
        private IMapper Mapper { get; set; }


        public RechtViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Recht, CreateRechtViewModel>().ReverseMap();
                cfg.CreateMap<Recht, EditRechtViewModel>().ReverseMap();
                cfg.CreateMap<Recht, DeleteRechtViewModel>().ReverseMap();
                cfg.CreateMap<Recht, DetailsRechtViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public Recht Map_CreateRechtViewModel_Recht(CreateRechtViewModel createRechtViewModel)
        {
            return Mapper.Map<Recht>(createRechtViewModel);
        }

        public Recht Map_EditRechtViewModel_Recht(EditRechtViewModel editRechtViewModel)
        {
            return Mapper.Map<Recht>(editRechtViewModel);
        }

        public EditRechtViewModel Map_Recht_EditRechtViewModel(Recht recht)
        {
            return Mapper.Map<EditRechtViewModel>(recht);
        }

        public DetailsRechtViewModel Map_Recht_DetailsRechtViewModel(Recht recht)
        {
            return Mapper.Map<DetailsRechtViewModel>(recht);
        }

        public Recht Map_DeleteRechtViewModel_Recht(DeleteRechtViewModel deleteRechtViewModel)
        {
            return Mapper.Map<Recht>(deleteRechtViewModel);
        }

        public DeleteRechtViewModel Map_Recht_DeleteRechtViewModel(Recht recht)
        {
            return Mapper.Map<DeleteRechtViewModel>(recht);
        }
    }
}
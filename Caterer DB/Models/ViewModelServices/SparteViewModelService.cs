using AutoMapper;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caterer_DB.Models.ViewModelServices
{
    public class SparteViewModelService : ISparteViewModelService
    {
        private IMapper Mapper { get; set; }


        public SparteViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Sparte, CreateSparteViewModel>().ReverseMap();
                cfg.CreateMap<Sparte, EditSparteViewModel>().ReverseMap();
                cfg.CreateMap<Sparte, DeleteSparteViewModel>().ReverseMap();
                cfg.CreateMap<Sparte, DetailsSparteViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public Sparte Map_CreateSparteViewModel_Sparte(CreateSparteViewModel createSparteViewModel)
        {
            return Mapper.Map<Sparte>(createSparteViewModel);
        }

        public Sparte Map_EditSparteViewModel_Sparte(EditSparteViewModel editSparteViewModel)
        {
            return Mapper.Map<Sparte>(editSparteViewModel);
        }

        public EditSparteViewModel Map_Sparte_EditSparteViewModel(Sparte sparte)
        {
            return Mapper.Map<EditSparteViewModel>(sparte);
        }

        public DetailsSparteViewModel Map_Sparte_DetailsSparteViewModel(Sparte sparte)
        {
            return Mapper.Map<DetailsSparteViewModel>(sparte);
        }

        public Sparte Map_DeleteSparteViewModel_Sparte(DeleteSparteViewModel deleteSparteViewModel)
        {
            return Mapper.Map<Sparte>(deleteSparteViewModel);
        }

        public DeleteSparteViewModel Map_Sparte_DeleteSparteViewModel(Sparte sparte)
        {
            return Mapper.Map<DeleteSparteViewModel>(sparte);
        }

    }
}
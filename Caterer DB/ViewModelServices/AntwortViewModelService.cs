using AutoMapper;
using Caterer_DB.Interfaces;
using Caterer_DB.ViewModel;
using Common.Model;

namespace Caterer_DB.Models.ViewModelServices
{
    public class AntwortViewModelService : IAntwortViewModelService
    {
        private IMapper Mapper { get; set; }

        public AntwortViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Antwort, CreateAntwortViewModel>().ReverseMap();
                cfg.CreateMap<Antwort, EditAntwortViewModel>().ReverseMap();
                cfg.CreateMap<Antwort, DeleteAntwortViewModel>().ReverseMap();
                cfg.CreateMap<Antwort, DetailsAntwortViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public Antwort Map_CreateAntwortViewModel_Antwort(CreateAntwortViewModel createAntwortViewModel)
        {
            return Mapper.Map<Antwort>(createAntwortViewModel);
        }

        public Antwort Map_EditAntwortViewModel_Antwort(EditAntwortViewModel editAntwortViewModel)
        {
            return Mapper.Map<Antwort>(editAntwortViewModel);
        }

        public EditAntwortViewModel Map_Antwort_EditAntwortViewModel(Antwort antwort)
        {
            return Mapper.Map<EditAntwortViewModel>(antwort);
        }

        public DetailsAntwortViewModel Map_Antwort_DetailsAntwortViewModel(Antwort antwort)
        {
            return Mapper.Map<DetailsAntwortViewModel>(antwort);
        }

        public Antwort Map_DeleteAntwortViewModel_Antwort(DeleteAntwortViewModel deleteAntwortViewModel)
        {
            return Mapper.Map<Antwort>(deleteAntwortViewModel);
        }

        public DeleteAntwortViewModel Map_Antwort_DeleteAntwortViewModel(Antwort antwort)
        {
            return Mapper.Map<DeleteAntwortViewModel>(antwort);
        }
    }
}
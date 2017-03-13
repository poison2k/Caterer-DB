using AutoMapper;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;

namespace Caterer_DB.Models.ViewModelServices
{

    public class FragebogenViewModelService : IFragebogenViewModelService
    {
        private IMapper Mapper { get; set; }

        public FragebogenViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                    cfg.CreateMap<FragebogenViewModelService, FragebogenViewModelService>().ReverseMap();
                });

            Mapper = config.CreateMapper();
        }

        public FragebogenViewModelService Map_FragebogenViewModelService_FragebogenViewModelService(FragebogenViewModelService fragebogenViewModelService)
        {
            return Mapper.Map<FragebogenViewModelService>(fragebogenViewModelService);
        }

        public BearbeiteFragebogenViewModel Map_Fragen_BearbeiteFragebogenViewModel(List<Frage> fragen)
        {
            var bearbeiteFragebogenViewModel = new BearbeiteFragebogenViewModel() {
                Fragen = fragen
            };
            return bearbeiteFragebogenViewModel;
          
        }
    }
}

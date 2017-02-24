using System;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using AutoMapper;

namespace Caterer_DB.Models.ViewModelServices
{
    public class ConfigViewModelService : IConfigViewModelService
    {
        private IMapper Mapper { get; set; }


        public ConfigViewModelService()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Config, EditConfigViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();

        }

        public EditConfigViewModel Map_Config_EditConfigViewModel(Config config)
        {
            return Mapper.Map<EditConfigViewModel>(config); 
        }

        public Config Map_EditConfigViewModel_Config(EditConfigViewModel editConfigViewModel)
        {
            return Mapper.Map<Config>(editConfigViewModel);
        }
    }
}
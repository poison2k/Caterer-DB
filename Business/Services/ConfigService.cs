﻿using Business.Interfaces;
using Common.Model;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class ConfigService : IConfigService
    {
        private IConfigRepository ConfigRepository { get; set; }

        public ConfigService(IConfigRepository configRepository)
        {
            ConfigRepository = configRepository;
        }

        public void AddConfig(Config config)
        {
            ConfigRepository.AddConfig(config);
        }

        public void EditConfig(Config config)
        {
            ConfigRepository.EditConfig(config);
        }

        public Config GetConfig()
        {
            return ConfigRepository.GetConfig();
        }
    }
}
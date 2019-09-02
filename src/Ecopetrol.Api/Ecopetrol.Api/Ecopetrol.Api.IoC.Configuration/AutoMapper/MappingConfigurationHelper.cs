﻿using AutoMapper;
using Ecopetrol.Api.IoC.Configuration.AutoMapper.Profiles;

namespace Ecopetrol.Api.IoC.Configuration.AutoMapper
{
    public static class MappingConfigurationsHelper
    {
        public static void ConfigureMapper()
        {
            //Mapping settings
            Mapper.Reset();//required because .NET Core DI engine calls the init many times (so, it loads mappings many times). Solution from Jimmy Bogard.

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<APIMappingProfile>();
                cfg.AddProfile<ServicesMappingProfile>();
            }
                );
        }
    }
}

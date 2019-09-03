using AutoMapper;
using Ecopetrol.Api.IoC.Configuration.AutoMapper.Profiles;

namespace Ecopetrol.Api.IoC.Configuration.AutoMapper
{
    public static class MappingConfigurationsHelper
    {
        public static IMapper ConfigureMapper()
        {
            //Mapping settings
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<APIMappingProfile>();
                cfg.AddProfile<ServicesMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}

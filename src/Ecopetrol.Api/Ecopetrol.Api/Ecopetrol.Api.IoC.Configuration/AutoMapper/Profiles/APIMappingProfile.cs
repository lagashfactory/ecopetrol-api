using AutoMapper;
using DC = Ecopetrol.Api.API.DataContracts;
using S = Ecopetrol.Api.Services.Model;

namespace Ecopetrol.Api.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.FAQ, S.FAQ>().ReverseMap();
            CreateMap<DC.Adress, S.Adress>().ReverseMap();
        }
    }
}

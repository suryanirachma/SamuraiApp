using AutoMapper;
using SamuraiApp.API.DTO.Elemens;
using SamuraiAppDomain;

namespace SamuraiApp.API.Profiles
{
    public class ElemenProfile : Profile
    {
        public ElemenProfile()
        {
            CreateMap<Elemen, ElemenDTO>();
            CreateMap<ElemenCreateDTO, Elemen>();
        }

    }
}

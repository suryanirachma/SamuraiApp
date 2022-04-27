using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.API.DTO.Samurais;
using SamuraiAppDomain;

namespace SamuraiApp.API.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<SamuraiCreateDTO,Samurai>();

            CreateMap<CreateSamuraiWithPedangDTO, Samurai>();
            CreateMap<Samurai, ViewSamuraiWithPedangDTO>();
            CreateMap<Samurai, ViewSamuraiWithPedangAndElemenDTO>();
            CreateMap<CreateSamuraiWithPedangAndElemenDTO, Samurai>();
        }

    }
}

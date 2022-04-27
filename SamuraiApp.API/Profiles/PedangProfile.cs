using AutoMapper;
using SamuraiApp.API.DTO.Pedangs;
using SamuraiApp.API.DTO.Samurais;
using SamuraiAppDomain;

namespace SamuraiApp.API.Profiles
{
    public class PedangProfile : Profile
    {
        public PedangProfile()
        {
            CreateMap<Pedang, PedangDTO>();
            CreateMap<PedangCreateDTO, Pedang>();
            CreateMap<CreatePedangSamuraiDTO, Pedang>();
            CreateMap<CreatePedangWithElemenDTO, Pedang>();
            CreateMap<Pedang, ViewPedangWithElemenDTO>();
            CreateMap<CreatePedangElemenSamuraiDTO, Pedang>();
    //elemennya ga perlu dimapping, karna udah di inisialisasi di dto create pedang with elemen dalam bentuk list
        }

    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles
{
    public class TypeTransportProfile : Profile
    {
        public TypeTransportProfile()
        {
            CreateMap<TypeTransport, TypeTransportDTO>().ReverseMap();
            CreateMap<TypeTransportDTO, TypeTransportViewModel>().ReverseMap();
        }
    }
}

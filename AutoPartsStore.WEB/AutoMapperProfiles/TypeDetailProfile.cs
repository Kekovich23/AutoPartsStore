using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class TypeDetailProfile : Profile {
        public TypeDetailProfile() {
            CreateMap<TypeDetail, TypeDetailDTO>().ReverseMap();
            CreateMap<TypeDetailDTO, TypeDetailViewModel>().ReverseMap();
        }
    }
}

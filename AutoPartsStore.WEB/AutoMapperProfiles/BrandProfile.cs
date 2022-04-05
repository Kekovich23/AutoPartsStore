using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class BrandProfile : Profile {
        public BrandProfile() {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BrandDTO, BrandViewModel>().ReverseMap();
        }
    }
}

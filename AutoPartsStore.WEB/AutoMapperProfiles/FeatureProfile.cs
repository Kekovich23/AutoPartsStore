using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class FeatureProfile : Profile{
        public FeatureProfile() {
            CreateMap<Feature, FeatureDTO>().ReverseMap();
            CreateMap<FeatureDTO, FeatureViewModel>().ReverseMap();
        }
    }
}

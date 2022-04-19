using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class SectionProfile : Profile{
        public SectionProfile() {
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<SectionDTO, SectionViewModel>().ReverseMap();
        }
    }
}

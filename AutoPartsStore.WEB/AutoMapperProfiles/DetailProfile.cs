using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class DetailProfile : Profile{
        public DetailProfile() {
            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<DetailDTO, DetailViewModel>().ReverseMap();
        }
    }
}

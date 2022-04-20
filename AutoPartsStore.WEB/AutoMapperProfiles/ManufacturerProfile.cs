using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class ManufacturerProfile : Profile{
        public ManufacturerProfile() {
            CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            CreateMap<ManufacturerDTO, ManufacturerViewModel>().ReverseMap();
        }
    }
}

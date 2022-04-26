using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class StatusProfile : Profile {
        public StatusProfile() {
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<StatusDTO, StatusViewModel>().ReverseMap();
        }
    }
}

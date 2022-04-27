using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class ModificationProfile : Profile{
        public ModificationProfile() {
            CreateMap<Modification, ModificationDTO>().ReverseMap();
            CreateMap<ModificationDTO, ModificationViewModel>().ReverseMap();
            CreateMap<SelectableModificationViewModel, ModificationDTO>();
        }
    }
}

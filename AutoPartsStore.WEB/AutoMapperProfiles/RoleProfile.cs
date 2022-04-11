using AutoMapper;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class RoleProfile : Profile {
        public RoleProfile() {
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}

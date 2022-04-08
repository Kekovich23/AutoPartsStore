using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
        }
    }
}

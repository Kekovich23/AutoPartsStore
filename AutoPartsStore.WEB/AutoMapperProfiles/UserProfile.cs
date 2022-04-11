using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
        }
    }
}

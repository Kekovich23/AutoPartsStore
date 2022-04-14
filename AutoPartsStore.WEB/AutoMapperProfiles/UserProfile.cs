using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models.User;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.WEB.AutoMapperProfiles {
    public class UserProfile : Profile {
        private readonly UserManager<User> _userManager;
        public UserProfile(UserManager<User> userManager) {
            _userManager = userManager;

            CreateMap<User, UserDTO>().ForMember(s => s.Role, opt => opt.MapFrom(src => _userManager.GetRolesAsync(src).Result.FirstOrDefault()));
            CreateMap<UserDTO, User>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<CreateUserViewModel, UserDTO>().ForMember(s => s.NewPassword, opt => opt.MapFrom(src => src.Password));
            CreateMap<UserViewModel, UserDTO>();
        }
    }
}

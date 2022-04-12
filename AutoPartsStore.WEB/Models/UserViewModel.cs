using AutoMapper;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.WEB.Models {
    public class UserViewModel : BaseEntityViewModel<Guid> {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }
    }
}

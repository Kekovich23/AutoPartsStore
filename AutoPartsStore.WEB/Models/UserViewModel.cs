using AutoMapper;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.WEB.Models {
    public class UserViewModel : BaseEntityViewModel<Guid> {
        public string UserName { get; set; }
        public string Email { get; set; }
        public RoleViewModel Role { get; set; }
        public IEnumerable<RoleViewModel> AllRoles { get; set; }
        public bool IsChecked(RoleViewModel roleViewModel) {
            if (roleViewModel == Role) {
                return true;
            }
            else {
                return false;
            }
        }
        public UserViewModel() {

        }
        public UserViewModel(RoleManager<Role> roleManager, IMapper mapper) {
            AllRoles = mapper.Map<IEnumerable<RoleViewModel>>(roleManager.Roles);
        }
    }
}

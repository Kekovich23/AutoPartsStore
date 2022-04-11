using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.WEB.Models {
    public class ChangeRoleViewModel {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel() {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}

using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models.User {
    public class UserViewModel : BaseEntityViewModel<Guid>{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

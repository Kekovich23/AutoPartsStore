using AutoPartsStore.AN.Entities;
using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class UserViewModel : BaseEntityViewModel<string> {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<string> Role { get; set; }
    }
}

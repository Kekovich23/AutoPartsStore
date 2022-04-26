using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models.User {
    public class UserCartViewModel : BaseEntityViewModel<Guid>{
        public List<DetailInCartViewModel> Details { get; set; }
    }
}

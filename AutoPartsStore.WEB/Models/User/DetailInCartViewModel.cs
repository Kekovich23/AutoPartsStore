using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models.User {
    public class DetailInCartViewModel : BaseEntityViewModel{
        public DetailViewModel Detail { get; set; }
        public int Amount { get; set; }
    }
}

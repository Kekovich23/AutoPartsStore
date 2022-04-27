using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class DetailViewModel : BaseEntityViewModel<Guid> {     
        public Guid ManufacturerId { get; set; }
        public int TypeDetailId { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
        public TypeDetailViewModel TypeDetail { get; set; }
        public IList<SelectableModificationViewModel> Modifications { get; set; }
    }
}

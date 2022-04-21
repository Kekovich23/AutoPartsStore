using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class DetailViewModel : BaseEntityViewModel<Guid>{
        //public int TypeDetailId { get; set; }
        //public Guid ManufacturerId { get; set; }
        public TypeDetailViewModel TypeDetail { get; set; }
        public ManufacturerViewModel Manufacturer { get; set; }
        public SetModificationViewModel SetModification { get; set; }
    }
}

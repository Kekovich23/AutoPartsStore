using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class DetailViewModel : BaseEntityViewModel<Guid> {        
        public ManufacturerViewModel Manufacturer { get; set; }
        public TypeDetailViewModel TypeDetail { get; set; }
        public IEnumerable<ModificationViewModel> AllModifications { get; set; }
        public IEnumerable<ModificationViewModel> SelectedModifications { get; set; }
    }
}

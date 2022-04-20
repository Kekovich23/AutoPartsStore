using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class ManufacturerViewModel : BaseEntityViewModel<Guid> {
        public string Name { get; set; }
    }
}

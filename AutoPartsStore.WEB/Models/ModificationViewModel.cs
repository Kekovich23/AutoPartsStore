using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class ModificationViewModel : BaseEntityViewModel<Guid> {
        public string Name { get; set; }
        public Guid ModelId { get; set; }
    }
}

using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class TypeDetailViewModel : BaseEntityViewModel<int> {
        public string Name { get; set; }
        public int SectionId { get; set; }
    }
}

using AutoPartsStore.BLL.Filters.Base;

namespace AutoPartsStore.BLL.Filters {
    public class TypeDetailFilter : BaseFilter {
        public string Name { get; set; }
        public int SectionId { get; set; }
    }
}

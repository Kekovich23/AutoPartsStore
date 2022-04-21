using AutoPartsStore.BLL.Filters.Base;

namespace AutoPartsStore.BLL.Filters {
    public class ModificationFilter : BaseFilter{
        public string Name { get; set; }
        public Guid? ModelId { get; set; }
    }
}

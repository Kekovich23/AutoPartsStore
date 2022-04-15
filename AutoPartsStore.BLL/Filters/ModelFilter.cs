using AutoPartsStore.BLL.Filters.Base;

namespace AutoPartsStore.BLL.Filters {
    public class ModelFilter : BaseFilter {
        public string Name { get; set; }
        public Guid? BrandId { get; set; }
        public int? TypeTransportId { get; set; }
    }
}

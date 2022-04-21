using AutoPartsStore.BLL.Filters.Base;

namespace AutoPartsStore.BLL.Filters {
    public class DetailFilter : BaseFilter{
        public int TypeDetailId { get; set; }
        public Guid? ManufacturerId { get; set; }
    }
}

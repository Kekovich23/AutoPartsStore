using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class ModelViewModel : BaseEntityViewModel<Guid> {
        public string? Name { get; set; }
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public int TypeTransportId { get; set; }
        public string? TypeTransportName { get; set; }
    }
}

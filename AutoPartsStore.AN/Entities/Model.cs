using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Model : BaseEntity<Guid> {
        public string? Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid TypeTransportId { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual TypeTransport? TypeTransport { get; set; }
    }
}

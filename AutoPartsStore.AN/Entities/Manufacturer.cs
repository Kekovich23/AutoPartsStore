using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Manufacturer : BaseEntity<Guid> {
        public string? Name { get; set; }
    }
}

using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Manufacturer : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

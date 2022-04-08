using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Brand : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

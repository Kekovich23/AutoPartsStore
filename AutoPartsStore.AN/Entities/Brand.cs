using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Brand : BaseEntity<Guid> {
        public string Name { get; set; }
    }
}

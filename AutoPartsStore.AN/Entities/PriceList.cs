using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class PriceList : BaseEntity<Guid> {
        public Guid DetailId { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
        public virtual Detail Detail { get; set; }
    }
}

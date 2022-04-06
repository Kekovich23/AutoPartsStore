using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Status : BaseEntity<int> {
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.AN.Entities.Complex;

namespace AutoPartsStore.AN.Entities {
    public class Order : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}

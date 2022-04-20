using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Detail : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public Guid ManufacturerId { get; set; }
        public int TypeDetailId { get; set; }

        public virtual TypeDetail TypeDetail { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Modification> Modifications { get; set; }
    }
}

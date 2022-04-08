using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Customer : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Modification> Modifications { get; set; }
        public virtual ICollection<PriceList> PriceDetails { get; set; }

    }
}

﻿using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Order : BaseEntity<Guid> {
        public Guid CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Status> Status { get; set; }
        public virtual ICollection<PriceList> PriceDetail { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

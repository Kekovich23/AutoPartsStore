namespace AutoPartsStore.AN.Entities.Complex {
    public class OrderStatus {
        public Guid OrderId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Status Status { get; set; }
    }
}

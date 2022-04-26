namespace AutoPartsStore.AN.Entities.Complex {
    public class OrderDetail {
        public Guid DetailId { get; set; }
        public Guid OrderId { get; set; }
        public int Amount { get; set; }

        public virtual Detail Detail { get; set; }
        public virtual Order Order { get; set; }
    }
}

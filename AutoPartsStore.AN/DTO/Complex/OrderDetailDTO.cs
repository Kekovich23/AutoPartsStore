namespace AutoPartsStore.AN.DTO.Complex {
    public class OrderDetailDTO {
        public Guid DetailId { get; set; }
        public Guid OrderId { get; set; }
        public int Amount { get; set; }

        public DetailDTO Detail { get; set; }
        public OrderDTO Order { get; set; }
    }
}

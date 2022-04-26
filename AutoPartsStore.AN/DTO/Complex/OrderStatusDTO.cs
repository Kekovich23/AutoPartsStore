namespace AutoPartsStore.AN.DTO.Complex {
    public class OrderStatusDTO {
        public Guid OrderId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public OrderDTO Order { get; set; }
        public StatusDTO Status { get; set; }
    }
}

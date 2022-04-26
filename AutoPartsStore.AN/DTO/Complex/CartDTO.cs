namespace AutoPartsStore.AN.DTO.Complex {
    public class CartDTO {
        public Guid DetailId { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }

        public UserDTO User { get; set; }
        public DetailDTO Detail { get; set; }
    }
}

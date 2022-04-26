namespace AutoPartsStore.AN.DTO {
    public class UserCartDTO {
        public Guid UserId { get; set; }
        public List<DetailInCartDTO> Details { get; set; }
    }
}

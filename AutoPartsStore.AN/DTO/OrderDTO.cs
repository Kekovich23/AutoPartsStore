namespace AutoPartsStore.AN.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

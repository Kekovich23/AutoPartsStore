namespace AutoPartsStore.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<Status>? Status { get; set; }
        public ICollection<PriceList>? PriceDetail { get; set; }
        public User? User { get; set; }
        public DateTime Created { get; set; }
    }
}

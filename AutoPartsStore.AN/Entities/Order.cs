namespace AutoPartsStore.AN.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public virtual ICollection<Status>? Status { get; set; }
        public virtual ICollection<PriceList>? PriceDetail { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Guid CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

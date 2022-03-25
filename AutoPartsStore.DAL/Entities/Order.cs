namespace AutoPartsStore.DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public virtual ICollection<Status>? Status { get; set; }
        public virtual ICollection<PriceList>? PriceDetail { get; set; }
        public virtual User? User { get; set; }
        public virtual Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

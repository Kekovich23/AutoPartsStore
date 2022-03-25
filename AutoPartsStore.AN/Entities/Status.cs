namespace AutoPartsStore.AN.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}

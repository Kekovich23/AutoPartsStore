namespace AutoPartsStore.DAL.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}

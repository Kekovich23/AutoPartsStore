namespace AutoPartsStore.AN.Entities
{
    public class Modification
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ModelId { get; set; }
        public virtual Model? Model { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
        public virtual ICollection<Detail>? Details { get; set; }
    }
}

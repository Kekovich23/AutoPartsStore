namespace AutoPartsStore.AN.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public virtual ICollection<Modification>? Modifications { get; set; }
        public virtual ICollection<PriceList>? PriceDetails { get; set; }
        
    }
}

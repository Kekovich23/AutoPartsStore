namespace AutoPartsStore.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Modification>? Modifications { get; set; }
        public ICollection<PriceList>? PriceDetails { get; set; }
        
    }
}

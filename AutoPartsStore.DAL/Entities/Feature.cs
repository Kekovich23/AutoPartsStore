namespace AutoPartsStore.DAL.Entities
{
    public class Feature
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public TypeDetail? TypeDetail { get; set; }
        public ICollection<Detail>? Details { get; set; }
    }
}

namespace AutoPartsStore.AN.Entities
{
    public class Feature
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid TypeDetailId { get; set; }
        public virtual TypeDetail? TypeDetail { get; set; }        
        public virtual ICollection<Detail>? Details { get; set; }
    }
}

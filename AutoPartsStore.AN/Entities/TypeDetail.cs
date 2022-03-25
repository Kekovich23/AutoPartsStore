namespace AutoPartsStore.AN.Entities
{
    public class TypeDetail
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Guid SectionId { get; set; }
    }
}

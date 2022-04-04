namespace AutoPartsStore.AN.Entities
{
    public class TypeDetail
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid SectionId { get; set; }
        public virtual Section? Section { get; set; }
    }
}

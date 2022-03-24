namespace AutoPartsStore.DAL.Entities
{
    public class TypeDetail
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Section? Section { get; set; }
    }
}

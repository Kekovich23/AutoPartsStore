namespace AutoPartsStore.AN.Entities
{
    public class ModelDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid TypeTransportId { get; set; }
    }
}

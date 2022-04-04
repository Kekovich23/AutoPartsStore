namespace AutoPartsStore.AN.DTO
{
    public class ModelDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public BrandDTO Brand { get;  set; }
        public TypeTransportDTO TypeTransport { get; set; }
    }
}

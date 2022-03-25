namespace AutoPartsStore.AN.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Guid BrandId { get; set; }
        public virtual TypeTransport? TypeTransport { get; set; }
        public virtual Guid TypeTransportId { get; set; }
    }
}

namespace AutoPartsStore.DAL.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Brand? Brand { get; set; }
        public TypeTransport? TypeTransport { get; set; }
    }
}

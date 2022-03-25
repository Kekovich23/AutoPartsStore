namespace AutoPartsStore.AN.Entities
{
    public class PriceListDTO
    {
        public Guid Id { get; set; }
        public Guid DetailId { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
    }
}

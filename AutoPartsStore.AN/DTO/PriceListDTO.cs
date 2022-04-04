namespace AutoPartsStore.AN.DTO
{
    public class PriceListDTO
    {
        public Guid Id { get; set; }
        public DetailDTO Detail { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
    }
}

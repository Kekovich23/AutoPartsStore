namespace AutoPartsStore.AN.Entities
{
    public class PriceList
    {
        public Guid Id { get; set; }
        public Guid DetailId { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
        public virtual Detail? Detail { get; set; }
    }
}

namespace AutoPartsStore.DAL.Entities
{
    public class PriceList
    {
        public Guid Id { get; set; }
        public Detail? Detail { get; set; }
        public uint Price { get; set; }
        public uint Number { get; set; }
    }
}

namespace AutoPartsStore.DAL.Entities
{
    public class Detail
    {
        public Guid Id { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public ICollection<Feature>? Features { get; set; }
        public ICollection<Modification>? Modifications { get; set; }
    }
}

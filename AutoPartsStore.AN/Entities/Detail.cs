namespace AutoPartsStore.AN.Entities
{
    public class Detail
    {
        public Guid Id { get; set; }
        public Guid ManufacturerId { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }        
        public virtual ICollection<Feature>? Features { get; set; }
        public virtual ICollection<Modification>? Modifications { get; set; }
    }
}

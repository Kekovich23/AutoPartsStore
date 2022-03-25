namespace AutoPartsStore.AN.Entities
{
    public class Modification
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual Model? Model { get; set; }
        public virtual Guid ModelId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Detail>? Details { get; set; }
    }
}

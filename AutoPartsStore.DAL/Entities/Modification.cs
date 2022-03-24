namespace AutoPartsStore.DAL.Entities
{
    public class Modification
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Model? Model { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Detail>? Details { get; set; }
    }
}

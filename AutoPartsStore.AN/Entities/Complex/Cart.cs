namespace AutoPartsStore.AN.Entities.Complex {
    public class Cart {        
        public Guid DetailId { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }

        public virtual User User { get; set; }
        public virtual Detail Detail { get; set; }
    }
}

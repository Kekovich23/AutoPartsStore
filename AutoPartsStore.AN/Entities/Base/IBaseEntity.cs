namespace AutoPartsStore.AN.Entities.Base {
    public interface IBaseEntity<TKey> {
        public TKey Id { get; set; }
    }
}

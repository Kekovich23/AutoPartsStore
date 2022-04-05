namespace AutoPartsStore.WEB.Models.Base {
    public class BaseEntityViewModel<TKey> {
        public TKey? Id { get; set; }
        public bool IsNew {
            get {
                return Id.Equals(default(TKey));
            }
        }
    }
}

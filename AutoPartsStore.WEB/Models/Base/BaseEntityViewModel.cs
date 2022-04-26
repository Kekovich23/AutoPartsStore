namespace AutoPartsStore.WEB.Models.Base {
    public class BaseEntityViewModel {

    }

    public class BaseEntityViewModel<TKey> : BaseEntityViewModel{
        public TKey? Id { get; set; }
        public bool IsNew {
            get {
                return Id.Equals(default(TKey));
            }
        }
    }
}

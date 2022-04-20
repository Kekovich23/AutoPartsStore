using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class DetailFeature : IBaseEntity<Guid> {
        public Guid Id { get; set; }
        public Guid DeatailId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }

        public virtual Detail Detail { get; set; }
        public virtual Feature Feature { get; set; }
    }
}

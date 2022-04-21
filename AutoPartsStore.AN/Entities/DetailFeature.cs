using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class DetailFeature {        
        public Guid DetailId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }

        public virtual Detail Detail { get; set; }
        public virtual Feature Feature { get; set; }
    }
}

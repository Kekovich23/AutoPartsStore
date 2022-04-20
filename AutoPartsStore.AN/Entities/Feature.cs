using AutoPartsStore.AN.Entities.Base;

namespace AutoPartsStore.AN.Entities {
    public class Feature : IBaseEntity<int> {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

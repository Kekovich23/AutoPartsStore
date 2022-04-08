using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class ModificationDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ModelDTO Model { get; set; }
    }
}

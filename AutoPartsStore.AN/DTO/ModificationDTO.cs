using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class ModificationDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ModelId { get; set; }
        public ModelDTO Model { get; set; }
        public ICollection<DetailDTO> Details { get; set; }
    }
}

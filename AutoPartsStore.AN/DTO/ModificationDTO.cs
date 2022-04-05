using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class ModificationDTO : BaseEntityDTO<Guid> {
        public string? Name { get; set; }
        public ModelDTO? Model { get; set; }
    }
}

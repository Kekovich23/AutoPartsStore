using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class ManufacturerDTO : BaseEntityDTO<Guid> {
        public string? Name { get; set; }
    }
}

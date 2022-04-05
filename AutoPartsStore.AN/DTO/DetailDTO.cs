using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class DetailDTO : BaseEntityDTO<Guid> {
        public ManufacturerDTO? Manufacturer { get; set; }
    }
}

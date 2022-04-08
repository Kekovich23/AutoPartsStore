using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class DetailDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }
    }
}

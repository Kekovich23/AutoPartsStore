using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class ModelDTO : BaseEntityDTO<Guid> {
        public string Name { get; set; }
        public BrandDTO Brand { get; set; }
        public TypeTransportDTO TypeTransport { get; set; }
    }
}

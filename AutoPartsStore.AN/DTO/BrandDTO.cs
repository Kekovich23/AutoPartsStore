using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class BrandDTO : BaseEntityDTO<Guid> {
        public string Name { get; set; }
    }
}

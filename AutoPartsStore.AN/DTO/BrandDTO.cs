using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class BrandDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

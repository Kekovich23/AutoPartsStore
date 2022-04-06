using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class PriceListDTO : BaseEntityDTO<Guid> {
        public DetailDTO Detail { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
    }
}

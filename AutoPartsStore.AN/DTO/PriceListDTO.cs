using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class PriceListDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public DetailDTO Detail { get; set; }
        public uint Price { get; set; }
        public uint Count { get; set; }
    }
}

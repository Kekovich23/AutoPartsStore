using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class TypeTransportDTO : IBaseEntityDTO<int> {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

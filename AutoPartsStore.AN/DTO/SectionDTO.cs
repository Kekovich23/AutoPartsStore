using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class SectionDTO : IBaseEntityDTO<int> {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

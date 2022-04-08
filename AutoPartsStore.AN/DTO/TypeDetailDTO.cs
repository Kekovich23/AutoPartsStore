using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class TypeDetailDTO : IBaseEntityDTO<int> {
        public int Id { get; set; }
        public string Name { get; set; }
        public SectionDTO Section { get; set; }
    }
}

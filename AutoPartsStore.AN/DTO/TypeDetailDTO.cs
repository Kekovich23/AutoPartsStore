using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class TypeDetailDTO : BaseEntityDTO<int> {
        public string? Name { get; set; }
        public SectionDTO? Section { get; set; }
    }
}

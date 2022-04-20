using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class DetailFeatureDTO : IBaseEntityDTO<Guid>{
        public Guid Id { get; set; }
        public Guid DetailId { get; set; }
        public int TypeDetailId { get; set; }
        public string Value { get; set; }
        public DetailDTO Detail { get; set; }
        public TypeDetailDTO TypeDetail { get; set; }
    }
}

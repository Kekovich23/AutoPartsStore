using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class DetailDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public Guid ManufacturerId { get; set; }
        public int TypeDetailId { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }
        public TypeDetailDTO TypeDetail { get; set; }
        public ICollection<ModificationDTO> Modifications { get; set; }
    }
}

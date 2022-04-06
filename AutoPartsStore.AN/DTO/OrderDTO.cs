using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class OrderDTO : BaseEntityDTO<Guid> {
        public CustomerDTO Customer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

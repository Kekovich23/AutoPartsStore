using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.DTO.Complex;

namespace AutoPartsStore.AN.DTO {
    public class OrderDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<DetailDTO> Details { get; set; }
        public IEnumerable<OrderDetailDTO> OrderDetails { get; set; }
        public IEnumerable<StatusDTO> Statuses { get; set; }
    }
}

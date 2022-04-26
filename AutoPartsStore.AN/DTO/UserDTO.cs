using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.DTO.Complex;

namespace AutoPartsStore.AN.DTO {
    public class UserDTO : IBaseEntityDTO<Guid> {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public IEnumerable<DetailDTO> Details { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
        public IEnumerable<CartDTO> Carts { get; set; }
    }
}

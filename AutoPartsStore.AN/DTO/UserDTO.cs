using AutoPartsStore.AN.DTO.Base;

namespace AutoPartsStore.AN.DTO {
    public class UserDTO : IBaseEntityDTO<string> {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<string> Role { get; set; }
    }
}

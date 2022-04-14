namespace AutoPartsStore.AN.DTO {
    public class ChangePasswordUserDTO {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

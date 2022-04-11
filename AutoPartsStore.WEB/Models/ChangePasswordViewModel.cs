namespace AutoPartsStore.WEB.Models {
    public class ChangePasswordViewModel {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}

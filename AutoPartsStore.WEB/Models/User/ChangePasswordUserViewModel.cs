namespace AutoPartsStore.WEB.Models {
    public class ChangePasswordUserViewModel {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

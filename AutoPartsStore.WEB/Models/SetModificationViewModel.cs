using AutoPartsStore.AN.DTO;

namespace AutoPartsStore.WEB.Models {
    public class SetModificationViewModel {
        public List<ModificationDTO> AllModifications { get; set; }
        public List<ModificationDTO> SelectedModifications { get; set; }
    }
}

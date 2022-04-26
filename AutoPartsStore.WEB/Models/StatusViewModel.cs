using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class StatusViewModel : BaseEntityViewModel<int> {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

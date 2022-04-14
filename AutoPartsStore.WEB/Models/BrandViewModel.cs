using AutoPartsStore.WEB.Models.Base;

namespace AutoPartsStore.WEB.Models {
    public class BrandViewModel : BaseEntityViewModel<Guid>
    {
        public string? Name { get; set; }        
    }
}

using AutoPartsStore.BLL.Filters.Base;

namespace AutoPartsStore.BLL.Filters {
    public class UserFilter : BaseFilter {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

namespace AutoPartsStore.BLL.Filters.Base {
    public class BaseFilter {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public string OrderBy { get; set; }
    }
}

﻿namespace AutoPartsStore.BLL.Filters.Base {
    public class BaseFilter {
        public string? SortColumn { get; set; }
        public string? SortColumnDir { get; set; }
        public string? Draw { get; set; }
        public int Skip { get; set; }
        public int PageSize { get; set; }
        
        public BaseFilter() { }
    }
}

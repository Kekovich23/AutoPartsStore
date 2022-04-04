﻿namespace AutoPartsStore.BLL.Services
{
    public class ServiceResult
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
    }
}

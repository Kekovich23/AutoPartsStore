namespace AutoPartsStore.BLL.Services {
    public class ServiceResult {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }

        public static ServiceResult Success() {
            return new ServiceResult { IsSuccessful = true };
        }

        public static ServiceResult Failed(string message) {
            return new ServiceResult { Message = message };
        }
    }
    public class ServiceResult<T> : ServiceResult {
        public T? Data { get; set; }

        public static ServiceResult<T> Success(T data) {
            return new ServiceResult<T> { IsSuccessful = true, Data = data };
        }
        public static new ServiceResult<T> Failed(string message, T data) {
            return new ServiceResult<T> { Message = message, Data = data };
        }
    }
}

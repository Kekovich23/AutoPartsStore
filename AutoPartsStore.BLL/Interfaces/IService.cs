using AutoPartsStore.BLL.Services.Base;

namespace AutoPartsStore.BLL.Interfaces {
    public interface IService<TEntity, TEntityDTO, TKey, TFilter> : IDisposable {
        Task<ServiceResult<TEntityDTO>> CreateAsync(TEntityDTO entityDTO);
        Task<ServiceResult<TEntityDTO>> GetAsync(TKey id);
        Task<ServiceResult<IEnumerable<TEntityDTO>>> GetAllAsync(TFilter filter);
        Task<ServiceResult> RemoveAsync(TKey id);
        Task<ServiceResult<TEntityDTO>> UpdateAsync(TEntityDTO entityDTO);
    }
}

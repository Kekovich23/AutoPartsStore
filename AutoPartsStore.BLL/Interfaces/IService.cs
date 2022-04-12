using AutoPartsStore.BLL.Services;

namespace AutoPartsStore.BLL.Interfaces {
    public interface IService<TEntity, TEntityDTO, TKey, TFilter> : IDisposable
        where TEntityDTO : class
        where TEntity : class {
        Task<ServiceResult<TEntityDTO>> Create(TEntityDTO entityDTO);
        Task<ServiceResult<TEntityDTO>> Get(TKey id);
        Task<ServiceResult<IEnumerable<TEntityDTO>>> GetAll(TFilter filter);
        Task<ServiceResult> Remove(TKey id);
        Task<ServiceResult<TEntityDTO>> Update(TEntityDTO entityDTO);
    }
}

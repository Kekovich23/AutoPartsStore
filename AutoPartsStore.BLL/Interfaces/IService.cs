using AutoPartsStore.BLL.Services.Base;

namespace AutoPartsStore.BLL.Interfaces {
    public interface IService<TEntity, TEntityDTO, TKey, TFilter> : IDisposable {
        Task<ServiceResult<TEntityDTO>> Create(TEntityDTO entityDTO);
        Task<ServiceResult<TEntityDTO>> Get(TKey id);
        ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter);
        Task<ServiceResult> Remove(TKey id);
        Task<ServiceResult<TEntityDTO>> Update(TEntityDTO entityDTO);
    }
}

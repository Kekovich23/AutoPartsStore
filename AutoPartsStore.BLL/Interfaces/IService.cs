using AutoPartsStore.BLL.Services;

namespace AutoPartsStore.BLL.Interfaces {
    public interface IService<TEntity, TEntityDTO, TKey, TFilter> : IDisposable
        where TEntityDTO : class
        where TEntity : class {
        ServiceResult<TEntityDTO> Create(TEntityDTO entityDTO);
        Task<ServiceResult<TEntityDTO>> Get(TKey id);
        Task<ServiceResult<IEnumerable<TEntityDTO>>> GetAll(TFilter filter);
        ServiceResult Remove(TKey id);
        ServiceResult<TEntityDTO> Update(TEntityDTO entityDTO);
    }
}

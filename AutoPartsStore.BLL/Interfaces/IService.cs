using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Services;

namespace AutoPartsStore.BLL.Interfaces {
    public interface IService<TEntity, TEntityDTO, TKey, TFilter> : IDisposable
        where TEntityDTO : BaseEntityDTO<TKey>
        where TEntity : BaseEntity<TKey> {
        ServiceResult<TEntityDTO> Create(TEntityDTO entityDTO);
        ServiceResult<TEntityDTO> Get(TKey id);
        ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter);
        ServiceResult Remove(TKey id);
        ServiceResult<TEntityDTO> Update(TEntityDTO entityDTO);
    }
}

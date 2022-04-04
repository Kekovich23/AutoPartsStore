using AutoPartsStore.BLL.Services;
using System.Linq.Expressions;

namespace AutoPartsStore.BLL.Interfaces
{
    public interface IService<TEntityDTO, TEntity, TFilter>
        where TEntityDTO : class
        where TEntity : class
        where TFilter : class
    {
        ServiceResult Create(TEntityDTO entityDTO);
        ServiceResult<TEntityDTO> Get(Expression<Func<TEntity, bool>> predicate);
        ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter);
        ServiceResult Remove(TEntityDTO entityDTO);
        ServiceResult Update(TEntityDTO entityDTO);
        void Dispose();
    }
}

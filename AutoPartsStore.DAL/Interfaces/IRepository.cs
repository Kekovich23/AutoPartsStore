using System.Linq.Expressions;

namespace AutoPartsStore.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, Boolean>> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
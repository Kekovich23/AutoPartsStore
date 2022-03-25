namespace AutoPartsStore.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
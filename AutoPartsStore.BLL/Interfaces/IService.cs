namespace AutoPartsStore.BLL.Interfaces
{
    public interface IService<TEntityDTO, TEntity> where TEntityDTO : class where TEntity : class
    {
        void Create(TEntityDTO entityDTO);
        TEntityDTO Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntityDTO> GetAll();
        void Remove(TEntityDTO entityDTO);
        void Update(TEntityDTO entityDTO);
        void Dispose();
    }
}

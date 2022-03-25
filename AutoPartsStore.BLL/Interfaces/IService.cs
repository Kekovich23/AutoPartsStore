namespace AutoPartsStore.BLL.Interfaces
{
    public interface IService<TEntityDTO, TEntity> where TEntityDTO : class where TEntity : class
    {
        void Create(TEntityDTO entityDTO);
        TEntityDTO Get(Guid? id);
        IEnumerable<TEntityDTO> GetAll();
        void Remove(TEntityDTO entityDTO);
        void Update(TEntityDTO entityDTO);
        void Dispose();
    }
}

using AutoMapper;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public abstract class BaseService<TEntityDTO, TEntity> : IService<TEntityDTO, TEntity> where TEntityDTO : class where TEntity : class
    {
        protected IUnitOfWork Database;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public void Create(TEntityDTO entityDTO)
        {
            Database.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public TEntityDTO Get(Func<TEntity, bool> predicate)
        {
            return _mapper.Map<TEntityDTO>(Database.GetRepository<TEntity>().Get(predicate));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {            
            return _mapper.Map<IEnumerable<TEntityDTO>>(Database.GetRepository<TEntity>().GetAll());
        }

        public void Remove(TEntityDTO entityDTO)
        {
            Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(entityDTO));
        }

        public void Update(TEntityDTO entityDTO)
        {
            Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
        }
    }
}

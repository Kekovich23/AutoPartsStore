using AutoMapper;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services
{
    public abstract class BaseService<TEntityDTO, TEntity> : IService<TEntityDTO, TEntity> where TEntityDTO : class where TEntity : class
    {
        protected IUnitOfWork Database { get; set; }

        public BaseService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(TEntityDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TEntityDTO, TEntity>()).CreateMapper();
            TEntity entity = mapper.Map<TEntityDTO, TEntity>(entityDTO);
            Database.GetRepository<TEntity>().Create(entity);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public TEntityDTO Get(Guid? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id объекта", "");
            var entity = Database.GetRepository<TEntity>().Get(id.Value);
            if (entity == null)
                throw new ValidationException("Объект не найден", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntityDTO>()).CreateMapper();
            TEntityDTO entityDTO = mapper.Map<TEntity, TEntityDTO>(entity);

            return entityDTO;
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TEntity>, List<TEntityDTO>>(Database.GetRepository<TEntity>().GetAll());
        }

        public void Remove(TEntityDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TEntityDTO, TEntity>()).CreateMapper();
            TEntity entity = mapper.Map<TEntityDTO, TEntity>(entityDTO);

            Database.GetRepository<TEntity>().Remove(entity);
        }

        public void Update(TEntityDTO entityDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TEntityDTO, TEntity>()).CreateMapper();
            TEntity entity = mapper.Map<TEntityDTO, TEntity>(entityDTO);

            Database.GetRepository<TEntity>().Update(entity);
        }
    }
}

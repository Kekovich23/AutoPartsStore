using AutoMapper;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;
using System.Linq.Expressions;

namespace AutoPartsStore.BLL.Services
{


    public abstract class BaseService<TEntityDTO, TEntity, TFilter> : IService<TEntityDTO, TEntity, TFilter>
        where TEntityDTO : class
        where TEntity : class
        where TFilter : class
    {
        protected readonly IUnitOfWork Database;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public ServiceResult Create(TEntityDTO entityDTO)
        {
            ServiceResult serviceResult = new();
            try
            {
                Database.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch
            {
                serviceResult.Message = "Failed to create";
            }
            return serviceResult;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ServiceResult<TEntityDTO> Get(Expression<Func<TEntity, bool>> predicate)
        {
            ServiceResult<TEntityDTO> serviceResult = new();
            try
            {
                var query = Database.GetRepository<TEntity>()
                .GetAll()
                .Where(predicate);

                query = Include(query);

                serviceResult.Data = _mapper.Map<TEntityDTO>(query.FirstOrDefault());
                serviceResult.IsSuccessful = true;
            }
            catch
            {
                serviceResult.Message = "Failed to get";
            }
            return serviceResult;
        }

        public ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter)
        {
            ServiceResult<IEnumerable<TEntityDTO>> serviceResult = new();
            try
            {
                var query = Database.GetRepository<TEntity>().GetAll();

                query = Include(query);

                query = FilterOut(query, filter);

                serviceResult.Data = _mapper.Map<IEnumerable<TEntityDTO>>(query);
                serviceResult.IsSuccessful = true;
            }
            catch
            {
                serviceResult.Message = "Failed to get all";
            }
            return serviceResult;
        }

        public ServiceResult Remove(TEntityDTO entityDTO)
        {
            ServiceResult serviceResult = new();
            try
            {
                Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch
            {
                serviceResult.Message = "Failed to remove";
            }
            return serviceResult;
        }

        public ServiceResult Update(TEntityDTO entityDTO)
        {
            ServiceResult serviceResult = new();
            try
            {
                Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch
            {
                serviceResult.Message = "Failed to update";
            }
            return serviceResult;
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> query)
        {
            return query;
        }

        protected virtual IQueryable<TEntity> FilterOut(IQueryable<TEntity> query, TFilter filter)
        {
            return query;
        }
    }
}
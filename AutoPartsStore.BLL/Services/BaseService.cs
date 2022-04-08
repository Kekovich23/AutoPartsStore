using AutoMapper;
using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services {
    public abstract class BaseService<TEntity, TEntityDTO, TKey, TFilter> : IService<TEntity, TEntityDTO, TKey, TFilter>
        where TEntityDTO : class, IBaseEntityDTO<TKey>
        where TEntity : class, IBaseEntity<TKey> {
        protected readonly IUnitOfWork Database;
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseService<TEntity, TEntityDTO, TKey, TFilter>> _logger;

        public BaseService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<TEntity, TEntityDTO, TKey, TFilter>> logger) {
            Database = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public ServiceResult<TEntityDTO> Create(TEntityDTO entityDTO) {
            try {
                Database.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
                return ServiceResult<TEntityDTO>.Success(entityDTO);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to create");
                return ServiceResult<TEntityDTO>.Failed("Failed to create", entityDTO);
            }
        }

        public void Dispose() {
            Database.Dispose();
        }

        private IQueryable<TEntity> GetQuery(TKey id) {
            var query = Database.GetRepository<TEntity>()
                .GetAll()
                .Where(x => x.Id.Equals(id));

            return Include(query);
        }

        public virtual async Task<ServiceResult<TEntityDTO>> Get(TKey id) {
            try {
                var query = GetQuery(id);
                return ServiceResult<TEntityDTO>.Success(_mapper.Map<TEntityDTO>(query.FirstOrDefault()));
            }
            catch (Exception ex){
                _logger.LogError(ex, "Failed to get");
                return ServiceResult<TEntityDTO>.Failed("Failed to get");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<TEntityDTO>>> GetAll(TFilter filter) {
            try {
                var query = Database.GetRepository<TEntity>().GetAll();

                query = Include(query);

                query = FilterOut(query, filter);
                return ServiceResult<IEnumerable<TEntityDTO>>.Success(_mapper.Map<IEnumerable<TEntityDTO>>(query));
            }
            catch (Exception ex){
                _logger.LogError(ex, "Failed to get all");
                return ServiceResult<IEnumerable<TEntityDTO>>.Failed("Failed to get all");
            }
        }

        public ServiceResult Remove(TKey id) {
            try {
                var query = GetQuery(id);
                Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(query.FirstOrDefault()));
                return ServiceResult.Success();
            }
            catch (Exception ex){
                _logger.LogError(ex, "Failed to remove");
                return ServiceResult.Failed("Failed to remove");
            }
        }

        public ServiceResult<TEntityDTO> Update(TEntityDTO entityDTO) {
            try {
                Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
                return ServiceResult<TEntityDTO>.Success(entityDTO);
            }
            catch (Exception ex){
                _logger.LogError(ex, "Failed to update");
                return ServiceResult<TEntityDTO>.Failed("Failed to update", entityDTO);
            }
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> query) {
            return query;
        }

        protected virtual IQueryable<TEntity> FilterOut(IQueryable<TEntity> query, TFilter filter) {
            return query;
        }
    }
}
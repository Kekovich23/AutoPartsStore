using AutoMapper;
using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;

namespace AutoPartsStore.BLL.Services {
    public abstract class BaseService<TEntity, TEntityDTO, TKey, TFilter> : IService<TEntity, TEntityDTO, TKey, TFilter>
        where TEntityDTO : BaseEntityDTO<TKey>
        where TEntity : BaseEntity<TKey> {
        protected readonly IUnitOfWork Database;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper) {
            Database = uow;
            _mapper = mapper;
        }

        public ServiceResult<TEntityDTO> Create(TEntityDTO entityDTO) {
            try {
                Database.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
                return ServiceResult<TEntityDTO>.Success(entityDTO);
            }
            catch {
                // TODO: log
                return ServiceResult<TEntityDTO>.Failed("Failed to create");
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

        public ServiceResult<TEntityDTO> Get(TKey id) {
            try {
                var query = GetQuery(id);
                return ServiceResult<TEntityDTO>.Success(_mapper.Map<TEntityDTO>(query.FirstOrDefault()));
            }
            catch {
                // TODO: log
                return ServiceResult<TEntityDTO>.Failed("Failed to get");
            }
        }

        public ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter) {
            try {
                var query = Database.GetRepository<TEntity>().GetAll();

                query = Include(query);

                query = FilterOut(query, filter);
                return ServiceResult<IEnumerable<TEntityDTO>>.Success(_mapper.Map<IEnumerable<TEntityDTO>>(query));
            }
            catch {
                // TODO: log
                return ServiceResult<IEnumerable<TEntityDTO>>.Failed("Failed to get all");
            }
        }

        public ServiceResult Remove(TKey id) {
            try {
                var query = GetQuery(id);
                Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(query));
                return ServiceResult.Success();
            }
            catch {
                // TODO: log
                return ServiceResult.Failed("Failed to remove");
            }
        }

        public ServiceResult<TEntityDTO> Update(TEntityDTO entityDTO) {
            try {
                Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
                return ServiceResult<TEntityDTO>.Success(entityDTO);
            }
            catch {
                // TODO: log
                return ServiceResult<TEntityDTO>.Failed("Failed to update");
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
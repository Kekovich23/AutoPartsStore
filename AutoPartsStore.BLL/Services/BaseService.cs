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

        public ServiceResult Create(TEntityDTO entityDTO) {
            ServiceResult serviceResult = new();
            try {
                Database.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch {
                serviceResult.Message = "Failed to create";
            }
            return serviceResult;
        }

        public void Dispose() {
            Database.Dispose();
        }

        public ServiceResult<TEntityDTO> Get(TKey id) {
            ServiceResult<TEntityDTO> serviceResult = new();
            try {
                var query = Database.GetRepository<TEntity>()
                    .GetAll()
                    .Where(x => x.Id.Equals(id));

                query = Include(query);

                serviceResult.Data = _mapper.Map<TEntityDTO>(query.FirstOrDefault());
                serviceResult.IsSuccessful = true;
            }
            catch {
                serviceResult.Message = "Failed to get";
            }
            return serviceResult;
        }

        public ServiceResult<IEnumerable<TEntityDTO>> GetAll(TFilter filter) {
            ServiceResult<IEnumerable<TEntityDTO>> serviceResult = new();
            try {
                var query = Database.GetRepository<TEntity>().GetAll();

                query = Include(query);

                query = FilterOut(query, filter);

                serviceResult.Data = _mapper.Map<IEnumerable<TEntityDTO>>(query);
                serviceResult.IsSuccessful = true;
            }
            catch {
                serviceResult.Message = "Failed to get all";
            }
            return serviceResult;
        }

        public ServiceResult Remove(TEntityDTO entityDTO) {
            ServiceResult serviceResult = new();
            try {
                Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch {
                serviceResult.Message = "Failed to remove";
            }
            return serviceResult;
        }

        public ServiceResult Update(TEntityDTO entityDTO) {
            ServiceResult serviceResult = new();
            try {
                Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
                serviceResult.IsSuccessful = true;
            }
            catch {
                serviceResult.Message = "Failed to update";
            }
            return serviceResult;
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> query) {
            return query;
        }

        protected virtual IQueryable<TEntity> FilterOut(IQueryable<TEntity> query, TFilter filter) {
            return query;
        }
    }
}
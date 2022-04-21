using AutoMapper;
using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Filters.Base;
using AutoPartsStore.BLL.Interfaces;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services.Base {
    public abstract class BaseService {
        protected readonly IUnitOfWork Database;
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseService> _logger;
        public BaseService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService> logger) {
            Database = uow;
            _mapper = mapper;
            _logger = logger;
        }
    }

    public abstract class BaseService<TEntity> : BaseService {
        protected BaseService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService> logger) : base(uow, mapper, logger) {
        }
    }

    public abstract class BaseService<TEntity, TEntityDTO, TKey, TFilter> : BaseService<TEntity>, IService<TEntity, TEntityDTO, TKey, TFilter>
        where TEntityDTO : class, IBaseEntityDTO<TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TFilter : BaseFilter {
        protected BaseService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService> logger) : base(uow, mapper, logger) {
        }

        public virtual async Task<ServiceResult<TEntityDTO>> CreateAsync(TEntityDTO entityDTO) {
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

        public virtual async Task<ServiceResult<TEntityDTO>> GetAsync(TKey id) {
            try {
                var query = GetQuery(id);
                return ServiceResult<TEntityDTO>.Success(_mapper.Map<TEntityDTO>(query.FirstOrDefault()));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get");
                return ServiceResult<TEntityDTO>.Failed("Failed to get");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<TEntityDTO>>> GetAllAsync(TFilter filter) {
            try {
                var query = Database.GetRepository<TEntity>().GetAll();

                if (filter != null) {
                    query = FilterOut(query, filter);

                    query = OrderBy(query, filter);

                    query = query.Skip(filter.Skip).Take(filter.PageSize);
                }

                query = Include(query);                

                return ServiceResult<IEnumerable<TEntityDTO>>.Success(_mapper.Map<IEnumerable<TEntityDTO>>(query));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get all");
                return ServiceResult<IEnumerable<TEntityDTO>>.Failed("Failed to get all");
            }
        }

        public virtual async Task<ServiceResult> RemoveAsync(TKey id) {
            try {
                var query = GetQuery(id);
                Database.GetRepository<TEntity>().Remove(_mapper.Map<TEntity>(query.FirstOrDefault()));
                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to remove");
                return ServiceResult.Failed("Failed to remove");
            }
        }

        public virtual async Task<ServiceResult<TEntityDTO>> UpdateAsync(TEntityDTO entityDTO) {
            try {
                Database.GetRepository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
                return ServiceResult<TEntityDTO>.Success(entityDTO);
            }
            catch (Exception ex) {
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

        protected virtual IQueryable<TEntity> OrderBy(IQueryable<TEntity> query, TFilter filter) {
            return query;
        }

        protected virtual TFilter InitFilter(IFormCollection form, TFilter filter) {
            var draw = form["draw"].FirstOrDefault();
            var start = form["start"].FirstOrDefault();
            var length = form["length"].FirstOrDefault();
            var sortColumn = form["columns[" + form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            filter.SortColumn = sortColumn;
            filter.SortColumnDir = sortColumnDir;
            filter.Skip = skip;
            filter.PageSize = pageSize;
            filter.Draw = draw;
            return filter;
        }

        public virtual TFilter GetFilter(IFormCollection form) {
            return null;
        }
    }
}
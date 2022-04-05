using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using System.Data.Entity;

namespace AutoPartsStore.BLL.Services {
    public class ModelService : BaseService<Model, ModelDTO, Guid, ModelFilter> {
        public ModelService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) {
        }

        protected override IQueryable<Model> Include(IQueryable<Model> query) {
            return query
                .Include(m => m.Brand)
                .Include(m => m.TypeTransport);
        }

        protected override IQueryable<Model> FilterOut(IQueryable<Model> query, ModelFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (filter.BrandId.HasValue) {
                query = query.Where(m => m.BrandId == filter.BrandId.Value);
            }

            if (filter.TypeTransportId.HasValue) {
                query = query.Where((m) => m.TypeTransportId == filter.TypeTransportId.Value);
            }

            return query;
        }
    }
}

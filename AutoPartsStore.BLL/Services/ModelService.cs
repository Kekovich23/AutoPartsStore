using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace AutoPartsStore.BLL.Services {
    public class ModelService : BaseService<Model, ModelDTO, Guid, ModelFilter> {
        public ModelService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Model, ModelDTO, Guid, ModelFilter>> logger) : base(uow, mapper, logger) {
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

        protected override IQueryable<Model> OrderBy(IQueryable<Model> query, ModelFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override ModelFilter GetFilter(IFormCollection form) {
            ModelFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(form["BrandId"]) && Guid.TryParse(form["BrandId"], out Guid result)) {
                filter.BrandId = result;
            }
            if (!string.IsNullOrWhiteSpace(form["TypeTransportId"]) && int.TryParse(form["TypeTransportId"], out int result1)) {
                filter.TypeTransportId = result1;
            }
            return filter;
        }
    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;

namespace AutoPartsStore.BLL.Services {
    public class FeatureService : BaseService<Feature, FeatureDTO, int, FeatureFilter> {
        public FeatureService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Feature, FeatureDTO, int, FeatureFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Feature> FilterOut(IQueryable<Feature> query, FeatureFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            return query;
        }

        protected override IQueryable<Feature> OrderBy(IQueryable<Feature> query, FeatureFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override FeatureFilter GetFilter(IFormCollection form) {
            FeatureFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}

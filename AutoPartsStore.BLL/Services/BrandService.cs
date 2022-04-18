using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace AutoPartsStore.BLL.Services {
    public class BrandService : BaseService<Brand, BrandDTO, Guid, BrandFilter> {
        public BrandService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<Brand, BrandDTO, Guid, BrandFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Brand> FilterOut(IQueryable<Brand> query, BrandFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower() == filter.Name.ToLower());
            }
            return query;
        }

        protected override IQueryable<Brand> OrderBy(IQueryable<Brand> query, BrandFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override BrandFilter GetFilter(IFormCollection form) {
            BrandFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}

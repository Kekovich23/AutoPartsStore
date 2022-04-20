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
    public class ManufacturerService : BaseService<Manufacturer, ManufacturerDTO, Guid, ManufacturerFilter> {
        public ManufacturerService(
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<BaseService<Manufacturer, ManufacturerDTO, Guid, ManufacturerFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Manufacturer> FilterOut(IQueryable<Manufacturer> query, ManufacturerFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower() == filter.Name.ToLower());
            }
            return query;
        }

        protected override IQueryable<Manufacturer> OrderBy(IQueryable<Manufacturer> query, ManufacturerFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override ManufacturerFilter GetFilter(IFormCollection form) {
            ManufacturerFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}

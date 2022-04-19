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
    public class TypeTransportService : BaseService<TypeTransport, TypeTransportDTO, int, TypeTransportFilter> {
        public TypeTransportService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService<TypeTransport, TypeTransportDTO, int, TypeTransportFilter>> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<TypeTransport> FilterOut(IQueryable<TypeTransport> query, TypeTransportFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower() == filter.Name.ToLower());
            }
            return query;
        }

        protected override IQueryable<TypeTransport> OrderBy(IQueryable<TypeTransport> query, TypeTransportFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override TypeTransportFilter GetFilter(IFormCollection form) {
            TypeTransportFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}

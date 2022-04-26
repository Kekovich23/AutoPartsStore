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
    public class StatusService : BaseService<Status, StatusDTO, int, StatusFilter> {
        public StatusService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Status> FilterOut(IQueryable<Status> query, StatusFilter filter) {
            if (!string.IsNullOrEmpty(filter.Name)) {
                query = query.Where(m => m.Name.ToLower() == filter.Name.ToLower());
            }
            return query;
        }

        protected override IQueryable<Status> OrderBy(IQueryable<Status> query, StatusFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override StatusFilter GetFilter(IFormCollection form) {
            StatusFilter filter = new();
            filter = InitFilter(form, filter);
            filter.Name = form["Name"].FirstOrDefault();
            return filter;
        }
    }
}

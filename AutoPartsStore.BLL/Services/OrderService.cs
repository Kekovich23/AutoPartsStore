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
    public class OrderService : BaseService<Order, OrderDTO, Guid, OrderFilter> {
        public OrderService(IUnitOfWork uow, IMapper mapper, ILogger<BaseService> logger) : base(uow, mapper, logger) {
        }

        protected override IQueryable<Order> Include(IQueryable<Order> query) {
            return query
                .Include(e => e.Details)
                .Include(e => e.User)
                .Include(e => e.OrderDetails);
        }

        protected override IQueryable<Order> OrderBy(IQueryable<Order> query, OrderFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
            }
            return query;
        }

        public override OrderFilter GetFilter(IFormCollection form) {
            OrderFilter filter = new();
            filter = InitFilter(form, filter);
            return filter;
        }


    }
}

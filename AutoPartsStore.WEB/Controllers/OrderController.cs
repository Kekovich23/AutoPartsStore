using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {
    public class OrderController : CrudController<Order, OrderDTO, OrderViewModel, Guid, OrderFilter> {
        public OrderController(
            OrderService service,
            IMapper mapper,
            ILogger<CrudController<Order, OrderDTO, OrderViewModel, Guid, OrderFilter>> logger) : base(service, mapper, logger) {
        }

    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.DAL.Configure;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsStore.WEB.Controllers {
    [Authorize(Roles = RoleInitializer.AdminRoleName)]
    public class StatusController : CrudController<Status, StatusDTO, StatusViewModel, int, StatusFilter> {
        public StatusController(
            StatusService service,
            IMapper mapper,
            ILogger<CrudController<Status, StatusDTO, StatusViewModel, int, StatusFilter>> logger) : base(service, mapper, logger) { }
    }
}

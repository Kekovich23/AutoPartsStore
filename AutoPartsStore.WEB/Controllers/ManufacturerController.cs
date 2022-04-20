using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class ManufacturerController : CrudController<Manufacturer, ManufacturerDTO, ManufacturerViewModel, Guid, ManufacturerFilter> {
        public ManufacturerController(
            ManufacturerService service,
            IMapper mapper,
            ILogger<CrudController<Manufacturer, ManufacturerDTO, ManufacturerViewModel, Guid, ManufacturerFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

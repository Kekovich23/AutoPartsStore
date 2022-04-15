using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class TypeTransportController : CrudController<TypeTransport, TypeTransportDTO, TypeTransportViewModel, int, TypeTransportFilter> {
        public TypeTransportController(
            TypeTransportService service,
            IMapper mapper,
            ILogger<CrudController<TypeTransport, TypeTransportDTO, TypeTransportViewModel, int, TypeTransportFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

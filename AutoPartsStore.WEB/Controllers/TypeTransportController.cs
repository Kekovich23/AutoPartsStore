using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class TypeTransportController : CrudController<TypeTransport, TypeTransportDTO, TypeTransportViewModel, int, TypeTransportFilter> {
        public TypeTransportController(BaseService<TypeTransport, TypeTransportDTO, int, TypeTransportFilter> service,
                                       IMapper mapper,
                                       ILogger<CrudController<TypeTransport, TypeTransportDTO, TypeTransportViewModel, int, TypeTransportFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

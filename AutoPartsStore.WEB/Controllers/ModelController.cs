using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class ModelController : CrudController<Model, ModelDTO, ModelViewModel, Guid, ModelFilter> {
        public ModelController(BaseService<Model, ModelDTO, Guid, ModelFilter> service,
                               IMapper mapper,
                               ILogger<CrudController<Model, ModelDTO, ModelViewModel, Guid, ModelFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

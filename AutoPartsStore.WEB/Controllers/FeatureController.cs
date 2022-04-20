using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class FeatureController : CrudController<Feature, FeatureDTO, FeatureViewModel, int, FeatureFilter> {
        public FeatureController(
            FeatureService service,
            IMapper mapper,
            ILogger<CrudController<Feature, FeatureDTO, FeatureViewModel, int, FeatureFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

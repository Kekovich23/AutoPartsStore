using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class ModelController : CrudController<Model, ModelDTO, ModelViewModel, Guid, ModelFilter> {
        private readonly TypeTransportService _typeTransportService;
        private readonly BrandService _brandService;

        public ModelController(
            ModelService service,
            TypeTransportService typeTransportService,
            BrandService brandService,
            IMapper mapper,
            ILogger<CrudController<Model, ModelDTO, ModelViewModel, Guid, ModelFilter>> logger) : base(service, mapper, logger) {
            _typeTransportService = typeTransportService;
            _brandService = brandService;
        }

        protected override async Task<bool> InitDataAsync() {
            var brandsResult = await _brandService.GetAllAsync(null);
            if (!brandsResult.IsSuccessful) {
                return false;
            }
            var typeTransportResult = await _typeTransportService.GetAllAsync(null);
            if (!typeTransportResult.IsSuccessful) {
                return false;
            }
            ViewBag.Brands = brandsResult.Data;
            ViewBag.TypesTransport = typeTransportResult.Data;
            return true;
        }
    }
}

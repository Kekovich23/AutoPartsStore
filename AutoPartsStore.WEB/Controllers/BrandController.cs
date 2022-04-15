using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class BrandController : CrudController<Brand, BrandDTO, BrandViewModel, Guid, BrandFilter> {
        public BrandController(
            BrandService service,
            IMapper mapper,
            ILogger<CrudController<Brand, BrandDTO, BrandViewModel, Guid, BrandFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

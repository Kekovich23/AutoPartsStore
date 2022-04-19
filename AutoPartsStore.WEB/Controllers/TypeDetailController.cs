using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class TypeDetailController : CrudController<TypeDetail, TypeDetailDTO, TypeDetailViewModel, int, TypeDetailFilter> {
        private readonly SectionService _sectionService;
        public TypeDetailController(
            TypeDetailService service,
            SectionService sectionService,
            IMapper mapper,
            ILogger<CrudController<TypeDetail, TypeDetailDTO, TypeDetailViewModel, int, TypeDetailFilter>> logger) : base(service, mapper, logger) {
            _sectionService = sectionService;
        }

        protected override async Task<bool> InitDataAsync() {
            var sectionResult = await _sectionService.GetAllAsync(null);
            if (!sectionResult.IsSuccessful) {
                return false;
            }
            ViewBag.Sections = sectionResult.Data;
            return true;
        }
    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;

namespace AutoPartsStore.WEB.Controllers {
    public class SectionController : CrudController<Section, SectionDTO, SectionViewModel, int, SectionFilter> {
        public SectionController(
            SectionService service,
            IMapper mapper,
            ILogger<CrudController<Section, SectionDTO, SectionViewModel, int, SectionFilter>> logger) : base(service, mapper, logger) {
        }
    }
}

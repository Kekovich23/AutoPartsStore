using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {
    public class ModificationController : CrudController<Modification, ModificationDTO, ModificationViewModel, Guid, ModificationFilter> {
        ModelService _modelService;
        public ModificationController(
            ModificationService service,
            ModelService modelService,
            IMapper mapper,
            ILogger<CrudController<Modification, ModificationDTO, ModificationViewModel, Guid, ModificationFilter>> logger) : base(service, mapper, logger) {
            _modelService = modelService;
        }

        protected override async Task<bool> InitDataAsync() {
            var modelResult = await _modelService.GetAllAsync(null);
            if (!modelResult.IsSuccessful) {
                return false;
            }
            ViewBag.Models = modelResult.Data;
            return true;
        }
    }
}

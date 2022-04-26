using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {
    public class DetailController : CrudController<Detail, DetailDTO, DetailViewModel, Guid, DetailFilter> {
        private readonly TypeDetailService _typeDetailService;
        private readonly ManufacturerService _manufacturerService;
        private readonly ModificationService _modificationService;
        private readonly DetailService _detailService;
        public DetailController(
            DetailService service,
            TypeDetailService typeDetailService,
            ManufacturerService manufacturerService,
            ModificationService modificationService,
            IMapper mapper,
            ILogger<CrudController<Detail, DetailDTO, DetailViewModel, Guid, DetailFilter>> logger) : base(service, mapper, logger) {
            _typeDetailService = typeDetailService;
            _manufacturerService = manufacturerService;
            _modificationService = modificationService;
            _detailService = service;
        }

        protected override async Task<bool> InitDataAsync() {
            var typeResult = await _typeDetailService.GetAllAsync(null);
            if (!typeResult.IsSuccessful) {
                return false;
            }
            var manufacturerResult = await _manufacturerService.GetAllAsync(null);
            if (!manufacturerResult.IsSuccessful) {
                return false;
            }
            ViewBag.TypesDetail = typeResult.Data;
            ViewBag.Manufacturers = manufacturerResult.Data;
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> SetModifications(Guid id) {
            var modificationResult = await _modificationService.GetAllAsync(null);
            if (!modificationResult.IsSuccessful) {
                return View("Error", modificationResult.Message);
            }
            var detailDTOResult = _detailService.GetModifications(id, modificationResult.Data);
            if (!detailDTOResult.IsSuccessful) {
                return View("Error", detailDTOResult.Message);
            }
            InitDataAsync();
            return View("SetModifications", _mapper.Map<DetailViewModel>(detailDTOResult.Data));
        }

        [HttpPost]
        public async Task<IActionResult> SetModifications(Guid id, List<Guid> modificationIds) {

            List<ModificationDTO> modifications = new ();

            foreach (var modificationId in modificationIds) {
                var resultModification = await _modificationService.GetAsync(modificationId);
                modifications.Add(resultModification.Data);
            }

            var result = _detailService.SetModifications(
                id,
                _mapper.Map<IEnumerable<ModificationDTO>>(modifications));

            if (!result.IsSuccessful) {
                return View("Error", result.Message);
            }
            return View("Index");
        }
    }    
}

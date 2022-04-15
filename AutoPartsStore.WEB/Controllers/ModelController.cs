using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public override async Task<IActionResult> Edit(Guid id) {
            var brandsResult = await _brandService.GetAllAsync(null);

            if (!brandsResult.IsSuccessful) {
                return View("ErrorGet", brandsResult.Message);
            }

            var typeTransportResult = await _typeTransportService.GetAllAsync(null);

            if (!typeTransportResult.IsSuccessful) {
                return View("ErrorGet", typeTransportResult.Message);
            }

            ViewBag.Brands = brandsResult.Data;
            ViewBag.TypesTransport = typeTransportResult.Data;
            return await base.Edit(id);
        }

        [HttpGet]
        public override async Task<IActionResult> Add() {
            var brandsResult = await _brandService.GetAllAsync(null);

            if (!brandsResult.IsSuccessful) {
                return View("ErrorGet", brandsResult.Message);
            }

            var typeTransportResult = await _typeTransportService.GetAllAsync(null);

            if (!typeTransportResult.IsSuccessful) {
                return View("ErrorGet", typeTransportResult.Message);
            }

            ViewBag.Brands = brandsResult.Data;
            ViewBag.TypesTransport = typeTransportResult.Data;
            return await base.Add();
        }

        [HttpGet]
        public override async Task<IActionResult> Index() {
            var brandsResult = await _brandService.GetAllAsync(null);

            if (!brandsResult.IsSuccessful) {
                return View("ErrorGet", brandsResult.Message);
            }

            var typeTransportResult = await _typeTransportService.GetAllAsync(null);

            if (!typeTransportResult.IsSuccessful) {
                return View("ErrorGet", typeTransportResult.Message);
            }

            ViewBag.Brands = brandsResult.Data;
            ViewBag.TypesTransport = typeTransportResult.Data;
            return await base.Index();
        }
    }
}

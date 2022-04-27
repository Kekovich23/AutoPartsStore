using AutoMapper;
using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Filters.Base;
using AutoPartsStore.BLL.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoPartsStore.WEB.Controllers.Base {
    public class CrudController<TEntity, TEntityDTO, TEntityViewModel, TKey, TFilter> : Controller
        where TEntity : class, IBaseEntity<TKey>
        where TEntityDTO : class, IBaseEntityDTO<TKey>
        where TEntityViewModel : new()
        where TFilter : BaseFilter {
        protected readonly BaseService<TEntity, TEntityDTO, TKey, TFilter> _service;
        protected readonly IMapper _mapper;
        protected readonly ILogger<CrudController<TEntity, TEntityDTO, TEntityViewModel, TKey, TFilter>> _logger;

        public CrudController(BaseService<TEntity, TEntityDTO, TKey, TFilter> service,
                              IMapper mapper,
                              ILogger<CrudController<TEntity, TEntityDTO, TEntityViewModel, TKey, TFilter>> logger) {
            _service = service;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        protected virtual async Task<bool> InitDataAsync() {
            return true;
        }

        public virtual async Task<IActionResult> Index() {
            if (!await InitDataAsync()) {
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetAll() {
            var filter = _service.GetFilter(Request.Form);

            var result = await _service.GetAllAsync(filter);
            if (!result.IsSuccessful) {
                return BadRequest();
            }

            var recordsTotal = result.Data.Count();

            return Json(new { filter.Draw, recordsFiltered = recordsTotal, recordsTotal, data = result.Data });
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(TKey id) {
            var result = await _service.GetAsync(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<TEntityViewModel>(result.Data));
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(TKey id) {
            var result = await _service.RemoveAsync(id);
            if (!result.IsSuccessful) {
                return BadRequest(result.Message);
            }
            return Ok();
        }

        protected void ErrorOccured(string errorMessage) {
            ViewBag.IsFailed = true;
            ViewBag.ErrorMessage = errorMessage;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Add() {
            if (!await InitDataAsync()) {
                return View("Error");
            }
            _logger.LogInformation("Pressed 'Add' button.");
            return View("Edit", new TEntityViewModel { });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntityViewModel entityViewModel) {
            if (!await InitDataAsync()) {
                return View("Error");
            }
            var result = await _service.CreateAsync(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View("Edit", entityViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(TKey id) {
            if (!await InitDataAsync()) {
                return View("Error");
            }
            var result = await _service.GetAsync(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<TEntityViewModel>(result.Data));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TEntityViewModel entityViewModel) {
            if (!await InitDataAsync()) {
                return View("Error");
            }
            var result = await _service.UpdateAsync(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View(_mapper.Map<TEntityViewModel>(result.Data));
            }
            return RedirectToAction("Index");
        }

        public Guid GetUserId() {
            return Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}

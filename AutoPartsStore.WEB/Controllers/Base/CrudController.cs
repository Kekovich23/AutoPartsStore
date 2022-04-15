using AutoMapper;
using AutoPartsStore.AN.DTO.Base;
using AutoPartsStore.AN.Entities.Base;
using AutoPartsStore.BLL.Filters.Base;
using AutoPartsStore.BLL.Services.Base;
using Microsoft.AspNetCore.Mvc;

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

        public virtual async Task<IActionResult> Index() {
            return View();
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetAll(TFilter filter) {

            filter = _service.GetFilter(Request.Form, filter);

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();

            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            //filter.SearchValue = searchValue;
            filter.SortColumn = sortColumn;
            filter.SortColumnDir = sortColumnDir;
            filter.Skip = skip;
            filter.PageSize = pageSize;

            // Getting all Customer data    
            var result = await _service.GetAllAsync(filter);
            if (!result.IsSuccessful) {
                return BadRequest();
            }

            //total number of rows count     
            var recordsTotal = result.Data.Count();
            //Returning Json Data    
            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result.Data });
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
            _logger.LogInformation("Pressed 'Add' button.");
            return View("Edit", new TEntityViewModel { });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntityViewModel entityViewModel) {
            var result = await _service.CreateAsync(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View("Edit", entityViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(TKey id) {
            var result = await _service.GetAsync(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<TEntityViewModel>(result.Data));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TEntityViewModel entityViewModel) {
            var result = await _service.UpdateAsync(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View(_mapper.Map<TEntityViewModel>(result.Data));
            }
            return RedirectToAction("Index");
        }
    }
}

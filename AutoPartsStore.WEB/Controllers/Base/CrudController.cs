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

        public virtual IActionResult Index() {
            return View();
        }

        [HttpPost]
        public virtual IActionResult GetAll(TFilter filter) {
            _logger.LogInformation("Hello, this is the index!");
            var serviceResult = _service.GetAll(filter);
            if (!serviceResult.IsSuccessful) {
                return BadRequest(error: serviceResult.Message);
            }

            var customerData = _mapper.Map<IEnumerable<TEntityViewModel>>(serviceResult.Data);

            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            //// Sort Column Direction (asc, desc)  
            //var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            //var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            //total number of rows counts   
            int recordsTotal = customerData.Count();
            //Paging   
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(TKey id) {
            var result = await _service.Get(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<TEntityViewModel>(result.Data));
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(TKey id) {
            var result = await _service.Remove(id);
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
        public virtual IActionResult Add() {
            _logger.LogInformation("Pressed 'Add' button.");
            return View("Edit", new TEntityViewModel { });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntityViewModel entityViewModel) {
            var result = await _service.Create(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View("Edit", entityViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(TKey id) {
            var result = await _service.Get(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<TEntityViewModel>(result.Data));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(TEntityViewModel entityViewModel) {
            var result = await _service.Update(_mapper.Map<TEntityDTO>(entityViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View(_mapper.Map<TEntityViewModel>(result.Data));
            }
            return RedirectToAction("Index");
        }
    }
}

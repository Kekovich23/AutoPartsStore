using AutoMapper;
using AutoPartsStore.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers.Base
{
    public class CrudController<TService, TEntity, TEntityDto, TEntityViewModel, TFilter> : Controller
        where TService : IService<TEntityDto, TEntity, TFilter>
        where TEntity : class
        where TEntityDto : class
        where TEntityViewModel : class
        where TFilter : class
    {
        protected readonly TService _service;
        private readonly IMapper _mapper;

        public CrudController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET - TFilters

        [HttpPost]
        public virtual IActionResult Get(TFilter filter)
        {
            var serviceResult = _service.GetAll(filter);
            //TODO CHECK
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

        // GET/id
        //[HttpGet]
        //public IActionResult Get(Guid id)
        //{
        //    var result = _service.Get(id);
        //    if (result)
        //    {
        //        return View(result);
        //    }

        //    return View("Details", result.Data);
        //}

        // POST

        // PUT - TEntityViewModel

        // DELETE - id
    }
}

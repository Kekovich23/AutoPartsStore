using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers
{
    public class TypeTransportController : Controller
    {
        private readonly TypeTransportService _typeTransportService;
        private readonly IMapper _mapper;

        public TypeTransportController(TypeTransportService typeTransportService, IMapper mapper)
        {
            _typeTransportService = typeTransportService;
            _mapper = mapper;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult GetTypeTransports()
        //{
        //    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

        //    // Skip number of Rows count  
        //    var start = Request.Form["start"].FirstOrDefault();

        //    // Paging Length 10,20  
        //    var length = Request.Form["length"].FirstOrDefault();

        //    // Sort Column Name  
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

        //    // Sort Column Direction (asc, desc)  
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        //    // Search Value from (Search box)  
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //    //Paging Size (10, 20, 50,100)  
        //    int pageSize = length != null ? Convert.ToInt32(length) : 0;

        //    int skip = start != null ? Convert.ToInt32(start) : 0;

        //    int recordsTotal = 0;

        //    var customerData = _mapper.Map<IEnumerable<TypeTransportViewModel>>(_typeTransportService.GetAll());

        //    ////Sorting
        //    //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //    //{
        //    //    if (sortColumnDirection == "asc")
        //    //        customerData = customerData.OrderBy(s => sortColumn));
        //    //    else
        //    //        customerData = customerData.OrderByDescending(s => s.Name);
        //    //}
        //    ////Search  
        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        customerData = customerData.Where(m => m.Name == searchValue);
        //    }

        //    //total number of rows counts   
        //    recordsTotal = customerData.Count();
        //    //Paging   
        //    var data = customerData.Skip(skip).Take(pageSize).ToList();
        //    //Returning Json Data  
        //    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });

        //}

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    var id = Guid.NewGuid();

        //    return View(new TypeTransportViewModel { Id = id });
        //}

        //[HttpPost]
        //public IActionResult Add(TypeTransportViewModel typeTransportViewModel)
        //{
        //    _typeTransportService.Create(_mapper.Map<TypeTransportDTO>(typeTransportViewModel));

        //    return RedirectToAction("Index", "TypeTransport");
        //}

        //[HttpPost]
        //public void Delete(Guid Id)
        //{
        //    _typeTransportService.Remove(_typeTransportService.GetTypeTransport(Id));
        //}

        //[HttpGet]
        //public IActionResult Edit(Guid Id)
        //{
        //    return View(_mapper.Map<TypeTransportViewModel>(_typeTransportService.GetTypeTransport(Id)));
        //}

        //[HttpPost]
        //public IActionResult Edit(TypeTransportViewModel typeTransportViewModel)
        //{
        //    _typeTransportService.Update(_mapper.Map<TypeTransportDTO>(typeTransportViewModel));

        //    return RedirectToAction("Index", "TypeTransport");
        //}
    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsStore.WEB.Controllers
{
    public class ModelController : Controller
    {
        private readonly ModelService _modelService;
        private readonly BrandService _brandService;
        private readonly TypeTransportService _typeTransportService;
        private readonly IMapper _mapper;
        public ModelController(ModelService modelService, BrandService brandService, TypeTransportService typeTransportService, IMapper mapper)
        {
            _modelService = modelService;
            _brandService = brandService;
            _typeTransportService = typeTransportService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult GetModels()
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

        //    var customerData = _mapper.Map<IEnumerable<ModelViewModel>>(_modelService.GetModels());

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

        //    ViewBag.Brands = new SelectList(_mapper.Map<List<BrandViewModel>>(_brandService.GetAll()), "Id", "Name");

        //    ViewBag.TypesTransport = new SelectList(_mapper.Map<List<TypeTransportViewModel>>(_typeTransportService.GetAll()), "Id", "Name");

        //    return View(new ModelViewModel { Id = id });
        //}

        //[HttpPost]
        //public IActionResult Add(ModelViewModel modelViewModel)
        //{
        //    _modelService.Create(_mapper.Map<ModelDTO>(modelViewModel));

        //    return RedirectToAction("Index", "Model");
        //}

        //[HttpPost]
        //public void Delete(Guid Id)
        //{
        //    _modelService.Remove(_modelService.GetModel(Id));
        //}

        //[HttpGet]
        //public IActionResult Edit(Guid Id)
        //{
        //    return View(_mapper.Map<ModelViewModel>(_modelService.GetModel(Id)));
        //}

        //[HttpPost]
        //public IActionResult Edit(ModelViewModel modelViewModel)
        //{
        //    _modelService.Update(_mapper.Map<ModelDTO>(modelViewModel));

        //    return RedirectToAction("Index", "Model");
        //}
    }
}

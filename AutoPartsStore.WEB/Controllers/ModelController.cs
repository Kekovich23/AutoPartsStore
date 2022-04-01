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
        ModelService _modelService;
        BrandService _brandService;
        TypeTransportService _typeTransportService;
        public ModelController(ModelService modelService, BrandService brandService, TypeTransportService typeTransportService)
        {
            _modelService = modelService;
            _brandService = brandService;
            _typeTransportService = typeTransportService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetModels()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;

            IEnumerable<ModelDTO> modelDTOs = _modelService.GetAll();
            foreach(var model in modelDTOs)
            {
                model.BrandName = _brandService.GetBrand(model.BrandId).Name;
                model.TypeTransportName = _typeTransportService.GetTypeTransport(model.TypeTransportId).Name;
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ModelDTO, ModelViewModel>()).CreateMapper();
            var customerData = mapper.Map<IEnumerable<ModelDTO>, IEnumerable<ModelViewModel>>(modelDTOs);
            ////Sorting
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    if (sortColumnDirection == "asc")
            //        customerData = customerData.OrderBy(s => sortColumn));
            //    else
            //        customerData = customerData.OrderByDescending(s => s.Name);
            //}
            ////Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m => m.Name == searchValue);
            }

            //total number of rows counts   
            recordsTotal = customerData.Count();
            //Paging   
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

        }

        [HttpGet]
        public IActionResult Add()
        {
            var id = Guid.NewGuid();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, BrandViewModel>()).CreateMapper();
            var brandViewModels = mapper.Map<IEnumerable<BrandDTO>, List<BrandViewModel>>(_brandService.GetAll());

            SelectList brands = new SelectList(brandViewModels, "Id", "Name");
            ViewBag.Brands = brands;

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeTransportDTO, TypeTransportViewModel>()).CreateMapper();
            var typeTransportViewModels = mapper.Map<IEnumerable<TypeTransportDTO>, List<TypeTransportViewModel>>(_typeTransportService.GetAll());

            SelectList typeTransport = new SelectList(typeTransportViewModels, "Id", "Name");
            ViewBag.TypesTransport = typeTransport;

            return View(new ModelViewModel { Id = id });
        }

        [HttpPost]
        public IActionResult Add(ModelViewModel modelViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ModelViewModel, ModelDTO>()).CreateMapper();
            var modelDTO = mapper.Map<ModelViewModel, ModelDTO>(modelViewModel);

            _modelService.Create(modelDTO);

            return RedirectToAction("Index", "Model");
        }

        [HttpPost]
        public void Delete(Guid Id)
        {
            var model = _modelService.GetModel(Id);
            _modelService.Remove(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ModelDTO, ModelViewModel>()).CreateMapper();
            var model = mapper.Map<ModelDTO, ModelViewModel>(_modelService.GetModel(Id));

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ModelViewModel modelViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ModelViewModel, ModelDTO>()).CreateMapper();
            var modelDTO = mapper.Map<ModelViewModel, ModelDTO>(modelViewModel);
            _modelService.Update(modelDTO);

            return RedirectToAction("Index", "Model");
        }
    }
}

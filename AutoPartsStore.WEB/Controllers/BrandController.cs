using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Infrastructure;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            //IEnumerable<BrandDTO> brandDTOs = _brandService.GetAll();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, BrandViewModel>()).CreateMapper();
            //var brands = mapper.Map<IEnumerable<BrandDTO>, List<BrandViewModel>>(brandDTOs);
            //return View(brands);
            return View();
        }
        [HttpPost]
        public IActionResult GetBrands()
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

            IEnumerable<BrandDTO> brandDTOs = _brandService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, BrandViewModel>()).CreateMapper();
            var customerData = mapper.Map<IEnumerable<BrandDTO>, IEnumerable<BrandViewModel>>(brandDTOs);
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

            return View(new BrandViewModel { Id = id });
        }

        [HttpPost]
        public IActionResult Add(BrandViewModel brandViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandViewModel, BrandDTO>()).CreateMapper();
            var brandDTO = mapper.Map<BrandViewModel, BrandDTO>(brandViewModel);

            _brandService.Create(brandDTO);

            return RedirectToAction("Index", "Brand");
        }

        [HttpPost]
        public void Delete(Guid Id)
        {
            var brand = _brandService.GetBrand(Id);
            _brandService.Remove(brand);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, BrandViewModel>()).CreateMapper();
            var brand = mapper.Map<BrandDTO, BrandViewModel>(_brandService.GetBrand(Id));

            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(BrandViewModel brandViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BrandViewModel, BrandDTO>()).CreateMapper();
            var brandDTO = mapper.Map<BrandViewModel, BrandDTO>(brandViewModel);
            _brandService.Update(brandDTO);

            return RedirectToAction("Index", "Brand");
        }
    }
}

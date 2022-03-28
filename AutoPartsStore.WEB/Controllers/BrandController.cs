using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers
{
    public class BrandController : Controller
    {
        BrandService _brandService;

        public BrandController(BrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}

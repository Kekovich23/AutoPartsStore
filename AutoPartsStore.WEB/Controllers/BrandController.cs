using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers
{
    public class BrandController : CrudController<BrandService, Brand, BrandDTO, BrandViewModel, BrandFilter>
    {
        public BrandController(BrandService service, IMapper mapper) : base(service, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public override IActionResult Get(BrandFilter filter)
        {            
            return base.Get(filter);
        }


        //[HttpGet]
        //public IActionResult Add()
        //{
        //    var id = Guid.NewGuid();

        //    return View(new BrandViewModel { Id = id });
        //}

        //[HttpPost]
        //public IActionResult Add(BrandViewModel brandViewModel)
        //{
        //    _brandService.Create(_mapper.Map<BrandDTO>(brandViewModel));

        //    return RedirectToAction("Index", "Brand");
        //}

        //[HttpPost]
        //public IActionResult Delete(Guid Id)
        //{
        //    var getServiceResult = _brandService.Get(b => b.Id == Id);
        //    if (getServiceResult.IsSuccessful)
        //    {
        //        var removeServiceResult = _brandService.Remove(getServiceResult.Data);
        //        if(removeServiceResult.IsSuccessful)
        //        {

        //        }
        //        ViewBag.Message = removeServiceResult.Message;
        //    }
        //    ViewBag.Message = getServiceResult.Message;
        //}

        //[HttpGet]
        //public IActionResult Edit(Guid Id)
        //{
        //    return View(_mapper.Map<BrandViewModel>(_brandService.GetBrand(Id)));
        ////}

        //[HttpPost]
        //public IActionResult Edit(BrandViewModel brandViewModel)
        //{
        //    _brandService.Update(_mapper.Map<BrandDTO>(brandViewModel));

        //    return RedirectToAction("Index", "Brand");
        //}
    }
}

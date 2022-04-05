using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {
    public class BrandController : CrudController<Brand, BrandDTO, BrandViewModel, BrandService, Guid, BrandFilter> {
        public BrandController(BrandService service, IMapper mapper) : base(service, mapper) {
        }

        public IActionResult Index() {
            return View();
        }

        //[HttpGet]
        //public IActionResult Add()
        //{

        //    return View(new BrandViewModel { });
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

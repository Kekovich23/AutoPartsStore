using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {
    //[Authorize(Roles = "admin")]
    public class UserController : CrudController<User, UserDTO, UserViewModel, string, UserFilter> {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
       // private readonly UserService _userService;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, UserService userService, IMapper mapper, ILogger<CrudController<User, UserDTO, UserViewModel, string, UserFilter>> logger) : base(userService, mapper, logger) {
            _roleManager = roleManager;
            _userManager = userManager;
            //_userService = userService;
        }
        
        public IActionResult Index() {                  
            return View();
        }

        [HttpGet]
        public override async Task<IActionResult> Edit(string id) {
            ViewBag.AllRoles = _roleManager.Roles.ToList();
            ViewBag.isFailed = false;
            var result = await _service.Get(id);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<UserViewModel>(result.Data));
        }

        [HttpPost]
        public override IActionResult Edit(UserViewModel userViewModel) {
            ViewBag.isFailed = false;
            ViewBag.AllRoles = _roleManager.Roles.ToList();
            var result = _service.Update(_mapper.Map<UserDTO>(userViewModel));
            if (!result.IsSuccessful) {
                ViewBag.isFailed = true;
                ViewBag.ErrorMessage = result.Message;
                return View(_mapper.Map<UserViewModel>(result.Data));                
            }
            return RedirectToAction("Index");
        }
    }
}

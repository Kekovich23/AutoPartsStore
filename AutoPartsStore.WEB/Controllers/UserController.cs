using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Configure;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using AutoPartsStore.WEB.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsStore.WEB.Controllers {

    //[Authorize(Roles = RoleInitializer.AdminRoleName)]
    public class UserController : CrudController<User, UserDTO, UserViewModel, Guid, UserFilter> {
        private readonly UserService _userService;
        private readonly RoleManager<Role> _roleManager;
        public UserController(
            RoleManager<Role> roleManager,
            UserService service,
            IMapper mapper,
            ILogger<CrudController<User, UserDTO, UserViewModel, Guid, UserFilter>> logger) : base(service, mapper, logger) {
            _userService = service;
            _roleManager = roleManager;
        }
        protected override async Task<bool> InitDataAsync() {
            ViewBag.AllRoles = new SelectList(_roleManager.Roles.ToList());
            return true;
        }


        [HttpGet]
        public IActionResult AddUser() {
            _logger.LogInformation("Pressed 'Add' button.");
            ViewBag.AllRoles = new SelectList(_roleManager.Roles.ToList());
            return View("Create", new CreateUserViewModel { });
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserViewModel createUserViewModel) {
            var result = await _service.CreateAsync(_mapper.Map<UserDTO>(createUserViewModel));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View("Create", createUserViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangePassword(Guid id) {
            return View(new ChangePasswordUserViewModel { UserId = id });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordUserViewModel changePassword) {
            var result = await _userService.ChangePasswordAsync(_mapper.Map<ChangePasswordUserDTO>(changePassword));
            if (!result.IsSuccessful) {
                ErrorOccured(result.Message);
                return View(changePassword.UserId);
            }
            return View("Index");
        }

        private ServiceResult<UserCartDTO> GetCart(Guid userId) {
            return _userService.GetCart(userId);
        }

        public IActionResult Cart(Guid userId) {
            var result = GetCart(userId);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return View(_mapper.Map<UserCartViewModel>(result.Data));
        }

        public IActionResult ClearCart(Guid userId) {
            var result = _userService.ClearCart(userId);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            var cartResult = GetCart(userId);
            if (!cartResult.IsSuccessful) {
                return View("ErrorGet", cartResult.Message);
            }
            return View("Cart", _mapper.Map<UserCartViewModel>(cartResult.Data));
        }

        public async Task<IActionResult> AddDetailToCart(Guid userId, Guid detailId, int amount) {
            var result = await _userService.AddDetailAsync(userId, detailId, amount);
            if (!result.IsSuccessful) {
                return View("ErrorGet", result.Message);
            }
            return Ok();
        }
    }
}

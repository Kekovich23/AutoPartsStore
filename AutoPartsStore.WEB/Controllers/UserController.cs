using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.DAL.Configure;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using AutoPartsStore.WEB.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPartsStore.WEB.Controllers {

    [Authorize(Roles = RoleInitializer.AdminRoleName)]
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
                return View("Create" ,createUserViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangePassword(Guid id) {
            return View(new ChangePasswordUserViewModel { UserId = id});
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

        [HttpGet]
        public override Task<IActionResult> Edit(Guid id) {          
            ViewBag.AllRoles = new SelectList(_roleManager.Roles.ToList());
            return base.Edit(id);
        }
    }
}

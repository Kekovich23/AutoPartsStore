using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services;
using AutoPartsStore.WEB.Controllers.Base;
using AutoPartsStore.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsStore.WEB.Controllers {   

    //[Authorize(Roles = "admin")]
    public class UserController : CrudController<User, UserDTO, UserViewModel, Guid, UserFilter> {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        
        private readonly UserService _userService;

        public UserController(
            RoleManager<Role> roleManager,
            UserManager<User> userManager,
            UserService userService,
            IMapper mapper,
            ILogger<CrudController<User, UserDTO, UserViewModel, Guid, UserFilter>> logger) : base(userService, mapper, logger) {
            _roleManager = roleManager;
            _userManager = userManager;
            //_userService = userService;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model) {
            if (ModelState.IsValid) {
                User user = new User { Email = model.Email, UserName = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> EditUser(Guid id) {
            User user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model) {
            if (ModelState.IsValid) {
                User user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null) {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded) {
                        return RedirectToAction("Index");
                    }
                    else {
                        foreach (var error in result.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id) {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null) {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangePassword(string id) {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model) {
            if (ModelState.IsValid) {
                User user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null) {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded) {
                        return RedirectToAction("Index");
                    }
                    else {
                        foreach (var error in result.Errors) {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }

        //[HttpGet]
        //public override async Task<IActionResult> Edit(string id) {
        //    ViewBag.AllRoles = _roleManager.Roles.ToList();
        //    ViewBag.isFailed = false;
        //    var result = await _service.Get(id);
        //    if (!result.IsSuccessful) {
        //        return View("ErrorGet", result.Message);
        //    }
        //    return View(_mapper.Map<UserViewModel>(result.Data));
        //}

        //[HttpPost]
        //public override IActionResult Edit(UserViewModel userViewModel) {
        //    ViewBag.isFailed = false;
        //    ViewBag.AllRoles = _roleManager.Roles.ToList();
        //    var result = _service.Update(_mapper.Map<UserDTO>(userViewModel));
        //    if (!result.IsSuccessful) {
        //        ErrorOccured(result.Message);
        //        return View(_mapper.Map<UserViewModel>(result.Data));                
        //    }
        //    return RedirectToAction("Index");
        //}

        private void ErrorOccured(string errorMessage) {
            ViewBag.isFailed = true;
            ViewBag.ErrorMessage = errorMessage;
        }
    }
}

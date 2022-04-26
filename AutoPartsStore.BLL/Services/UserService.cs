using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.AN.Entities.Complex;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;

namespace AutoPartsStore.BLL.Services {
    public class UserService : BaseService<User, UserDTO, Guid, UserFilter> {
        private readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<BaseService<User, UserDTO, Guid, UserFilter>> logger) : base(uow, mapper, logger) {
            _userManager = userManager;
        }

        private static void CatchException(IdentityResult result) {
            if (!result.Succeeded) {
                throw new Exception(CollectErrors(result.Errors));
            }
        }

        private static string CollectErrors(IEnumerable<IdentityError> errors) {
            if (errors == null) {
                return string.Empty;
            }
            return string.Join(" ", errors);
        }

        protected override IQueryable<User> FilterOut(IQueryable<User> query, UserFilter filter) {
            if (!string.IsNullOrWhiteSpace(filter.UserName)) {
                query = query.Where(m => m.UserName.ToLower() == filter.UserName.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(filter.Email)) {
                query = query.Where(m => m.Email.ToLower() == filter.Email.ToLower());
            }

            return query;
        }

        protected override IQueryable<User> OrderBy(IQueryable<User> query, UserFilter filter) {
            if (!(string.IsNullOrEmpty(filter.SortColumn) && string.IsNullOrEmpty(filter.SortColumnDir))) {
                if (filter.SortColumn != "Role" && filter.SortColumnDir != "Role") {
                    query = query.OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
                }
                else {
                    var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(query);
                    usersDTO = usersDTO.AsQueryable().OrderBy(filter.SortColumn + " " + filter.SortColumnDir);
                    var result = _mapper.Map<IEnumerable<User>>(usersDTO);
                    query = result.AsQueryable();
                }
            }

            return query;
        }

        private async Task<IdentityResult> SetRoleForUser(Guid id, string role) {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _userManager.GetRolesAsync(user);

            CatchException(await _userManager.RemoveFromRolesAsync(user, (IEnumerable<string>)roles));

            return await _userManager.AddToRoleAsync(user, role);
        }

        public override async Task<ServiceResult<UserDTO>> CreateAsync(UserDTO userDTO) {
            try {
                var user = _mapper.Map<User>(userDTO);

                CatchException(await _userManager.CreateAsync(user, userDTO.NewPassword));

                CatchException(await SetRoleForUser(userDTO.Id, userDTO.Role));

                return ServiceResult<UserDTO>.Success(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to create");
                return ServiceResult<UserDTO>.Failed("Failed to create");
            }
        }

        public override async Task<ServiceResult> RemoveAsync(Guid id) {
            try {
                CatchException(await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString())));

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to remove");
                return ServiceResult.Failed("Failed to remove");
            }
        }

        public override async Task<ServiceResult<UserDTO>> UpdateAsync(UserDTO userDTO) {
            try {
                User user = await _userManager.FindByIdAsync(userDTO.Id.ToString());

                user.Email = userDTO.Email;
                user.UserName = userDTO.UserName;

                CatchException(await _userManager.UpdateAsync(user));

                CatchException(await SetRoleForUser(userDTO.Id, userDTO.Role));

                return ServiceResult<UserDTO>.Success(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to update");
                return ServiceResult<UserDTO>.Failed(ex.Message, userDTO);
            }
        }

        public async Task<ServiceResult> ChangePasswordAsync(ChangePasswordUserDTO changePassword) {
            try {
                CatchException(await _userManager.ChangePasswordAsync(
                    await _userManager.FindByIdAsync(changePassword.UserId.ToString()),
                    changePassword.OldPassword,
                    changePassword.NewPassword));
                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to change password");
                return ServiceResult.Failed(ex.Message);
            }
        }

        public async Task<ServiceResult> SetRole(Guid id, string role) {
            try {
                CatchException(await SetRoleForUser(id, role));
                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to set role");
                return ServiceResult.Failed(ex.Message);
            }
        }

        public override UserFilter GetFilter(IFormCollection form) {
            UserFilter filter = new();
            filter = InitFilter(form, filter);
            filter.UserName = form["UserName"].FirstOrDefault();
            filter.Email = form["Email"].FirstOrDefault();
            return filter;
        }

        public async Task<ServiceResult> AddDetailAsync(Guid userId, Guid detailId, int amount) {
            try {
                if (amount == 0) {
                    var cart = Database.GetRepository<Cart>().GetAll().Where(e => e.DetailId == detailId).Where(e => e.UserId == userId);
                    if (cart.Any()) {
                        Database.GetRepository<Cart>().Remove(cart.FirstOrDefault());
                    }
                }
                else {
                    Cart cart = new Cart { Amount = amount, DetailId = detailId, UserId = userId };
                    Database.GetRepository<Cart>().Create(cart);
                }

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to add detail to cart");
                return ServiceResult.Failed(ex.Message);
            }
        }

        public ServiceResult ClearCart(Guid userId) {
            try {
                var carts = Database.GetRepository<Cart>().GetAll().Where(e => e.UserId == userId).ToList();

                foreach (var cart in carts) {
                    Database.GetRepository<Cart>().Remove(cart);
                }

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                return ServiceResult.Failed(ex.Message);
            }
        }

        public ServiceResult<UserCartDTO> GetCart(Guid userId) {
            try {
                var carts = Database.GetRepository<Cart>().GetAll().Where(e => e.UserId == userId).ToList();

                UserCartDTO userCartDTO = new() { UserId = userId, Details = new() };

                foreach (var cart in carts) {
                    DetailInCartDTO detailInCartDTO = new() {
                        Detail = _mapper.Map<DetailDTO>(Database.GetRepository<Detail>()
                        .GetAll()
                        .Where(e => e.Id == cart.DetailId)
                        .Include(e => e.Manufacturer)
                        .Include(e => e.TypeDetail)
                        .FirstOrDefault()),
                        Amount = cart.Amount
                    };
                    userCartDTO.Details.Add(detailInCartDTO);
                }

                return ServiceResult<UserCartDTO>.Success(userCartDTO);
            }
            catch (Exception ex) {
                return ServiceResult<UserCartDTO>.Failed(ex.Message);
            }
        }
    }
}

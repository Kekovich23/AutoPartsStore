using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.BLL.Services.Base;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

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
                return String.Empty;
            }
            return String.Join(" ", errors);
        }

        // TODO: override Include and FilterOut

        protected override IQueryable<User> FilterOut(IQueryable<User> query, UserFilter filter) {
            return base.FilterOut(query, filter);
        }

        private async Task<IdentityResult> SetRoleForUser(Guid id, string role) {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _userManager.GetRolesAsync(user);

            CatchException(await _userManager.RemoveFromRolesAsync(user, (IEnumerable<string>)roles));

            return await _userManager.AddToRoleAsync(user, role);
        }

        public override async Task<ServiceResult<UserDTO>> Create(UserDTO userDTO) {
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

        public override async Task<ServiceResult> Remove(Guid id) {
            try {
                CatchException(await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString())));

                return ServiceResult.Success();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to remove");
                return ServiceResult.Failed("Failed to remove");
            }
        }

        public override async Task<ServiceResult<UserDTO>> Update(UserDTO userDTO) {
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
    }
}

using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services {
    public class UserService : BaseService<User, UserDTO, Guid, UserFilter> {
        private readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager,
            IUnitOfWork uow, IMapper mapper,
            ILogger<BaseService<User, UserDTO,
            Guid, UserFilter>> logger) : base(uow, mapper, logger) {
            _userManager = userManager;
        }

        public override async Task<ServiceResult<IEnumerable<UserDTO>>> GetAll(UserFilter filter) {
            try {
                var query = _userManager.Users;

                List<UserDTO> result = new();

                query = Include(query);

                query = FilterOut(query, filter);

                foreach (User user in query.ToList()) {
                    //UserDTO userDTO = await new(_userManager.GetRolesAsync(user));
                    UserDTO userDTO = _mapper.Map<UserDTO>(user);
                    result.Add(userDTO);
                }

                return ServiceResult<IEnumerable<UserDTO>>.Success(_mapper.Map<IEnumerable<UserDTO>>(result));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get all");
                return ServiceResult<IEnumerable<UserDTO>>.Failed("Failed to get all");
            }
        }

        public override async Task<ServiceResult<UserDTO>> Create(UserDTO userDTO) {
            try {
                var user = _mapper.Map<User>(userDTO);

                var result = await _userManager.CreateAsync(user, userDTO.NewPassword);

                if (!result.Succeeded) {
                    string err = "";
                    foreach (var error in result.Errors) {
                        err += error.Description + " ";
                    }
                    throw new Exception(err);
                }

                return ServiceResult<UserDTO>.Success(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to create");
                return ServiceResult<UserDTO>.Failed("Failed to create");
            }
        }

        //public override async Task<ServiceResult<UserDTO>> Get(string id) {
        //    try {
        //        var user = await _userManager.FindByIdAsync(id);

        //        var userDTO = new UserDTO {
        //            Id = user.Id,
        //            Name = user.UserName,
        //            Email = user.Email,
        //            Role = await _userManager.GetRolesAsync(user)
        //        };

        //        return ServiceResult<UserDTO>.Success(userDTO);
        //    }
        //    catch (Exception ex) {
        //        _logger.LogError(ex, "Failed to get");
        //        return ServiceResult<UserDTO>.Failed("Failed to get");
        //    }
        //}

        public override async Task<ServiceResult> Remove(Guid id) {
            try {
                User user = await _userManager.FindByIdAsync(id.ToString());

                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded) {
                    string err = "";
                    foreach (var error in result.Errors) {
                        err += error.Description + " ";
                    }
                    throw new Exception(err);
                }

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

                if (user != null) {
                    user.Email = userDTO.Email;
                    user.UserName = userDTO.UserName;

                   var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded) {
                        string err = "";
                        foreach (var error in result.Errors) {
                            err += error.Description + " ";
                        }
                        throw new Exception(err);
                    }
                }

                if (!string.IsNullOrEmpty(userDTO.NewPassword)) {
                    var result = await _userManager.ChangePasswordAsync(user, userDTO.OldPassword, userDTO.NewPassword);
                    if (!result.Succeeded) {
                        string err = "";
                        foreach (var error in result.Errors) {
                            err += error.Description + " ";
                        }
                        throw new Exception(err);
                    }
                }

                return ServiceResult<UserDTO>.Success(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to update");
                return ServiceResult<UserDTO>.Failed("Failed to update", userDTO);
            }
        }
    }
}

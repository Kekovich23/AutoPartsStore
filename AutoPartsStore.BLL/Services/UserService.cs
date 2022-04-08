using AutoMapper;
using AutoPartsStore.AN.DTO;
using AutoPartsStore.AN.Entities;
using AutoPartsStore.BLL.Filters;
using AutoPartsStore.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AutoPartsStore.BLL.Services {
    public class UserService : BaseService<User, UserDTO, string, UserFilter> {
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager, IUnitOfWork uow, IMapper mapper, ILogger<BaseService<User, UserDTO, string, UserFilter>> logger) : base(uow, mapper, logger) {
            _userManager = userManager;
        }

        public override async Task<ServiceResult<IEnumerable<UserDTO>>> GetAll(UserFilter filter) {
            try {
                var query = _userManager.Users;                

                List<UserDTO> result = new();

                query = Include(query);

                query = FilterOut(query, filter);

                foreach (var user in query.ToList()) {
                    var userDTO = new UserDTO {
                        Id = user.Id,
                        Name = user.UserName,
                        Email = user.Email,
                        Role = await _userManager.GetRolesAsync(user)
                    };
                    result.Add(userDTO);
                }
                
                return ServiceResult<IEnumerable<UserDTO>>.Success(_mapper.Map<IEnumerable<UserDTO>>(result));
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get all");
                return ServiceResult<IEnumerable<UserDTO>>.Failed("Failed to get all");
            }
        }

        public override async Task<ServiceResult<UserDTO>> Get(string id) {
            try {
                var user = await _userManager.FindByIdAsync(id);

                var userDTO = new UserDTO {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Role = await _userManager.GetRolesAsync(user)
                };

                return ServiceResult<UserDTO>.Success(userDTO);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to get");
                return ServiceResult<UserDTO>.Failed("Failed to get");
            }
        }

        public override ServiceResult<UserDTO> Update(UserDTO userDTO) {
            try {
                Database.GetRepository<User>().Update(_mapper.Map<User>(userDTO));
                return ServiceResult<UserDTO>.Success(userDTO);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to update");
                return ServiceResult<UserDTO>.Failed("Failed to update", userDTO);
            }
        }
    }
}

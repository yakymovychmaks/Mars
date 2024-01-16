using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Extensions;
using Domain.Helpers;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IRepository<Profile> _profilesRepository;
        private readonly IRepository<User> _userRepository;
        public UserService(ILogger<UserService> logger, IRepository<Profile> profilesRepository, IRepository<User> userRepository)
        {
            _logger = logger;
            _profilesRepository = profilesRepository;
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<User>> Create(User model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user != null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Користувач такий вже існує",
                        StatusCode = StatusCode.UserAlreadyExists
                    };
                }
                user = new User()
                {
                    Name = model.Name,
                    Role = model.Role,
                    Password = HashPasswordHelper.HashPassowrd(model.Password),
                    Profile = model.Profile,
                    Posts = new List<Post>()
                };
                await _userRepository.Create(user);
                return new BaseResponse<User>()
                {
                    Data = user,
                    Description = "Користувача створено",
                    StatusCode = StatusCode.OK
                };
            }    
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.Create] error: {ex.InnerException}");
                return new BaseResponse<User>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.InnerException}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user == null)
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                await _userRepository.Delete(user);

                _logger.LogInformation($"[UserService.DeleteUser] користувача видалено");

                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.DeleteUser] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public BaseResponse<Dictionary<int, string>> GetRoles()
        {
            try
            {
                var role = ((Role[])Enum.GetValues(typeof(Role)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = role,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll()
                    .Select(x => new User()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Role = x.Role
                    })
                    .ToListAsync();
                _logger.LogInformation($"[UserService.GetUsers] отримано елементів {users.Count}");
                return new BaseResponse<IEnumerable<User>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
                return new BaseResponse<IEnumerable<User>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутрішня помилка: {ex.Message}"
                };
            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> Login(string LoginsUser, string password)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == LoginsUser);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Невірне ім'я користувача"
                    };
                }
                if (user.Password != password)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Невірний пароль користувача"
                    };
                }
                var rezult = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = rezult,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<bool>> ChangePassword(string LoginsUser, string Password)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == LoginsUser);
                if(user == null)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Невірне ім'я користувача"
                    };
                }
                user.Password = HashPasswordHelper.HashPassowrd(Password);
                await _userRepository.Update(user);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Пароль оновленно"
                };
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
    
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
using BLL.Tokens;
using Microsoft.AspNetCore.Identity;
using Domain.LoginModels;

namespace BLL.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        //private readonly IRepository<Profile> _profilesRepository;
        //private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(ILogger<UserService> logger,   UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public async Task<IBaseResponse<RegisterViewModel>> Register(RegisterViewModel model)
        {
            CreateDefaultRoles();
            var user = new User { UserName = model.Name ,Name = model.Name, Email = model.Email, SureNme = model.Surename, Profile = new Profile { Age = 18,Address="masfni", Apointment = null} };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(user, "USER");
                await _signInManager.SignInAsync(user, false);
                return new BaseResponse<RegisterViewModel>()
                {
                    Data = null,
                    Description = "Success",
                    StatusCode = StatusCode.OK
                };
            }
            else
            {
                List<string> errors = new List<string>();
                foreach(var error in result.Errors)
                {
                    var errorDescription = error.Description;
                    errors.Add(errorDescription);
                }
                return new BaseResponse<RegisterViewModel>()
                {
                    Data = null,
                    Description = errors.ToString(),
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<LoginModel>> Login(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Name,loginModel.Password,false,false);
            if(result.Succeeded)
            {
                return new BaseResponse<LoginModel>()
                {
                    Data = null,
                    Description = "Succes",
                    StatusCode = StatusCode.OK
                };
            }
            else
            {
                return new BaseResponse<LoginModel>()
                {
                    Data = null,
                    Description = result.ToString() ,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async void CreateDefaultRoles()
        {
            var roles = await _roleManager.RoleExistsAsync("USER");
            if (roles == null) 
            {
                await _roleManager.CreateAsync(new IdentityRole("USER")); 
            }
        }
        //public async Task<IBaseResponse<User>> Create(User model)
        //{
        //    return null;
        //    //try
        //    //{
        //        var user1 = await _userManager.CreateAsync(model);
        //    //    var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
        //    //    if (user != null)
        //    //    {
        //    //        return new BaseResponse<User>()
        //    //        {
        //    //            Description = "Користувач такий вже існує",
        //    //            StatusCode = StatusCode.UserAlreadyExists
        //    //        };
        //    //    }
        //    //    user = new User()
        //    //    {
        //    //        Name = model.Name,
        //    //        Role = model.Role,
        //    //        Password = HashPasswordHelper.HashPassowrd(model.Password),
        //    //        Profile = model.Profile,
        //    //    };
        //    //    await _userRepository.Create(user);
        //    //    return new BaseResponse<User>()
        //    //    {
        //    //        Data = user,
        //    //        Description = "Користувача створено",
        //    //        StatusCode = StatusCode.OK
        //    //    };
        //    //}    
        //    //catch (Exception ex)
        //    //{
        //    //    _logger.LogError(ex, $"[UserService.Create] error: {ex.InnerException}");
        //    //    return new BaseResponse<User>()
        //    //    {
        //    //        StatusCode = StatusCode.InternalServerError,
        //    //        Description = $"Внутрішня помилка: {ex.InnerException}"
        //    //    };
        //    //}
        ////}

        //public async Task<IBaseResponse<bool>> DeleteUser(int id)
        //{
        //    try
        //    {
        //        var user = await _userRepository.GetById(id);
        //        if (user == null)
        //            return new BaseResponse<bool>
        //            {
        //                StatusCode = StatusCode.UserNotFound,
        //                Data = false
        //            };
        //        await _userRepository.Delete(user);

        //        _logger.LogInformation($"[UserService.DeleteUser] користувача видалено");

        //        return new BaseResponse<bool>
        //        {
        //            StatusCode = StatusCode.OK,
        //            Data = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"[UserSerivce.DeleteUser] error: {ex.Message}");
        //        return new BaseResponse<bool>()
        //        {
        //            StatusCode = StatusCode.InternalServerError,
        //            Description = $"Внутренняя ошибка: {ex.Message}"
        //        };
        //    }
        //}

        //public BaseResponse<Dictionary<int, string>> GetRoles()
        //{
        //    try
        //    {
        //        var role = ((Role[])Enum.GetValues(typeof(Role)))
        //            .ToDictionary(k => (int)k, t => t.GetDisplayName());
        //        return new BaseResponse<Dictionary<int, string>>()
        //        {
        //            Data = role,
        //            StatusCode = StatusCode.OK,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<Dictionary<int, string>>()
        //        {
        //            Description = ex.Message,
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public async Task<BaseResponse<IEnumerable<User>>> GetUsers()
        //{
        //    try
        //    {
        //        var users = await _userRepository.GetAll()
        //            .Select(x => new User()
        //            {
        //                Id = x.Id,
        //                Name = x.Name,
        //                //Role = x.Role
        //            })
        //            .ToListAsync();
        //        _logger.LogInformation($"[UserService.GetUsers] отримано елементів {users.Count}");
        //        return new BaseResponse<IEnumerable<User>>()
        //        {
        //            Data = users,
        //            StatusCode = StatusCode.OK
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
        //        return new BaseResponse<IEnumerable<User>>()
        //        {
        //            StatusCode = StatusCode.InternalServerError,
        //            Description = $"Внутрішня помилка: {ex.Message}"
        //        };
        //    }
        //}

        //public async Task<BaseResponse<ClaimsIdentity>> Login(string LoginsUser, string password)
        //{
        //    try
        //    {
        //        var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == LoginsUser);
        //        if (user == null || user.SureNme != HashPasswordHelper.HashPassowrd(password))
        //        {
        //            return new BaseResponse<ClaimsIdentity>()
        //            {
        //                StatusCode = StatusCode.UserNotFound,
        //                Description = "Невірне ім'я користувача або пароль"
        //            };
        //        }
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        //        };

        //        // Додайте інші клейми за потребою
        //        GenerarorKeyTokenHelper generatorKeys = new GenerarorKeyTokenHelper();
        //        var expires = DateTime.UtcNow.AddHours(1); // Термін дії токену

        //        // Створіть екземпляр JwtTokenGenerator з вашим секретним ключем
        //        var tokenGenerator = new GeneratToken(generatorKeys.GenerateRandomSymmetricKey());

        //        // Використовуйте JwtTokenGenerator для генерації токену
        //        var token = tokenGenerator.GenerateToken(claims, expires);

        //        var response = new
        //        {
        //            Data = new ClaimsIdentity(claims, "ApplicationCookie",
        //                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType),
        //            StatusCode = StatusCode.OK,
        //            Description = "Успішний вхід",
        //            TemporaryToken = token
        //        };

        //        return new BaseResponse<ClaimsIdentity>()
        //        {
        //            Data = response.Data,
        //            StatusCode = StatusCode.OK,
        //            Description = response.TemporaryToken

        //        };
        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError(ex, $"[Login]: {ex.Message}");
        //        return new BaseResponse<ClaimsIdentity>()
        //        {
        //            Description = ex.Message,
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}
        //public async Task<BaseResponse<bool>> ChangePassword(string LoginsUser, string Password)
        //{
        //    try
        //    {
        //        var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == LoginsUser);
        //        if(user == null)
        //        {
        //            return new BaseResponse<bool>()
        //            {
        //                StatusCode = StatusCode.UserNotFound,
        //                Description = "Невірне ім'я користувача"
        //            };
        //        }
        //        user.Password = HashPasswordHelper.HashPassowrd(Password);
        //        await _userRepository.Update(user);

        //        return new BaseResponse<bool>()
        //        {
        //            Data = true,
        //            StatusCode = StatusCode.OK,
        //            Description = "Пароль оновленно"
        //        };
        //    }catch(Exception ex)
        //    {
        //        _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
        //        return new BaseResponse<bool>()
        //        {
        //            Description = ex.Message,
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}
        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                //new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("UserId",user.Id.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
    
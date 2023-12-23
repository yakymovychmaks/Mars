using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Helpers;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _loger;
        private readonly IRepository<Profiles> _profilesRepository;
        private readonly IRepository<User> _userRepository;
        public UserService(ILogger<UserService> loger, IRepository<Profiles> profilesRepository, IRepository<User> userRepository)
        {
            _loger = loger;
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
            }    
        }

        public Task<IBaseResponse<bool>> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<Dictionary<int, string>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<User>>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}

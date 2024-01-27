using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Response;
using Microsoft.Extensions.Logging;
using Domain;
using Domain.Enum;

namespace BLL.Services
{
    internal class PostService : IPostService
    {

        private readonly IRepository<Post> _postRepository;
        private readonly ILogger<PostService> _postLogger;
        public PostService(IRepository<Post> postRepository, ILogger<PostService> postLogger) 
        {
            _postRepository = postRepository;
            _postLogger = postLogger;
        }
        public async Task<IBaseResponse<Post>> Create(Post post, User user)
        {
            try
            {
                if (user.Role == Role.Admin)
                {
                    await _postRepository.Create(post);
                    return new BaseResponse<Post>()
                    {
                        Data = post,
                        Description = "Пост успішно створено",
                        StatusCode = StatusCode.OK
                    };
                }
                else if (user.Role != Role.Admin)
                    return new BaseResponse<Post>()
                    {
                        Data = null,
                        Description = "Ви не володієте достатнім рівнем доступу",
                        StatusCode = StatusCode.InternalServerError
                    };
                else
                    return new BaseResponse<Post>()
                    {
                        Data = null,
                        Description = "Упс щось не так",
                        StatusCode = StatusCode.InternalServerError
                    };
            }
            catch (Exception ex)
            {
                _postLogger.LogError(ex, $"[PostService.Create] error: {ex.InnerException}");
                return new BaseResponse<Post>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Post>> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<Post>>> GetAll(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Post>> Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

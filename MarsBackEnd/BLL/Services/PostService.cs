using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Response;
using Microsoft.Extensions.Logging;
using Domain;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IBaseResponse<bool>> Delete(int id, User user)
        {
            try
            {
                if (user.Role == Role.Admin)
                {
                    Post rezult = await _postRepository.GetById(id);
                    if (rezult != null)
                    {
                        await _postRepository.Delete(rezult);
                        return new BaseResponse<bool>()
                        {
                            Data = true,
                            Description = "Ви видалили цей пост",
                            StatusCode = StatusCode.OK
                        };
                    }
                    else
                        return new BaseResponse<bool>()
                        {
                            Data = false,
                            Description = "Такого посту не існує",
                            StatusCode = StatusCode.InternalServerError
                        };
                }
                else return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Упс щось пішло не так",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            catch (Exception ex)
            {
                _postLogger.LogError(ex, $"[PostService Delete] error: {ex.InnerException}");
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Post>> GetPost(int id)
        {
            try
            {
                var rezult = await _postRepository.GetById(id);
                return new BaseResponse<Post>()
                {
                    Data = rezult,
                    Description = "Ось пост",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _postLogger.LogError(ex, $"[PoserService GetPost] error: {ex.InnerException}");
                return new BaseResponse<Post>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Post>>> GetAll(int userId)
        {
            try
            {
                var posts = await _postRepository.GetAll()
                    .Select(x => new Post()
                    {
                        Id = x.Id,
                        title = x.title,
                        Description = x.Description
                    })
                    .ToListAsync();
                _postLogger.LogInformation($"[PostService.GetAll] отримано елементів {posts.Count}");
                return new BaseResponse<IEnumerable<Post>>()
                {
                    Data = posts,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _postLogger.LogError(ex, $"[PostService.GetAll] error: {ex.InnerException}");
                return new BaseResponse<IEnumerable<Post>>
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Post>> Update(Post post, User user)
        {
            try
            {
                if(user.Role == Role.Admin)
                {
                    var updatePost = await _postRepository.GetById(post.Id);
                    if (updatePost != null)
                    {
                        updatePost.title = post.title;
                        updatePost.Description = post.Description;
                        await _postRepository.Update(updatePost);
                    }
                    else
                    {
                        return new BaseResponse<Post>()
                        {
                            Data = null,
                            Description = "такого посту не існує",
                            StatusCode = StatusCode.OK
                        };
                    }
                }
                else
                {
                    return new BaseResponse<Post>
                    {
                        Data = null,
                        Description = "Упс",
                        StatusCode = StatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                _postLogger.LogError(ex, $"[PostService.Update] error: {ex.InnerException}");
                return new BaseResponse<Post>
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}

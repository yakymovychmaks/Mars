using Domain.Entity;
using BLL.Interface;
using Domain.Response;
using System.Security.Claims;
using DLL.Repository;
using Domain.Enum;

namespace BLL.Services
{
    public class BlogService : IBlogService
    {
        private readonly BlogRepository _blogRepository;
        public BlogService(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IBaseResponse<Blog>> Create(Blog blog, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
               if(claimsPrincipal.IsInRole("Admin") || claimsPrincipal.IsInRole("Moderator"))
                {
                    await _blogRepository.Create(blog);
                    return new BaseResponse<Blog>
                    {
                        Data = blog,
                        Description = "Ваш блог успішно створений",
                        StatusCode = Domain.Enum.StatusCode.OK
                    };
                }
                return new BaseResponse<Blog>()
                {
                    Data = null,
                    Description = "У вас недостатгьо прав",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Blog>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if (claimsPrincipal.IsInRole("Admin") || claimsPrincipal.IsInRole("Moderator"))
                {
                    var blog = await _blogRepository.GetById(id);
                    if (blog == null)
                    {
                        return new BaseResponse<bool>()
                        {
                            Data = false,
                            Description = "Такого поста не існує",
                            StatusCode = StatusCode.OK
                        };
                    }
                    await _blogRepository.Delete(blog);
                    return new BaseResponse<bool>()
                    {
                        Data = true,
                        Description = "Ваш блог видалено",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "У вас недостатньо прав",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Blog>>> GetAll()
        {
            try
            {
                var blog = _blogRepository.GetAll()
                    .Select(blog => new Blog
                    {
                        tags = blog.tags,
                        posts = blog.posts
                    }).ToList();
                return new BaseResponse<IEnumerable<Blog>>()
                {
                    Data = blog,
                    Description = "Ось ваші блоги",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex )
            {
                return new BaseResponse<IEnumerable<Blog>>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Blog>> GetById(int id)
        {
            try
            {
                var blog = await _blogRepository.GetById(id);
                if (blog == null)
                    return new BaseResponse<Blog>()
                    {
                        Data = null,
                        Description = "Такого блогу немає",
                        StatusCode = StatusCode.OK
                    };
                return new BaseResponse<Blog>()
                {
                    Data = blog,
                    Description = "Ось ваш блог",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Blog>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Blog>> Update(Blog blog, ClaimsPrincipal claimsPrincipal)
        {
            try
            {

                if(claimsPrincipal.IsInRole("Admin") || claimsPrincipal.IsInRole("Moderator"))
                {
                    await _blogRepository.Update(blog);
                    return new BaseResponse<Blog>()
                    {
                        Data = blog,
                        Description = "Ваш блог успішно оновлено",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<Blog>()
                {
                    Data = blog,
                    Description = "У вас недостатньо прав",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Blog>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}

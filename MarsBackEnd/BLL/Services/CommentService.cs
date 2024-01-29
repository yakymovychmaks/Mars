using BLL.Interface;
using DLL.Interface;
using DLL.Repository;
using Domain.Entity;
using Domain.Enum;
using Domain.Helpers;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class CommentService : ICommentService
    {

        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Post> _postRepository;
        private readonly ILogger<CommentService> _commentLogger;
        public CommentService(IRepository<Comment> commentRepository, ILogger<CommentService> commentLogger, IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _commentLogger = commentLogger;
        }
        public async Task<IBaseResponse<Comment>> Create(Comment comment, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if (claimsPrincipal.IsInRole("admin") || claimsPrincipal.IsInRole("User"))
                {
                    var post = _postRepository.GetById(comment.Id);
                    if(post != null)
                    {
                        await _commentRepository.Create(comment);
                        return new BaseResponse<Comment>()
                        {
                            Data = comment,
                            Description = "Коментар успішно створено",
                            StatusCode = StatusCode.OK
                        };
                    }
                    else
                    {
                        return new BaseResponse<Comment>()
                        {
                            Data = null,
                            Description = "Такого поста не існує",
                            StatusCode = StatusCode.OK
                        };
                    }
                }
                else
                {
                    return new BaseResponse<Comment>()
                    {
                        Data = null,
                        Description = "У вас недостатньо прав для створення коментарая",
                        StatusCode = StatusCode.OK
                    };
                }
            }
            catch (Exception ex)
            {
                _commentLogger.LogError($"[CommentService.Create] error: {ex.InnerException}");
                return new BaseResponse<Comment>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if(claimsPrincipal.IsInRole("admin") || claimsPrincipal.IsInRole("Moderator"))
                {
                    var result = await _commentRepository.GetById(id);
                    if(result != null)
                    {
                        await _commentRepository.Delete(result);
                        return new BaseResponse<bool>()
                        {
                            Data = true,
                            Description = "Комент успішно видалено",
                            StatusCode = StatusCode.OK
                        };
                    }
                    else
                    {
                        return new BaseResponse<bool>()
                        {
                            Data = false,
                            Description = "Такого коментаря не існує",
                            StatusCode = StatusCode.OK
                        };
                    }
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Description = "Ви не можете видалити цей коментар",
                        StatusCode = StatusCode.OK
                    };
                }
            }
            catch (Exception ex)
            {
                _commentLogger.LogError(ex,$"[Comment.Delete] error: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Comment>>> GetAll()
        {
            try
            {
                var comment = await _commentRepository.GetAll()
                    .Select(x => new Comment
                    {
                        Id = x.Id,
                        Description = x.Description,
                        PostId = x.PostId
                    })
                    .ToListAsync();
                return new BaseResponse<IEnumerable<Comment>>()
                {
                    Data = comment,
                    Description = "Ось всі коментарі",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _commentLogger.LogError(ex, $"[CommentService.GetAll] error: {ex.Message}");
                return new BaseResponse<IEnumerable<Comment>>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Comment>> GetComment(int id)
        {
            try
            {
                var result = await _commentRepository.GetById(id);
                if (result == null)
                {
                    return new BaseResponse<Comment>()
                    {
                        Data = null,
                        Description = "Такого коментаря не існує",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<Comment>()
                {
                    Data = result,
                    Description = "Ось коментар",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _commentLogger.LogError(ex, $"[CommentService.GetComment] error: {ex.Message}");
                return new BaseResponse<Comment>()
                {
                    Data = null,
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        //public Task<IBaseResponse<Comment>> Update(Comment comment, ClaimsPrincipal claimsPrincipal)
        //{
        //    try
        //    {

        //    }
        //}
    }
}

using Domain.Entity;
using Domain.Response;
using System.Security.Claims;

namespace BLL.Interface
{
    public interface ICommentService
    {
        Task<IBaseResponse<Comment>> Create(Comment comment, ClaimsPrincipal claimsPrincipal);

        //Task<IBaseResponse<Comment>> Update(Comment comment, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal claimsPrincipal);

        Task<IBaseResponse<Comment>> GetComment(int id);

        Task<IBaseResponse<IEnumerable<Comment>>> GetAll();
    }
}

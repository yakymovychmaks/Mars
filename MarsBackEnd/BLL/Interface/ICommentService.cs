using Domain.Entity;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

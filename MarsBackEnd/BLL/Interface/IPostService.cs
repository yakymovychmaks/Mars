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
    public interface IPostService
    {

        Task<IBaseResponse<Post>> Create(Post post, ClaimsPrincipal user);
        Task<IBaseResponse<Post>> Update(Post post, ClaimsPrincipal user);

        Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal user);

        Task<IBaseResponse<Post>> GetPost(int id);

        Task<IBaseResponse<IEnumerable<Post>>> GetAll();
    }
}

using Domain.Entity;
using Domain.Response;
using System.Security.Claims;


namespace BLL.Interface
{
    public interface IBlogService
    {
        Task<IBaseResponse<Blog>> Create(Blog blog, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<Blog>> Update(Blog blog, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<bool>> Delete(int id, ClaimsPrincipal claimsPrincipal);
        Task<IBaseResponse<IEnumerable<Blog>>> GetAll();
        Task<IBaseResponse<Blog>> GetById(int id);
    }
}

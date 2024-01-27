using Domain.Entity;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    internal interface IPostService
    {

        Task<IBaseResponse<Post>> Create(Post post, User user);
        Task<IBaseResponse<Post>> Update(Post post);

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Post>> GetPost(int id);

        Task<IBaseResponse<IEnumerable<Post>>> GetAll(int userId);
    }
}

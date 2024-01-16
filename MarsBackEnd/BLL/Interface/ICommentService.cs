using Domain.Entity;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    internal interface ICommentService
    {
        Task<IBaseResponse<Comment>> Create(Comment comment);

        Task<IBaseResponse<Comment>> Update(Comment comment);
        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Comment>> GetComment(int id);

        Task<IBaseResponse<IEnumerable<Comment>>> GetAll();
    }
}

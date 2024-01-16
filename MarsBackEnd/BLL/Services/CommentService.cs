using BLL.Interface;
using DLL.Interface;
using DLL.Repository;
using Domain.Entity;
using Domain.Enum;
using Domain.Helpers;
using Domain.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class CommentService : ICommentService
    {

        private readonly IRepository<Comment> _commentRepository;
        private readonly ILogger<CommentService> _commentLogger;
        public CommentService(IRepository<Comment> commentRepository, ILogger<CommentService> commentLogger)
        {
            _commentRepository = commentRepository;
            _commentLogger = commentLogger;
        }
        public Task<IBaseResponse<Comment>> Create(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<Comment>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Comment>> GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Comment>> Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}

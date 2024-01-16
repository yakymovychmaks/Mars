using BLL.Interface;
using DLL.Interface;
using Domain.Entity;
using Domain.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Task<IBaseResponse<Post>> Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Post>> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<Post>>> GetAll(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Post>> Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

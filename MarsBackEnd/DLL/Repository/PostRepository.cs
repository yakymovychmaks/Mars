using DLL.DataAccess;
using DLL.Interface;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _dbContext;
        public PostRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task Create(Post entity)
        {
            await _dbContext.Posts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Post entity)
        {
            _dbContext.Posts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts.ToList();
        }

        public async Task<Post> GetById(int id)
        {

            var result = await _dbContext.Posts.FindAsync(id);
            return result;

        }

        public async Task<Post> Update(Post entity)
        {
            var result = await _dbContext.Posts.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

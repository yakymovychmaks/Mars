using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

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

        public IQueryable<Post> GetAll()
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

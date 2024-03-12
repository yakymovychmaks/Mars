using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace DLL.Repository
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly ApplicationDbContext _dbContext;
        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Blog entity)
        {
            await _dbContext.Blog.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Blog entity)
        {
            _dbContext.Blog.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Blog> GetAll()
        {
            return _dbContext.Blog;
        }

        public async Task<Blog> GetById(int id)
        {
            return await _dbContext.Blog.FindAsync(id);
        }

        public async Task<Blog> Update(Blog entity)
        {
            var result = await _dbContext.Blog.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

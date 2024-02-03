using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class PostItemsRepository : IRepository<PostItem>
    {
        private readonly ApplicationDbContext _dbContext;
        public PostItemsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(PostItem entity)
        {
            await _dbContext.PostItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(PostItem entity)
        {
            _dbContext.PostItems.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<PostItem> GetAll()
        {
            return _dbContext.PostItems;
        }

        public async Task<PostItem> GetById(int id)
        {
            return await _dbContext.PostItems.FindAsync(id);
        }

        public async Task<PostItem> Update(PostItem entity)
        {
            var result = await _dbContext.PostItems.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

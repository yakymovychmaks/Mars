using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly ApplicationDbContext _dbContext;
        public TagRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Tag entity)
        {
            await _dbContext.Tags.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Tag entity)
        {
            _dbContext.Tags.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Tag> GetAll()
        {
            return _dbContext.Tags;
        }

        public async Task<Tag> GetById(int id)
        {
            return await _dbContext.Tags.FindAsync(id);
        }

        public async Task<Tag> Update(Tag entity)
        {
            var result = await _dbContext.Tags.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

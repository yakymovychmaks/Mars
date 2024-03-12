using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class PhotoRepository : IRepository<Photo>
    {
        private readonly ApplicationDbContext _dbContext;
        public PhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Photo entity)
        {
            await _dbContext.Photos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Photo entity)
        {
            _dbContext.Photos.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Photo> GetAll()
        {
            return _dbContext.Photos;
        }

        public async Task<Photo> GetById(int id)
        {
            return await _dbContext.Photos.FindAsync(id);
        }

        public async Task<Photo> Update(Photo entity)
        {
            var result = await _dbContext.Photos.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

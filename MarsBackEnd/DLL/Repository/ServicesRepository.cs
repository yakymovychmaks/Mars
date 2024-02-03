using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class ServicesRepository : IRepository<Services>
    {
        private readonly ApplicationDbContext _dbContext;
        public ServicesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Services entity)
        {
            await _dbContext.Services.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Services entity)
        {
            _dbContext.Services.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Services> GetAll()
        {
            return _dbContext.Services;
        }

        public async Task<Services> GetById(int id)
        {
            return await _dbContext.Services.FindAsync(id);
        }

        public async Task<Services> Update(Services entity)
        {
            var result = await _dbContext.Services.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

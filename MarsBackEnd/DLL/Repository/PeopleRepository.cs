
using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class PeopleRepository : IRepository<People>
    {
        private readonly ApplicationDbContext _dbContext;
        public PeopleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(People entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(People entity)
        {
            _dbContext.People.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<People> GetAll()
        {
            return _dbContext.People;
        }

        public async Task<People> GetById(int id)
        {
            return await _dbContext.People.FindAsync(id);
        }

        public async Task<People> Update(People entity)
        {
            var result = await _dbContext.People.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

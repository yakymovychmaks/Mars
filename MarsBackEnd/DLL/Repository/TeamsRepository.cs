using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class TeamsRepository : IRepository<Teams>
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Teams entity)
        {
            await _dbContext.Teams.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Teams entity)
        {
            _dbContext.Teams.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Teams> GetAll()
        {
            return _dbContext.Teams;
        }

        public async Task<Teams> GetById(int id)
        {
            return await _dbContext.Teams.FindAsync(id);
        }

        public async Task<Teams> Update(Teams entity)
        {
            var result = await _dbContext.Teams.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Profile entity)
        {
            await _dbContext.Profiles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _dbContext.Profiles;
        }

        public async Task Delete(Profile entity)
        {
            _dbContext.Profiles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Profile> Update(Profile entity)
        {
            var result = await _dbContext.Profiles.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Profile> GetById(int id)
        {
            var result = await _dbContext.Profiles.FindAsync(id);
            return result;
        }
    }
}
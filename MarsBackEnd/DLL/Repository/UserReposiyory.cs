using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;


namespace DLL.Repository
{
    public class UserReposiyory : IRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;
        public UserReposiyory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
                return _dbContext.Users;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _dbContext.Users.FindAsync(id);
            return result;
        }

        public async Task<User> Update(User entity)
        {
            var result = await _dbContext.Users.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

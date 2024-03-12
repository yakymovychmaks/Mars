using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class PartnerRepository : IRepository<Partner>
    {
        private readonly ApplicationDbContext _dbContext;
        public PartnerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Partner> GetAll()
        {
            return _dbContext.Partners;
        }

        public async Task<Partner> GetById(int id)
        {
            return await _dbContext.Partners.FindAsync(id);
        }

        public async Task Create(Partner entity)
        {
            await _dbContext.Partners.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Partner entity)
        {
            _dbContext.Partners.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Partner> Update(Partner entity)
        {
            var result = await _dbContext.Partners.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        
    }
}

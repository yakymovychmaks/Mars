

using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class PatientWaitListRepository : IRepository<PatientWaitList>
    {
        private readonly ApplicationDbContext _dbContext;
        public PatientWaitListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(PatientWaitList entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(PatientWaitList entity)
        {
            _dbContext.PatientWaitList.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<PatientWaitList> GetAll()
        {
            return _dbContext.PatientWaitList;
        }

        public async Task<PatientWaitList> GetById(int id)
        {
            return await _dbContext.PatientWaitList.FindAsync(id);
        }

        public async Task<PatientWaitList> Update(PatientWaitList entity)
        {
            var result = await _dbContext.PatientWaitList.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

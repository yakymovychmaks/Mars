using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class ApointmentRepository : IRepository<Apointment>
    {
        private readonly ApplicationDbContext _dbContext;
        public ApointmentRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task Create(Apointment entity)
        {
            await _dbContext.Apointsments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Apointment entity)
        {
            _dbContext.Apointsments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Apointment> GetAll()
        {

            return _dbContext.Apointsments;



        }

        public async Task<Apointment> GetById(int id)
        {

            var result = await _dbContext.Apointsments.FindAsync(id);
            return result;

        }

        public async Task<Apointment> Update(Apointment entity)
        {
            var result = await _dbContext.Apointsments.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

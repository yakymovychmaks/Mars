using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;


namespace DLL.Repository
{
    public class MemberRolesRepository : IRepository<MemberRole>
    {
        private readonly ApplicationDbContext _dbContext;
        public MemberRolesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(MemberRole entity)
        {
            await _dbContext.MemberRoles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(MemberRole entity)
        {
            _dbContext.MemberRoles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<MemberRole> GetAll()
        {
            return _dbContext.MemberRoles;
        }

        public async Task<MemberRole> GetById(int id)
        {
            return await _dbContext.MemberRoles.FindAsync(id);
        }

        public async Task<MemberRole> Update(MemberRole entity)
        {
            var result = await _dbContext.MemberRoles.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

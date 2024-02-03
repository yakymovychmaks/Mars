using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;

namespace DLL.Repository
{
    public class ThemesQuestionRepository : IRepository<ThemesQuestion>
    {
        private readonly ApplicationDbContext _dbContext;
        public ThemesQuestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ThemesQuestion entity)
        {
            await _dbContext.ThemesQuestions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ThemesQuestion entity)
        {
            _dbContext.ThemesQuestions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<ThemesQuestion> GetAll()
        {
            return _dbContext.ThemesQuestions;
        }

        public async Task<ThemesQuestion> GetById(int id)
        {
            return await _dbContext.ThemesQuestions.FindAsync(id);
        }

        public async Task<ThemesQuestion> Update(ThemesQuestion entity)
        {
            var result = await _dbContext.ThemesQuestions.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

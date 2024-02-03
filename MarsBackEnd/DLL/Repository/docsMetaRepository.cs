using DLL.DataAccess;
using DLL.Interface;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class docsMetaRepository : IRepository<DocsMeta>
    {
        private readonly ApplicationDbContext _dbContext;
        public docsMetaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(DocsMeta entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(DocsMeta entity)
        {
            _dbContext.Docs.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<DocsMeta> GetAll()
        {
            return _dbContext.Docs;
        }

        public async Task<DocsMeta> GetById(int id)
        {
            return await _dbContext.Docs.FindAsync(id);
        }

        public async Task<DocsMeta> Update(DocsMeta entity)
        {
            var result = await _dbContext.Docs.FindAsync(entity.Id);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

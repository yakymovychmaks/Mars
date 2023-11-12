using DLL.DataAccess;
using DLL.Interface;
using DLL.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly ApplicationDbContext _DbContext;
        public OfficeRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(Office entity)
        {
            _DbContext.Office.Add(entity);    
        }

        public void Delete(int id)
        {
            var OfficeToDelete = _DbContext.Office.Find(id);
            if (OfficeToDelete != null)
            {
                _DbContext.Office.Remove(OfficeToDelete);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Office> GetAll()
        {
            return _DbContext.Office.ToList();
        }

        public Office GetById(int id)
        {
            return _DbContext.Office.Find(id);
        }

        public void Update(Office entity)
        {
            _DbContext.Office.Update(entity);
        }
    }
}

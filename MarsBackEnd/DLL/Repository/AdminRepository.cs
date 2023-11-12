using DLL.DataAccess;
using DLL.Interface;
using DLL.Models.AdminsModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class AdminRepository : IRepository<Admin>
    {
        private readonly ApplicationDbContext _DbContext;
        public AdminRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public void Add(Admin entity)
        {
            
        }

        public void Delete(int id)
        {
            var user = _DbContext.Admin.Find(id);
            if (user != null)
            {
                _DbContext.Admin.Remove(user);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            return _DbContext.Admin.ToList();
        }

        public Admin GetById(int id)
        {
            return _DbContext.Admin.Find(id);
        }

        public void Update(Admin entity)
        {
            _DbContext.Admin.Update(entity);
        }
    }
}

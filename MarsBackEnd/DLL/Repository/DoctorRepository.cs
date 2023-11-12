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
    internal class DoctorRepository : IRepository<Doctor>
    {
        private readonly ApplicationDbContext _DbContext;
        public DoctorRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(Doctor entity)
        {
            _DbContext.Doctors.Add(entity);    
        }

        public void Delete(int id)
        {
            var DoctorToDelete = _DbContext.Doctors.Find(id);
            if (DoctorToDelete != null)
            {
                _DbContext.Doctors.Remove(DoctorToDelete);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _DbContext.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _DbContext.Doctors.Find(id);
        }

        public void Update(Doctor entity)
        {
            _DbContext.Doctors.Update(entity);
        }
    }
}

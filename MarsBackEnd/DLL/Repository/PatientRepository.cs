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
    public class PatientRepository : IRepository<Patient>
    {
        private readonly ApplicationDbContext _DbContext;
        public PatientRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(Patient entity)
        {
            _DbContext.Patients.Add(entity);
        }

        public void Delete(int id)
        {
            var PatientToDelete = _DbContext.Patients.Find(id);
            if (PatientToDelete != null)
            {
                _DbContext.Patients.Remove(PatientToDelete);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            return _DbContext.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _DbContext.Patients.Find(id);
        }

        public void Update(Patient entity)
        {
            _DbContext.Update(entity);
        }
    }
}

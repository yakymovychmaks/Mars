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
    public class ApointmentRepository : IRepository<Apointment>
    {
        private readonly ApplicationDbContext _DbContext;
        public ApointmentRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Add(Apointment entity)
        {
            _DbContext.Add(entity);
        }

        public void Delete(int id)
        {
            var apointmentToDelete = _DbContext.Apointments.Find(id);
            if (apointmentToDelete != null)
            {
                _DbContext.Apointments.Remove(apointmentToDelete);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Apointment> GetAll()
        {
            return _DbContext.Apointments.ToList();
        }

        public Apointment GetById(int id)
        {
            return _DbContext.Apointments.Find(id);
        }

        public void Update(Apointment entity)
        {
            _DbContext.Apointments.Update(entity);
        }
    }
}

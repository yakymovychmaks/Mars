using DLL.DataAccess;
using DLL.Interface;
using DLL.Model.UserModel;
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
        public ApointmentRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public string Add(Apointment entity)
        {
            try
            {
                _DbContext.Apointsments.Add(entity);
                _DbContext.SaveChanges();
                return "DLL ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _DbContext.Apointsments.Remove(_DbContext.Apointsments.Find(id));
                _DbContext.SaveChanges();
                return "Dll ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Apointment> GetAll()
        {
            try
            {
                return _DbContext.Apointsments.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Apointment GetById(int id)
        {
            try
            {
                return _DbContext.Apointsments.Find(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(Apointment entity)
        {
            try
            {
                _DbContext.Update(entity);
                return "DLL ok";
            }
            catch (Exception ex)
            {
                return ex.Message;  
            }
        }
    }
}

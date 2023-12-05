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
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationDbContext _DbContext;
        public CommentRepository (ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public string Add(Comment entity)
        {
            try
            {
                _DbContext.Comments.Add(entity);
                _DbContext.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _DbContext.Comments.Remove(_DbContext.Comments.Find(id));
                _DbContext.SaveChanges();
                return "Ok";
            }catch (Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            try
            {
                return _DbContext.Comments.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Comment GetById(int id)
        {
            try
            {
                return _DbContext.Comments.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(Comment entity)
        {
            try
            {
                _DbContext.Comments.Update(entity);
                _DbContext.SaveChanges();
                return "Ok";
            }
            catch(Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
            }
        }
    }
}

using DLL.DataAccess;
using DLL.Interface;
using DLL.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _DbContext;
        public PostRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public string Add(Post entity)
        {
            try
            {
                _DbContext.Posts.Add(entity);
                _DbContext.SaveChanges();
                return "okey";
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
                _DbContext.Posts.Remove(_DbContext.Posts.Find(id));
                _DbContext.SaveChanges();
                return "okey";
            }
            catch (Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                return _DbContext.Posts.ToList();
            }
            catch { return null; }
        }

        public Post GetById(int id)
        {
            try
            {
                return _DbContext.Posts.Find(id);
            }
            catch { return null; }
        }

        public string Update(Post entity)
        {
            try
            {
                _DbContext.Posts.Update(entity);
                _DbContext.SaveChanges();
                return "It was update";
            }
            catch (Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
            }
        }
    }
}

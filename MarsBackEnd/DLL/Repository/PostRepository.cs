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
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _DbContext;
        public PostRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public string Add(Post entity)
        {
            _DbContext.Posts.Add(entity);
            _DbContext.SaveChanges();
            return "okey";
        }

        public string Delete(int id)
        {
            var postToDelete = _DbContext.Posts.Find(id);
            if (postToDelete != null)
            {

                _DbContext.Posts.Remove(postToDelete);
                _DbContext.SaveChanges();
                return "okey";
            }
            return "error delete";
        }

        public IEnumerable<Post> GetAll()
        {
            return _DbContext.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _DbContext.Posts.Find(id);
        }

        public string Update(Post entity)
        {
            _DbContext.Posts.Update(entity);
            _DbContext.SaveChanges();
            return "error";
        }
    }
}
